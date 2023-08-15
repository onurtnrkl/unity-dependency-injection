using System;
using System.Collections.Generic;
using DependencyInjection.Resolution;

namespace DependencyInjection.Core
{
    internal sealed class Container : IContainer
    {
        public static readonly IContainer Null = new NullContainer();

        private readonly IContainerResolver _resolver;
        private readonly IList<IContainer> _children;
        private readonly IContainer _parent;

        public Container(IContainerResolver resolver, IList<IContainer> children, IContainer parent)
        {
            _resolver = resolver;
            _children = children;
            _parent = parent;
        }

        public void Dispose()
        {
            _parent.RemoveChild(this);

            foreach (var child in _children)
            {
                child.Dispose();
            }

            _resolver.Clear();
            _children.Clear();
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
