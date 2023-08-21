using System;
using UnityEngine;

namespace DependencyInjection.Core
{
    public interface IContainerConfigurer
    {
        void AddInstance(Type registrationType, object implementationInstance);
        void AddSingleton(Type registrationType, Type implementationType);
        void AddSingleton(Type registrationType, Type implementationType, GameObject prefab);
        void AddTransient(Type registrationType, Type implementationType);
    }
}