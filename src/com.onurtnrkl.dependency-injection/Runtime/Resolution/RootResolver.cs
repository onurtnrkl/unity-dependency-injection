using System.Collections.Generic;
using System;
using DependencyInjection.Activators;
using System.Reflection;

namespace DependencyInjection.Resolution
{
    internal sealed class RootResolver : IRootResolver
    {
        private readonly IDictionary<Type, IObjectResolver> _objectResolversByRegistrationTypes;
        private readonly IDictionary<Type, IObjectActivator> _objectActivatorsByImplementationTypes;

        public RootResolver()
        {
            _objectResolversByRegistrationTypes = new Dictionary<Type, IObjectResolver>();
            _objectActivatorsByImplementationTypes = new Dictionary<Type, IObjectActivator>();
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

        public IObjectActivator GetOrCreateObjectActivator(Type implementationType)
        {
            if (!_objectActivatorsByImplementationTypes.TryGetValue(implementationType, out var objectActivator))
            {
                var constructor = implementationType.GetConstructors(BindingFlags.Public | BindingFlags.Instance)[0];
                objectActivator = new MethodBaseActivator(constructor);
                _objectActivatorsByImplementationTypes.Add(implementationType, objectActivator);
            }

            return objectActivator;
        }
    }
}
