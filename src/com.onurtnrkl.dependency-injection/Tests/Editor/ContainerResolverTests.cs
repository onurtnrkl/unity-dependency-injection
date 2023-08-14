using DependencyInjection.EditorTests.Fakes;
using DependencyInjection.Resolution;
using NUnit.Framework;

namespace DependencyInjection.EditorTests
{
    internal sealed class ContainerResolverTests : TestsBase
    {
        [Test]
        public void Resolve_InstanceWithZeroParameterClassInstanceWithRegistrationType_ShouldReturnInstanceOfRegistrationType()
        {
            var containerResolver = new ContainerResolver();
            var objectResolver = new InstanceResolver(new ZeroParameterClass());
            containerResolver.AddObjectResolver(typeof(IZeroParameterClass), objectResolver);
            var instance = containerResolver.Resolve(typeof(IZeroParameterClass));
            Assert.IsInstanceOf<IZeroParameterClass>(instance);
        }

        [Test]
        public void Resolve_InstanceWithZeroParameterClassInstanceWithImplementationType_ShouldReturnInstanceOfImplementationType()
        {
            var containerResolver = new ContainerResolver();
            var objectResolver = new InstanceResolver(new ZeroParameterClass());
            containerResolver.AddObjectResolver(typeof(ZeroParameterClass), objectResolver);
            var instance = containerResolver.Resolve(typeof(ZeroParameterClass));
            Assert.IsInstanceOf<ZeroParameterClass>(instance);
        }

        [Test]
        public void Resolve_SingletonMultipleTimes_ShouldReturnSameInstances()
        {
            var containerResolver = new ContainerResolver();
            var objectResolver = new SingletonResolver(typeof(ZeroParameterClass), containerResolver);
            containerResolver.AddObjectResolver(typeof(IZeroParameterClass), objectResolver);
            var instance1 = containerResolver.Resolve(typeof(IZeroParameterClass));
            var instance2 = containerResolver.Resolve(typeof(IZeroParameterClass));
            Assert.AreSame(instance1, instance2);
        }

        [Test]
        public void Resolve_SingletonWithZeroParameterClassWithRegistrationType_ShouldReturnInstanceOfRegistrationType()
        {
            var containerResolver = new ContainerResolver();
            var objectResolver = new SingletonResolver(typeof(ZeroParameterClass), containerResolver);
            containerResolver.AddObjectResolver(typeof(IZeroParameterClass), objectResolver);
            var instance = containerResolver.Resolve(typeof(IZeroParameterClass));
            Assert.IsInstanceOf<IZeroParameterClass>(instance);
        }

        [Test]
        public void Resolve_SingletonWithZeroParameterClassWithImplementationType_ShouldReturnInstanceOfImplementationType()
        {
            var containerResolver = new ContainerResolver();
            var objectResolver = new SingletonResolver(typeof(ZeroParameterClass), containerResolver);
            containerResolver.AddObjectResolver(typeof(ZeroParameterClass), objectResolver);
            var instance = containerResolver.Resolve(typeof(ZeroParameterClass));
            Assert.IsInstanceOf<ZeroParameterClass>(instance);
        }

        [Test]
        public void Resolve_SingletonWithOneParameterClassWithRegistrationType_ShouldParameterReturnInstanceOfParameterType()
        {
            var containerResolver = new ContainerResolver();
            var zeroParameterClassResolver = new SingletonResolver(typeof(ZeroParameterClass), containerResolver);
            var oneParameterClassResolver = new SingletonResolver(typeof(OneParameterClass), containerResolver);
            containerResolver.AddObjectResolver(typeof(IZeroParameterClass), zeroParameterClassResolver);
            containerResolver.AddObjectResolver(typeof(IOneParameterClass), oneParameterClassResolver);
            var instance = (OneParameterClass)containerResolver.Resolve(typeof(IOneParameterClass));
            var parameterInstance = instance.GetZeroParameterClass();
            Assert.IsInstanceOf<IZeroParameterClass>(parameterInstance);
        }

        [Test]
        public void Resolve_TransientMultipleTimes_ShouldReturnDifferentInstances()
        {
            var containerResolver = new ContainerResolver();
            var zeroParameterClassResolver = new TransientResolver(typeof(ZeroParameterClass), containerResolver);
            containerResolver.AddObjectResolver(typeof(IZeroParameterClass), zeroParameterClassResolver);
            var instance1 = containerResolver.Resolve(typeof(IZeroParameterClass));
            var instance2 = containerResolver.Resolve(typeof(IZeroParameterClass));
            Assert.AreNotSame(instance1, instance2);
        }
    }
}
