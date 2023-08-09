using System;
using System.Runtime.CompilerServices;
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
            var instance = RuntimeHelpers.GetUninitializedObject(_implementationType);
            ConstructorInjector.Inject(instance, _rootResolver);

            return instance;
        }
    }
}
