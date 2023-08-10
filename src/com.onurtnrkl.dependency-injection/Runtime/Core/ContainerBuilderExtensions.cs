using System;

namespace DependencyInjection.Core
{
    internal static class ContainerBuilderExtensions
    {
        public static void AddSingleton(this ContainerBuilder containerBuilder, object implementationInstance)
        {
            containerBuilder.AddSingleton(implementationInstance.GetType(), implementationInstance);
        }

        public static void AddSingleton(this ContainerBuilder containerBuilder, Type implementationType)
        {
            containerBuilder.AddSingleton(implementationType, implementationType);
        }

        public static void AddTransient(this ContainerBuilder containerBuilder, Type implementationType)
        {
            containerBuilder.AddTransient(implementationType, implementationType);
        }
    }
}
