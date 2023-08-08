using System.Runtime.CompilerServices;
using System;
using System.Reflection;
using DependencyInjection.Activators;

namespace DependencyInjection.Resolution
{
    internal sealed class SingletonResolver : IObjectResolver
    {
        private readonly Type _implementationType;
        private readonly IRootResolver _rootResolver;
        private object _instance;

        public SingletonResolver(Type implementationType, IRootResolver rootResolver)
        {
            _implementationType = implementationType;
            _rootResolver = rootResolver;
        }

        public object Resolve()
        {
            if (_instance == null)
            {
                var objectActivator = _rootResolver.GetOrCreateObjectActivator(_implementationType);
                var parameterTypes = objectActivator.ParameterTypes;
                var parameters = new object[parameterTypes.Length];//TODO: Use object pooling instead.

                for (var i = 0; i < parameterTypes.Length; i++)
                {
                    var parameterType = parameterTypes[i];
                    parameters[i] = _rootResolver.Resolve(parameterType);
                }

                _instance = RuntimeHelpers.GetUninitializedObject(_implementationType);
                objectActivator.Activate(_instance, parameters);
            }

            return _instance;
        }
    }
}
