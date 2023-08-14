using System;
using System.Collections.Generic;
using DependencyInjection.Resolution;

namespace DependencyInjection.Core
{
    public sealed class ContainerBuilder : IContainerConfigurer
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
            var objectResolver = new InstanceResolver(implementationInstance);
            _containerResolver.AddObjectResolver(registrationType, objectResolver);
        }

        public void AddSingleton(Type registrationType, Type implementationType)
        {
            var objectResolver = new SingletonResolver(implementationType, _containerResolver);
            _containerResolver.AddObjectResolver(registrationType, objectResolver);
        }

        public void AddTransient(Type registrationType, Type implementationType)
        {
            var objectResolver = new TransientResolver(implementationType, _containerResolver);
            _containerResolver.AddObjectResolver(registrationType, objectResolver);
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
