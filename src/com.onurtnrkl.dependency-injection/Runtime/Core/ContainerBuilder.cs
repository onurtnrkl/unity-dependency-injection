using System;
using DependencyInjection.Resolution;

namespace DependencyInjection.Core
{
    internal class ContainerBuilder : IContainerBuilder
    {
        private readonly IContainerResolver _containerResolver;

        public ContainerBuilder()
        {
            _containerResolver = new ContainerResolver();
        }

        public void AddInstance(Type registrationType, object instance)
        {
            _containerResolver.AddObjectResolver(registrationType, new InstanceResolver(instance));
        }

        public void AddInstance(object instance)
        {
            AddInstance(instance.GetType(), instance);
        }

        public void AddSingleton(Type registrationType, Type implementationType)
        {
            _containerResolver.AddObjectResolver(registrationType, new SingletonResolver(implementationType, _containerResolver));
        }

        public void AddSingleton(Type implementationType)
        {
            AddSingleton(implementationType, implementationType);
        }

        public void AddTransient(Type registrationType, Type implementationType)
        {
            _containerResolver.AddObjectResolver(registrationType, new TransientResolver(implementationType, _containerResolver));
        }

        public void AddTransient(Type implementationType)
        {
            AddTransient(implementationType, implementationType);
        }

        public IContainer Build()
        {
            var container = new Container(_containerResolver);

            return container;
        }
    }
}
