using System;
using System.Runtime.CompilerServices;
using DependencyInjection.Injectors;

namespace DependencyInjection.Resolution
{
    internal sealed class SingletonResolver : IObjectResolver
    {
        private readonly Type _implementationType;
        private readonly IContainerResolver _containerResolver;
        private object _instance;

        public SingletonResolver(Type implementationType, IContainerResolver containerResolver)
        {
            _implementationType = implementationType;
            _containerResolver = containerResolver;
        }

        public object Resolve()
        {
            if (_instance == null)
            {
                _instance = RuntimeHelpers.GetUninitializedObject(_implementationType);
                ConstructorInjector.Inject(_instance, _containerResolver);
            }

            return _instance;
        }
    }
}
