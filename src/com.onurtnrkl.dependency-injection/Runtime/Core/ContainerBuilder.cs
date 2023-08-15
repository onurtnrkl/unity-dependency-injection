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
            var objectResolver = new InstanceResolver(implementationInstance);
            _containerResolver.AddObjectResolver(registrationType, objectResolver);
        }

        public void AddSingleton(Type registrationType, Type implementationType)
        {
            var objectResolver = new SingletonResolver(implementationType, _containerResolver, _disposableCollection);
            _containerResolver.AddObjectResolver(registrationType, objectResolver);
        }

        public void AddTransient(Type registrationType, Type implementationType)
        {
            var objectResolver = new TransientResolver(implementationType, _containerResolver, _disposableCollection);
            _containerResolver.AddObjectResolver(registrationType, objectResolver);
        }

        public IContainer Build()
        {
            var container = new Container(_containerResolver, _disposableCollection, _children, _parent);
            _parent.AddChild(container);
            return container;
        }
    }
}
