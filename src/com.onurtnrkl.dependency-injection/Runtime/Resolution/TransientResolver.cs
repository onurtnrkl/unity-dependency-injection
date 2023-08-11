using System;
using System.Runtime.CompilerServices;
using DependencyInjection.Injectors;

namespace DependencyInjection.Resolution
{
    internal sealed class TransientResolver : IObjectResolver
    {
        private readonly Type _implementationType;
        private readonly IRegistrationResolver _registrationResolver;

        public TransientResolver(Type implementationType, IRegistrationResolver registrationResolver)
        {
            _implementationType = implementationType;
            _registrationResolver = registrationResolver;
        }

        public object Resolve()
        {
            var implementationInstance = RuntimeHelpers.GetUninitializedObject(_implementationType);
            ConstructorInjector.Inject(implementationInstance, _registrationResolver);

            return implementationInstance;
        }
    }
}
