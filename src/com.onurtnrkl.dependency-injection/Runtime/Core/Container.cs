using System;
using System.Collections.Generic;
using DependencyInjection.Resolution;

namespace DependencyInjection.Core
{
    internal sealed class Container : IContainer
    {
        private readonly IContainerResolver _resolver;
        private readonly IList<IContainer> _children;
        private readonly IContainer _parent;

        public Container(IContainerResolver resolver, IList<IContainer> children, IContainer parent)
        {
            _resolver = resolver;
            _children = children;
            _parent = parent;
        }

        public void AddChild(IContainer child)
        {
            _children.Add(child);
        }

        public void RemoveChild(IContainer child)
        {
            _children.Remove(child);
        }

        public object Resolve(Type registrationType)
        {
            return _resolver.Resolve(registrationType);
        }
    }
}
