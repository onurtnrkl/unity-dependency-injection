using System.Runtime.CompilerServices;
using System;
using DependencyInjection.Injectors;

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
            var uninitializedObject = RuntimeHelpers.GetUninitializedObject(_implementationType);
            var objectActivator = _rootResolver.GetOrCreateObjectActivator(_implementationType);
            var instance = MethodBaseInjector.Inject(uninitializedObject, objectActivator, _rootResolver);

            return instance;
        }
    }
}
