using DependencyInjection.Core;
using DependencyInjection.EditorTests.Fakes;
using DependencyInjection.EditorTests.Mocks;
using DependencyInjection.Resolution;
using NUnit.Framework;

namespace DependencyInjection.EditorTests
{
    internal sealed class ContainerResolverTests : TestsBase
    {
        [Test]
        public void Resolve_InstanceWithZeroParameterClassInstanceWithRegistrationType_ShouldReturnInstanceOfRegistrationType()
        {
            var containerResolver = new ContainerResolver(Container.Root);
            var instanceResolver = new InstanceResolver(new ZeroParameterClass());
            containerResolver.AddInstanceResolver(typeof(IZeroParameterClass), instanceResolver);
            var instance = containerResolver.Resolve(typeof(IZeroParameterClass));
            Assert.IsInstanceOf<IZeroParameterClass>(instance);
        }

        [Test]
        public void Resolve_InstanceWithZeroParameterClassInstanceWithImplementationType_ShouldReturnInstanceOfImplementationType()
        {
            var containerResolver = new ContainerResolver(Container.Root);
            var instanceResolver = new InstanceResolver(new ZeroParameterClass());
            containerResolver.AddInstanceResolver(typeof(ZeroParameterClass), instanceResolver);
            var instance = containerResolver.Resolve(typeof(ZeroParameterClass));
            Assert.IsInstanceOf<ZeroParameterClass>(instance);
        }

        [Test]
        public void Resolve_SingletonMultipleTimes_ShouldReturnSameInstances()
        {
            var containerResolver = new ContainerResolver(Container.Root);
            var disposableCollection = new MockDisposableCollection();
            var objectResolver = new ObjectResolver(typeof(ZeroParameterClass), containerResolver, disposableCollection);
            var instanceResolver = new SingletonResolver(objectResolver);
            containerResolver.AddInstanceResolver(typeof(IZeroParameterClass), instanceResolver);
            var instance1 = containerResolver.Resolve(typeof(IZeroParameterClass));
            var instance2 = containerResolver.Resolve(typeof(IZeroParameterClass));
            Assert.AreSame(instance1, instance2);
        }

        [Test]
        public void Resolve_SingletonWithZeroParameterClassWithRegistrationType_ShouldReturnInstanceOfRegistrationType()
        {
            var containerResolver = new ContainerResolver(Container.Root);
            var disposableCollection = new MockDisposableCollection();
            var objectResolver = new ObjectResolver(typeof(ZeroParameterClass), containerResolver, disposableCollection);
            var instanceResolver = new SingletonResolver(objectResolver);
            containerResolver.AddInstanceResolver(typeof(IZeroParameterClass), instanceResolver);
            var instance = containerResolver.Resolve(typeof(IZeroParameterClass));
            Assert.IsInstanceOf<IZeroParameterClass>(instance);
        }

        [Test]
        public void Resolve_SingletonWithZeroParameterClassWithImplementationType_ShouldReturnInstanceOfImplementationType()
        {
            var containerResolver = new ContainerResolver(Container.Root);
            var disposableCollection = new MockDisposableCollection();
            var objectResolver = new ObjectResolver(typeof(ZeroParameterClass), containerResolver, disposableCollection);
            var instanceResolver = new SingletonResolver(objectResolver);
            containerResolver.AddInstanceResolver(typeof(ZeroParameterClass), instanceResolver);
            var instance = containerResolver.Resolve(typeof(ZeroParameterClass));
            Assert.IsInstanceOf<ZeroParameterClass>(instance);
        }

        [Test]
        public void Resolve_SingletonWithOneParameterClassWithRegistrationType_ShouldParameterReturnInstanceOfParameterType()
        {
            var containerResolver = new ContainerResolver(Container.Root);
            var disposableCollection = new MockDisposableCollection();
            var zeroParameterClassResolver = new ObjectResolver(typeof(ZeroParameterClass), containerResolver, disposableCollection);
            var oneParameterClassResolver = new ObjectResolver(typeof(OneParameterClass), containerResolver, disposableCollection);
            containerResolver.AddInstanceResolver(typeof(IZeroParameterClass), new SingletonResolver(zeroParameterClassResolver));
            containerResolver.AddInstanceResolver(typeof(IOneParameterClass), new SingletonResolver(oneParameterClassResolver));
            var instance = (OneParameterClass)containerResolver.Resolve(typeof(IOneParameterClass));
            var parameterInstance = instance.GetZeroParameterClass();
            Assert.IsInstanceOf<IZeroParameterClass>(parameterInstance);
        }

        [Test]
        public void Resolve_TransientMultipleTimes_ShouldReturnDifferentInstances()
        {
            var containerResolver = new ContainerResolver(Container.Root);
            var disposableCollection = new MockDisposableCollection();
            var zeroParameterClassResolver = new ObjectResolver(typeof(ZeroParameterClass), containerResolver, disposableCollection);
            containerResolver.AddInstanceResolver(typeof(IZeroParameterClass), new TransientResolver(zeroParameterClassResolver));
            var instance1 = containerResolver.Resolve(typeof(IZeroParameterClass));
            var instance2 = containerResolver.Resolve(typeof(IZeroParameterClass));
            Assert.AreNotSame(instance1, instance2);
        }
    }
}
