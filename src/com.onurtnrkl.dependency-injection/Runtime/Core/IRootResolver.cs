using System;

namespace DependencyInjection.Core
{
    internal interface IRootResolver
    {
        object Resolve(Type registrationType);
    }
}
