using System;
using System.Runtime.CompilerServices;
using DependencyInjection.Injectors;

namespace DependencyInjection.Resolution
{
    internal sealed class TransientResolver : IObjectResolver
    {
        private readonly Type _implementationType;
        private readonly IContainerResolver _containerResolver;

        public TransientResolver(Type implementationType, IContainerResolver containerResolver)
        {
            _implementationType = implementationType;
            _containerResolver = containerResolver;
        }

        public object Resolve()
        {
            var implementationInstance = RuntimeHelpers.GetUninitializedObject(_implementationType);
            ConstructorInjector.Inject(implementationInstance, _containerResolver);

            return implementationInstance;
        }
    }
}
