using System.Collections.Generic;
using System;

namespace DependencyInjection.Core
{
    internal class Container
    {
        private readonly IDictionary<Type, IResolver> _resolversByRegistrationType;

        public Container()
        {
            _resolversByRegistrationType = new Dictionary<Type, IResolver>();
        }

        public void AddInstance<TRegistration, TImplementation>(TImplementation implementation) where TRegistration : class where TImplementation : class, TRegistration
        {
            var registrationType = typeof(TRegistration);
            _resolversByRegistrationType.Add(registrationType, new InstanceResolver(implementation));
        }

        public void AddSingleton<TRegistration, TImplementation>() where TRegistration : class where TImplementation : class, TRegistration
        {
            var registrationType = typeof(TRegistration);
            var implementationType = typeof(TImplementation);
            _resolversByRegistrationType.Add(registrationType, new SingletonResolver(implementationType));
        }

        public object Resolve(Type registrationType)
        {
            var resolver = _resolversByRegistrationType[registrationType];
            var implementation = resolver.Resolve();

            return implementation;
        }
    }
}
