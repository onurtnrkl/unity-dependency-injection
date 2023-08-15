using System.Collections.Generic;
using System;

namespace DependencyInjection.Resolution
{
    internal sealed class ContainerResolver : IContainerResolver
    {
        private readonly IDictionary<Type, IObjectResolver> _objectResolversByRegistrationTypes;
        private readonly IRegistrationResolver _parent;

        public ContainerResolver(IRegistrationResolver parent)
        {
            _objectResolversByRegistrationTypes = new Dictionary<Type, IObjectResolver>();
            _parent = parent;
        }

        public object Resolve(Type registrationType)
        {
            if (_objectResolversByRegistrationTypes.TryGetValue(registrationType, out var objectResolver))
            {
                return objectResolver.Resolve();
            }

            return _parent.Resolve(registrationType);
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
