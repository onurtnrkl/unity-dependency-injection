using System.Collections.Generic;
using System;

namespace DependencyInjection.Resolution
{
    internal sealed class ContainerResolver : IContainerResolver
    {
        private readonly IDictionary<Type, IObjectResolver> _objectResolversByRegistrationTypes;

        public ContainerResolver()
        {
            _objectResolversByRegistrationTypes = new Dictionary<Type, IObjectResolver>();
        }

        public object Resolve(Type registrationType)
        {
            var resolver = _objectResolversByRegistrationTypes[registrationType];
            var implementationInstance = resolver.Resolve();

            return implementationInstance;
        }

        public void AddObjectResolver(Type registrationType, IObjectResolver objectResolver)
        {
            _objectResolversByRegistrationTypes.Add(registrationType, objectResolver);
        }

        public void Clear()
        {
            _objectResolversByRegistrationTypes.Clear();
        }
    }
}
