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
            if (!_objectResolversByRegistrationTypes.TryGetValue(registrationType, out var objectResolver))
            {
                return null;
            }

            var implementationInstance = objectResolver.Resolve();

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
