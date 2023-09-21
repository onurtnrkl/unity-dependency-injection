using DependencyInjection.Core;
using DependencyInjection.Tests.Fakes;
using NUnit.Framework;
using UnityEngine;

namespace DependencyInjection.Tests
{
    internal sealed class ContainerTests
    {
        [Test]
        public void Resolve_ContainerWithPrefab_ShouldBeInjectedWithZeroParameterClass()
        {
            var containerBuilder = new ContainerBuilder(Container.Root);
            var prefab = new GameObject("OneParameterMonoBehaviour", typeof(OneParameterMonoBehaviour));
            containerBuilder.AddSingletonPrefab(typeof(OneParameterMonoBehaviour), prefab);
            containerBuilder.AddSingleton(typeof(IZeroParameterClass), typeof(ZeroParameterClass));
            var container = containerBuilder.Build();
            var instance = (OneParameterMonoBehaviour)container.Resolve(typeof(OneParameterMonoBehaviour));

            Assert.IsNotNull(instance.GetZeroParameterClass());
        }

        [Test]
        public void Resolve_ContainerWithComponent_ShouldBeInjectedWithZeroParameterClass()
        {
            var containerBuilder = new ContainerBuilder(Container.Root);
            var component = new GameObject("OneParameterMonoBehaviour").AddComponent<OneParameterMonoBehaviour>();
            containerBuilder.AddSingletonComponent(typeof(OneParameterMonoBehaviour), component);
            containerBuilder.AddSingleton(typeof(IZeroParameterClass), typeof(ZeroParameterClass));
            var container = containerBuilder.Build();
            var instance = (OneParameterMonoBehaviour)container.Resolve(typeof(OneParameterMonoBehaviour));

            Assert.IsNotNull(instance.GetZeroParameterClass());
        }
    }
}
