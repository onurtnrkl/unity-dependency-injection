using System.Collections.Generic;
using System;

namespace DependencyInjection.Core
{
    internal class Container : IRootResolver
    {
        private readonly IDictionary<Type, IResolver> _resolversByRegistrationTypes;

        public Container()
        {
            _resolversByRegistrationTypes = new Dictionary<Type, IResolver>();
        }

        public void AddInstance(Type registrationType, object instance)
        {
            _resolversByRegistrationTypes.Add(registrationType, new InstanceResolver(instance));
        }

        public void AddInstance(object instance)
        {
            AddInstance(instance.GetType(), instance);
        }

        public void AddSingleton(Type registrationType, Type implementation)
        {
            _resolversByRegistrationTypes.Add(registrationType, new SingletonResolver(implementation, this));
        }

        public void AddSingleton(Type implementationType)
        {
            AddSingleton(implementationType, implementationType);
        }

        public object Resolve(Type registrationType)
        {
            var resolver = _resolversByRegistrationTypes[registrationType];
            var implementation = resolver.Resolve();

            return implementation;
        }
    }
}
