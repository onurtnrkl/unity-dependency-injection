using System;

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

        public static void AddTransient(this IContainerConfigurer containerConfigurer, Type implementationType)
        {
            containerConfigurer.AddTransient(implementationType, implementationType);
        }
    }
}
