using System;
using System.Runtime.CompilerServices;
using DependencyInjection.Injectors;

namespace DependencyInjection.Resolution
{
    internal sealed class SingletonResolver : IObjectResolver
    {
        private readonly Type _implementationType;
        private readonly IRegistrationResolver _registrationResolver;
        private readonly IDisposableCollection _disposableCollection;
        private object _implementationInstance;

        public SingletonResolver(Type implementationType, IRegistrationResolver registrationResolver, IDisposableCollection disposableCollection)
        {
            _implementationType = implementationType;
            _registrationResolver = registrationResolver;
            _disposableCollection = disposableCollection;
        }

        public object Resolve()
        {
            if (_implementationInstance == null)
            {
                _implementationInstance = RuntimeHelpers.GetUninitializedObject(_implementationType);
                ConstructorInjector.Inject(_implementationInstance, _registrationResolver);
                _disposableCollection.TryAdd(_implementationInstance);
            }

            return _implementationInstance;
        }
    }
}
