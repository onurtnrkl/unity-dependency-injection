using System;
using DependencyInjection.Core;

namespace DependencyInjection.Containers
{
    internal sealed class SceneContainer : IContainer
    {
        private readonly IContainer _container;

        public static SceneContainer Instance { get; private set; }

        private SceneContainer(IInstaller sceneInstaller)
        {
            var parent = ApplicationContainer.Instance;
            var containerBuilder = new ContainerBuilder();
            sceneInstaller.Install(containerBuilder);
            containerBuilder.SetParent(parent);
            _container = containerBuilder.Build();
            parent.AddChild(_container);
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

        public object Resolve(Type registrationType)
        {
            return _container.Resolve(registrationType);
        }
    }
}
