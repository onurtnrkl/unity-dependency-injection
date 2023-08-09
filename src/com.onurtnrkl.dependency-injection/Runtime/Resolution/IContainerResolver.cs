using System;

namespace DependencyInjection.Resolution
{
    internal interface IContainerResolver
    {
        object Resolve(Type registrationType);
        void AddObjectResolver(Type registrationType, IObjectResolver objectResolver);
    }
}
