using System;
using DependencyInjection.Core;
using DependencyInjection.Injectors;
using UnityEngine;
using Object = UnityEngine.Object;

namespace DependencyInjection.Resolution
{
    internal sealed class PrefabResolver : IObjectResolver
    {
        private readonly Type _implementationType;
        private readonly GameObject _prefab;
        private readonly IRegistrationResolver _registrationResolver;
        private readonly IDisposableCollection _disposableCollection;

        public PrefabResolver(Type implementationType, GameObject prefab, IRegistrationResolver registrationResolver, IDisposableCollection disposableCollection)
        {
            _implementationType = implementationType;
            _prefab = prefab;
            _registrationResolver = registrationResolver;
            _disposableCollection = disposableCollection;
        }

        public object Resolve()
        {
            var instance = Object.Instantiate(_prefab).GetComponent(_implementationType);
            MethodInjector.Inject(instance, _registrationResolver);
            _disposableCollection.TryAdd(instance);

            return instance;
        }
    }
}
