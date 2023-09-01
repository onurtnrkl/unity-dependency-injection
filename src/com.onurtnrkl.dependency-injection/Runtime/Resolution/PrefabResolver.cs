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
        private readonly IContainer _parent;

        public PrefabResolver(Type implementationType, GameObject prefab, IRegistrationResolver registrationResolver, IDisposableCollection disposableCollection, IContainer parent)
        {
            _implementationType = implementationType;
            _prefab = prefab;
            _registrationResolver = registrationResolver;
            _disposableCollection = disposableCollection;
            _parent = parent;
        }

        public object Resolve()
        {
            var gameObject = Object.Instantiate(_prefab);
            var instance = gameObject.GetComponent(_implementationType);

            if (_parent == Container.Root)
            {
                Object.DontDestroyOnLoad(gameObject);
            }

            MethodInjector.Inject(instance, _registrationResolver);
            _disposableCollection.TryAdd(instance);

            return instance;
        }
    }
}
