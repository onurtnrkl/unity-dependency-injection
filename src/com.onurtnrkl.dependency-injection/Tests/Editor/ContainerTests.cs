using DependencyInjection.Core;
using DependencyInjection.EditorTests.Fakes;
using NUnit.Framework;

namespace DependencyInjection.EditorTests
{
    internal partial class ContainerTests
    {
        [Test]
        public void Resolve_InstanceOfZeroParameterClassWithRegistrationType_ShouldReturnInstanceOfRegistrationType()
        {
            var container = new Container();
            container.AddInstance(typeof(IZeroParameterClass), new ZeroParameterClass());
            var instance = container.Resolve(typeof(IZeroParameterClass));
            Assert.IsInstanceOf<IZeroParameterClass>(instance);
        }

        [Test]
        public void Resolve_InstanceOfZeroParameterClassWithImplementationType_ShouldReturnInstanceOfImplementationType()
        {
            var container = new Container();
            container.AddInstance(new ZeroParameterClass());
            var instance = container.Resolve(typeof(ZeroParameterClass));
            Assert.IsInstanceOf<ZeroParameterClass>(instance);
        }

        [Test]
        public void Resolve_SingletonMultipleTimes_ShouldReturnSameInstances()
        {
            var container = new Container();
            container.AddSingleton(typeof(IZeroParameterClass), typeof(ZeroParameterClass));
            var instance1 = container.Resolve(typeof(IZeroParameterClass));
            var instance2 = container.Resolve(typeof(IZeroParameterClass));
            Assert.That(instance1, Is.EqualTo(instance2));
        }

        [Test]
        public void Resolve_SingletonOfZeroParameterClassWithRegistrationType_ShouldReturnInstanceOfRegistrationType()
        {
            var container = new Container();
            container.AddSingleton(typeof(IZeroParameterClass), typeof(ZeroParameterClass));
            var instance = container.Resolve(typeof(IZeroParameterClass));
            Assert.IsInstanceOf<IZeroParameterClass>(instance);
        }

        [Test]
        public void Resolve_SingletonOfZeroParameterClassWithImplementationType_ShouldReturnInstanceOfImplementationType()
        {
            var container = new Container();
            container.AddSingleton(typeof(ZeroParameterClass));
            var instance = container.Resolve(typeof(ZeroParameterClass));
            Assert.IsInstanceOf<ZeroParameterClass>(instance);
        }

        [Test]
        public void Resolve_SingletonOfOneParameterClassWithRegistrationType_ShouldParameterReturnInstanceOfParameterType()
        {
            var container = new Container();
            container.AddSingleton(typeof(IZeroParameterClass), typeof(ZeroParameterClass));
            container.AddSingleton(typeof(IOneParameterClass), typeof(OneParameterClass));
            var instance = (OneParameterClass)container.Resolve(typeof(IOneParameterClass));
            var parameterInstance = instance.GetZeroParameterClass();
            Assert.IsInstanceOf<IZeroParameterClass>(parameterInstance);
        }

        [Test]
        public void Resolve_TransientMultipleTimes_ShouldReturnDifferentInstances()
        {
            var container = new Container();
            container.AddTransient(typeof(IZeroParameterClass), typeof(ZeroParameterClass));
            var instance1 = container.Resolve(typeof(IZeroParameterClass));
            var instance2 = container.Resolve(typeof(IZeroParameterClass));
            Assert.That(instance1, Is.Not.EqualTo(instance2));
        }
    }
}
