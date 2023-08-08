using System;
using DependencyInjection.Resolution;

namespace DependencyInjection.Core
{
    internal class Container
    {
        private readonly IRootResolver _rootResolver;

        public Container()
        {
            _rootResolver = new RootResolver();
        }

        public void AddInstance(Type registrationType, object instance)
        {
            _rootResolver.AddObjectResolver(registrationType, new InstanceResolver(instance));
        }

        public void AddInstance(object instance)
        {
            AddInstance(instance.GetType(), instance);
        }

        public void AddSingleton(Type registrationType, Type implementationType)
        {
            _rootResolver.AddObjectResolver(registrationType, new SingletonResolver(implementationType, _rootResolver));
        }

        public void AddSingleton(Type implementationType)
        {
            AddSingleton(implementationType, implementationType);
        }

        public object Resolve(Type registrationType)
        {
            return _rootResolver.Resolve(registrationType);
        }
    }
}
