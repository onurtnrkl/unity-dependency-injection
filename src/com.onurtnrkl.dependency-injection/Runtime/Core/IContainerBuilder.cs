using System;

namespace DependencyInjection.Core
{
    internal interface IContainerBuilder
    {
        void AddSingleton(Type registrationType, object implementationInstance);
        void AddSingleton(Type registrationType, Type implementationType);
        void AddTransient(Type registrationType, Type implementationType);
        void AddChild(IContainer child);
    }
}