using System;
using System.Collections.Generic;
using DependencyInjection.Resolution;

namespace DependencyInjection.Core
{
    public sealed class ContainerBuilder : IContainerBuilder
    {
        private readonly IContainerResolver _containerResolver;
        private readonly IDisposableCollection _disposableCollection;
        private readonly IList<IContainer> _children;
        private readonly IContainer _parent;

        public ContainerBuilder(IContainer parent)
        {
            _containerResolver = new ContainerResolver(parent);
            _disposableCollection = new DisposableCollection();
            _children = new List<IContainer>();
            _parent = parent;
        }

        public void AddInstance(Type registrationType, object implementationInstance)
        {
            var instanceResolver = new InstanceResolver(implementationInstance);
            _containerResolver.AddInstanceResolver(registrationType, instanceResolver);
        }

        public void AddSingleton(Type registrationType, Type implementationType)
        {
            var objectResolver = new ObjectResolver(implementationType, _containerResolver, _disposableCollection);
            var instanceResolver = new SingletonResolver(objectResolver);
            _containerResolver.AddInstanceResolver(registrationType, instanceResolver);
        }

        public void AddTransient(Type registrationType, Type implementationType)
        {
            var objectResolver = new ObjectResolver(implementationType, _containerResolver, _disposableCollection);
            var instanceResolver = new TransientResolver(objectResolver);
            _containerResolver.AddInstanceResolver(registrationType, instanceResolver);
        }

        public IContainer Build()
        {
            var container = new Container(_containerResolver, _disposableCollection, _children, _parent);
            _parent.AddChild(container);
            return container;
        }
    }
}
