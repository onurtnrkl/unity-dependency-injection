using System;
using System.Runtime.CompilerServices;
using DependencyInjection.Injectors;

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
                ConstructorInjector.Inject(_instance, _rootResolver);
            }

            return _instance;
        }
    }
}
