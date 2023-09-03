using System;
using UnityEngine;

namespace DependencyInjection.Core
{
    public interface IContainerConfigurer
    {
        void AddInstance(Type registrationType, object implementationInstance);
        void AddSingleton(Type registrationType, Type implementationType);
        void AddTransient(Type registrationType, Type implementationType);
        void AddSingletonComponent(Type registrationType, Type implementationType, Component component);
        void AddSingletonPrefab(Type registrationType, Type implementationType, GameObject prefab);
        void AddTransientPrefab(Type registrationType, Type implementationType, GameObject prefab);
    }
}