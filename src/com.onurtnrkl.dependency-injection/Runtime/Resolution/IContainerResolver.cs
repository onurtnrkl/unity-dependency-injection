using System;

namespace DependencyInjection.Resolution
{
    internal interface IContainerResolver : IRegistrationResolver
    {
        void AddObjectResolver(Type registrationType, IObjectResolver objectResolver);
        void Clear();
    }
}
