using DependencyInjection.Resolution;

namespace DependencyInjection.Core
{
    internal interface IContainer
    {
        IContainerResolver Resolver { get; }
        void AddChild(IContainer child);
        void RemoveChild(IContainer child);
    }
}
