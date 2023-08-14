using DependencyInjection.Resolution;

namespace DependencyInjection.Core
{
    public interface IContainer : IRegistrationResolver
    {
        void AddChild(IContainer child);
        void RemoveChild(IContainer child);
    }
}
