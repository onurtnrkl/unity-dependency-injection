using DependencyInjection.Resolution;

namespace DependencyInjection.Core
{
    internal interface IContainer : IRegistrationResolver
    {
        void AddChild(IContainer child);
        void RemoveChild(IContainer child);
    }
}
