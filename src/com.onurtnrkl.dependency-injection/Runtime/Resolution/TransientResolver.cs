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
            return ConstructorInjector.Inject(_implementationType, _rootResolver);
        }
    }
}
