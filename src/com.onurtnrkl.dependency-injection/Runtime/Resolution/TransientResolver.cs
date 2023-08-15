using System;
using System.Runtime.CompilerServices;
using DependencyInjection.Core;
using DependencyInjection.Injectors;

namespace DependencyInjection.Resolution
{
    internal sealed class TransientResolver : IObjectResolver
    {
        private readonly Type _implementationType;
        private readonly IRegistrationResolver _registrationResolver;
        private readonly IDisposableCollection _disposableCollection;

        public TransientResolver(Type implementationType, IRegistrationResolver registrationResolver, IDisposableCollection disposableCollection)
        {
            _implementationType = implementationType;
            _registrationResolver = registrationResolver;
            _disposableCollection = disposableCollection;
        }

        public object Resolve()
        {
            var implementationInstance = RuntimeHelpers.GetUninitializedObject(_implementationType);
            ConstructorInjector.Inject(implementationInstance, _registrationResolver);
            _disposableCollection.TryAdd(implementationInstance);

            return implementationInstance;
        }
    }
}
