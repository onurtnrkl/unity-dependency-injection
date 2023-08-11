using DependencyInjection.Core;
using DependencyInjection.Resolution;

namespace DependencyInjection.Containers
{
    internal sealed class SceneContainer : IContainer
    {
        private readonly IContainer _container;

        public static SceneContainer Instance { get; private set; }

        public IContainerResolver Resolver => _container.Resolver;

        private SceneContainer(IInstaller sceneInstaller)
        {
            var containerBuilder = new ContainerBuilder();
            sceneInstaller.Install(containerBuilder);
            _container = containerBuilder.Build();
            ApplicationContainer.Instance.AddChild(_container);
        }

        public static void CreateInstance(IInstaller sceneInstaller)
        {
            Instance = new SceneContainer(sceneInstaller);
        }

        public static void DestroyInstance()
        {
            // TODO: Dispose container first
            ApplicationContainer.Instance.RemoveChild(Instance._container);
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
