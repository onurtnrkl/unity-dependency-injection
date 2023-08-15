using System;

namespace DependencyInjection.Core
{
    internal sealed class EmptyContainer : IContainer
    {
        public EmptyContainer()
        {
        }

        public void AddChild(IContainer child)
        {
        }

        public void Dispose()
        {
        }

        public void RemoveChild(IContainer child)
        {
        }

        public object Resolve(Type registrationType)
        {
            return null;
        }
    }
}
