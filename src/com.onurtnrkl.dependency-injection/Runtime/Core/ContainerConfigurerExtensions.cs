using System;
using UnityEngine;

namespace DependencyInjection.Core
{
    public static class ContainerConfigurerExtensions
    {
        public static void AddInstance(this IContainerConfigurer containerConfigurer, object implementationInstance)
        {
            var implementationType = implementationInstance.GetType();
            containerConfigurer.AddInstance(implementationType, implementationInstance);
        }

        public static void AddSingleton(this IContainerConfigurer containerConfigurer, Type implementationType)
        {
            containerConfigurer.AddSingleton(implementationType, implementationType);
        }

        public static void AddTransient(this IContainerConfigurer containerConfigurer, Type implementationType)
        {
            containerConfigurer.AddTransient(implementationType, implementationType);
        }

        public static void AddSingletonComponent(this IContainerConfigurer containerConfigurer, Type implementationType, Component component)
        {
            containerConfigurer.AddSingletonComponent(implementationType, implementationType, component);
        }

        public static void AddSingletonPrefab(this IContainerConfigurer containerConfigurer, Type implementationType, GameObject prefab)
        {
            containerConfigurer.AddSingletonPrefab(implementationType, implementationType, prefab);
        }

        public static void AddTransientPrefab(this IContainerConfigurer containerConfigurer, Type implementationType, GameObject prefab)
        {
            containerConfigurer.AddTransientPrefab(implementationType, implementationType, prefab);
        }

        public static void AddInstance<TRegistration, TImplementation>(this IContainerConfigurer containerConfigurer, TImplementation implementationInstance)
            where TImplementation : class where TRegistration : TImplementation
        {
            var registrationType = typeof(TRegistration);
            containerConfigurer.AddInstance(registrationType, implementationInstance);
        }

        public static void AddInstance<TImplementation>(this IContainerConfigurer containerConfigurer, TImplementation implementationInstance)
            where TImplementation : class
        {
            var implementationType = typeof(TImplementation);
            containerConfigurer.AddInstance(implementationType, implementationInstance);
        }

        public static void AddSingleton<TRegistration, TImplementation>(this IContainerConfigurer containerConfigurer)
            where TImplementation : class where TRegistration : TImplementation
        {
            var registrationType = typeof(TRegistration);
            var implementationType = typeof(TImplementation);
            containerConfigurer.AddSingleton(registrationType, implementationType);
        }

        public static void AddSingleton<TImplementation>(this IContainerConfigurer containerConfigurer)
            where TImplementation : class
        {
            var implementationType = typeof(TImplementation);
            containerConfigurer.AddSingleton(implementationType, implementationType);
        }

        public static void AddTransient<TRegistration, TImplementation>(this IContainerConfigurer containerConfigurer)
            where TImplementation : class where TRegistration : TImplementation
        {
            var registrationType = typeof(TRegistration);
            var implementationType = typeof(TImplementation);
            containerConfigurer.AddTransient(registrationType, implementationType);
        }

        public static void AddTransient<TImplementation>(this IContainerConfigurer containerConfigurer)
            where TImplementation : class
        {
            var implementationType = typeof(TImplementation);
            containerConfigurer.AddTransient(implementationType, implementationType);
        }

        public static void AddSingletonComponent<TRegistration, TImplementation>(this IContainerConfigurer containerConfigurer, TImplementation component)
            where TImplementation : Component where TRegistration : TImplementation
        {
            var registrationType = typeof(TRegistration);
            var implementationType = typeof(TImplementation);
            containerConfigurer.AddSingletonComponent(registrationType, implementationType, component);
        }

        public static void AddSingletonComponent<TImplementation>(this IContainerConfigurer containerConfigurer, TImplementation component)
            where TImplementation : Component
        {
            var implementationType = typeof(TImplementation);
            containerConfigurer.AddSingletonComponent(implementationType, implementationType, component);
        }

        public static void AddSingletonPrefab<TRegistration, TImplementation>(this IContainerConfigurer containerConfigurer, GameObject prefab)
            where TImplementation : Component where TRegistration : TImplementation
        {
            var registrationType = typeof(TRegistration);
            var implementationType = typeof(TImplementation);
            containerConfigurer.AddSingletonPrefab(registrationType, implementationType, prefab);
        }

        public static void AddSingletonPrefab<TImplementation>(this IContainerConfigurer containerConfigurer, GameObject prefab)
            where TImplementation : Component
        {
            var implementationType = typeof(TImplementation);
            containerConfigurer.AddSingletonPrefab(implementationType, implementationType, prefab);
        }

        public static void AddTransientPrefab<TRegistration, TImplementation>(this IContainerConfigurer containerConfigurer, GameObject prefab)
            where TImplementation : Component where TRegistration : TImplementation
        {
            var registrationType = typeof(TRegistration);
            var implementationType = typeof(TImplementation);
            containerConfigurer.AddTransientPrefab(registrationType, implementationType, prefab);
        }

        public static void AddTransientPrefab<TImplementation>(this IContainerConfigurer containerConfigurer, GameObject prefab)
           where TImplementation : Component
        {
            var implementationType = typeof(TImplementation);
            containerConfigurer.AddTransientPrefab(implementationType, implementationType, prefab);
        }
    }
}
