using System;
using System.Collections.Generic;
using DependencyInjection.Resolution;

namespace DependencyInjection.Core
{
    internal sealed class ContainerBuilder : IContainerBuilder
    {
        private readonly IContainerResolver _containerResolver;
        private readonly IList<IContainer> _children;
        private IContainer _parent;

        public ContainerBuilder()
        {
            _containerResolver = new ContainerResolver();
            _children = new List<IContainer>();
            // TODO: Set application container as parent
        }

        public void AddInstance(Type registrationType, object implementationInstance)
        {
            _containerResolver.AddObjectResolver(registrationType, new InstanceResolver(implementationInstance));
        }

        public void AddSingleton(Type registrationType, Type implementationType)
        {
            _containerResolver.AddObjectResolver(registrationType, new SingletonResolver(implementationType, _containerResolver));
        }

        public void AddTransient(Type registrationType, Type implementationType)
        {
            _containerResolver.AddObjectResolver(registrationType, new TransientResolver(implementationType, _containerResolver));
        }

        public void AddChild(IContainer child)
        {
            _children.Add(child);
        }

        public void SetParent(IContainer parent)
        {
            _parent = parent;
        }

        public IContainer Build()
        {
            var container = new Container(_containerResolver, _children, _parent);

            return container;
        }
    }
}
