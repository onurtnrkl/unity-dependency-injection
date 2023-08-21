using System;
using UnityEngine;

namespace DependencyInjection.Core
{
    public static class ContainerConfigurerExtensions
    {
        public static void AddInstance(this IContainerConfigurer containerConfigurer, object implementationInstance)
        {
            containerConfigurer.AddInstance(implementationInstance.GetType(), implementationInstance);
        }

        public static void AddSingleton(this IContainerConfigurer containerConfigurer, Type implementationType)
        {
            containerConfigurer.AddSingleton(implementationType, implementationType);
        }

        public static void AddSingleton(this IContainerConfigurer containerConfigurer, Type implementationType, GameObject prefab)
        {
            containerConfigurer.AddSingleton(implementationType, implementationType, prefab);
        }

        public static void AddSingleton(this IContainerConfigurer containerConfigurer, Component prefab)
        {
            var implementationType = prefab.GetType();
            containerConfigurer.AddSingleton(implementationType, implementationType, prefab.gameObject);
        }

        public static void AddTransient(this IContainerConfigurer containerConfigurer, Type implementationType)
        {
            containerConfigurer.AddTransient(implementationType, implementationType);
        }
    }
}
