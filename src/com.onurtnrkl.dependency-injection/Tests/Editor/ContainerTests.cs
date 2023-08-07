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
    }
}
