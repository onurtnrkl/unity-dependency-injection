using System;
using DependencyInjection.Activators;

namespace DependencyInjection.Resolution
{
    internal interface IRootResolver
    {
        object Resolve(Type registrationType);
        void AddObjectResolver(Type registrationType, IObjectResolver objectResolver);
        IObjectActivator GetOrCreateObjectActivator(Type implementationType);
    }
}
