using System.Runtime.CompilerServices;
using System;
using System.Buffers;
using DependencyInjection.Pool;

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
            var instance = RuntimeHelpers.GetUninitializedObject(_implementationType);
            var objectActivator = _rootResolver.GetOrCreateObjectActivator(_implementationType);
            var parameterTypes = objectActivator.ParameterTypes;
            var parameterTypesLength = parameterTypes.Length;

            using (FixedSizeArrayPool<object>.Get(parameterTypesLength, out var parameters))
            {
                for (var i = 0; i < parameterTypesLength; i++)
                {
                    var parameterType = parameterTypes[i];
                    parameters[i] = _rootResolver.Resolve(parameterType);
                }

                objectActivator.Activate(instance, parameters);
            }

            return instance;
        }
    }
}
