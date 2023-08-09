using System.Runtime.CompilerServices;
using System;
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
                var uninitializedObject = RuntimeHelpers.GetUninitializedObject(_implementationType);
                var objectActivator = _rootResolver.GetOrCreateObjectActivator(_implementationType);
                _instance = MethodBaseInjector.Inject(uninitializedObject, objectActivator, _rootResolver);
            }

            return _instance;
        }
    }
}
