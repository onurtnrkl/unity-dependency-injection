using System;
using DependencyInjection.Core;

namespace DependencyInjection.Containers
{
    internal sealed class ApplicationContainer : IContainer
    {
        private readonly IContainer _container;

        public static ApplicationContainer Instance { get; private set; }

        private ApplicationContainer(IInstaller applicationInstaller)
        {
            var containerBuilder = new ContainerBuilder();
            applicationInstaller.Install(containerBuilder);
            _container = containerBuilder.Build();
        }

        public static void CreateInstance(IInstaller applicationInstaller)
        {
            Instance = new ApplicationContainer(applicationInstaller);
        }

        public static void DestroyInstance()
        {
            // TODO: Dispose container first
            Instance = null;
        }

        public void AddChild(IContainer child)
        {
            _container.AddChild(child);
        }

        public void RemoveChild(IContainer child)
        {
            _container.RemoveChild(child);
        }

        public object Resolve(Type registrationType)
        {
            return _container.Resolve(registrationType);
        }
    }
}
