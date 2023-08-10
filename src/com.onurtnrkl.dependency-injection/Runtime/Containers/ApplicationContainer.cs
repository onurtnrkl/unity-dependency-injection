using DependencyInjection.Core;
using DependencyInjection.Resolution;

namespace DependencyInjection.Containers
{
    internal sealed class ApplicationContainer : IContainer
    {
        private readonly IContainer _container;

        public static ApplicationContainer Instance { get; private set; }

        public IContainerResolver Resolver => _container.Resolver;

        private ApplicationContainer(IInstaller applicationInstaller)
        {
            var containerBuilder = new ContainerBuilder();
            applicationInstaller.Install(containerBuilder);
            _container = containerBuilder.Build();
        }

        public static ApplicationContainer CreateInstance(IInstaller applicationInstaller)
        {
            Instance = new ApplicationContainer(applicationInstaller);

            return Instance;
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
    }
}
