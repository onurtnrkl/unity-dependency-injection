using System;

namespace DependencyInjection.Core
{
    internal interface IContainerBuilder
    {
        void AddInstance(Type registrationType, object implementationInstance);
        void AddSingleton(Type registrationType, Type implementationType);
        void AddTransient(Type registrationType, Type implementationType);
        void AddChild(IContainer child);
        void SetParent(IContainer parent);
        IContainer Build();
    }
}