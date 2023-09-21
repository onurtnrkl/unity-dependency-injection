using System;
using DependencyInjection.Core;
using DependencyInjection.Injectors;
using UnityEngine;

namespace DependencyInjection.Resolution
{
    internal sealed class ComponentResolver : IObjectResolver
    {
        private readonly Component _component;
        private readonly IRegistrationResolver _registrationResolver;
        private readonly IDisposableCollection _disposableCollection;

        public ComponentResolver(Component component, IRegistrationResolver registrationResolver, IDisposableCollection disposableCollection)
        {
            _component = component;
            _registrationResolver = registrationResolver;
            _disposableCollection = disposableCollection;
        }

        public object Resolve()
        {
            var instance = _component;
            MethodInjector.Inject(instance, _registrationResolver);
            _disposableCollection.TryAdd(instance);

            return instance;
        }
    }
}
