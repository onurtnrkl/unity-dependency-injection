using System;
using System.Runtime.CompilerServices;
using DependencyInjection.Injectors;

namespace DependencyInjection.Resolution
{
    internal sealed class SingletonResolver : IObjectResolver
    {
        private readonly Type _implementationType;
        private readonly IContainerResolver _containerResolver;
        private object _implementationInstance;

        public SingletonResolver(Type implementationType, IContainerResolver containerResolver)
        {
            _implementationType = implementationType;
            _containerResolver = containerResolver;
        }

        public object Resolve()
        {
            if (_implementationInstance == null)
            {
                _implementationInstance = RuntimeHelpers.GetUninitializedObject(_implementationType);
                ConstructorInjector.Inject(_implementationInstance, _containerResolver);
            }

            return _implementationInstance;
        }
    }
}
