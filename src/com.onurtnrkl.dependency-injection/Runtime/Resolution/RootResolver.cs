using System.Collections.Generic;
using System;

namespace DependencyInjection.Resolution
{
    internal sealed class RootResolver : IRootResolver
    {
        private readonly IDictionary<Type, IObjectResolver> _objectResolversByRegistrationTypes;

        public RootResolver()
        {
            _objectResolversByRegistrationTypes = new Dictionary<Type, IObjectResolver>();
        }

        public object Resolve(Type registrationType)
        {
            var resolver = _objectResolversByRegistrationTypes[registrationType];
            var implementation = resolver.Resolve();

            return implementation;
        }

        public void AddObjectResolver(Type registrationType, IObjectResolver objectResolver)
        {
            _objectResolversByRegistrationTypes.Add(registrationType, objectResolver);
        }
    }
}
