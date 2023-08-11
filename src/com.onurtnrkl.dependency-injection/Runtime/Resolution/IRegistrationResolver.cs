using System;

namespace DependencyInjection.Resolution
{
    internal interface IRegistrationResolver
    {
        object Resolve(Type registrationType);
    }
}