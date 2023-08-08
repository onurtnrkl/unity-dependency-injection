using System.Runtime.CompilerServices;
using System;
using DependencyInjection.Pool;

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
                _instance = RuntimeHelpers.GetUninitializedObject(_implementationType);
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

                    objectActivator.Activate(_instance, parameters);
                }
            }

            return _instance;
        }
    }
}
