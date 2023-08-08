using System.Runtime.CompilerServices;
using System;

namespace DependencyInjection.Resolution
{
    internal sealed class TransientResolver : IObjectResolver
    {
        private readonly Type _implementationType;
        private readonly IRootResolver _rootResolver;

        public TransientResolver(Type implementationType, IRootResolver rootResolver)
        {
            _implementationType = implementationType;
            _rootResolver = rootResolver;
        }

        public object Resolve()
        {
            var objectActivator = _rootResolver.GetOrCreateObjectActivator(_implementationType);
            var parameterTypes = objectActivator.ParameterTypes;
            var parameters = new object[parameterTypes.Length];//TODO: Use object pooling instead.

            for (var i = 0; i < parameterTypes.Length; i++)
            {
                var parameterType = parameterTypes[i];
                parameters[i] = _rootResolver.Resolve(parameterType);
            }

            var instance = RuntimeHelpers.GetUninitializedObject(_implementationType);
            objectActivator.Activate(instance, parameters);

            return instance;
        }
    }
}
