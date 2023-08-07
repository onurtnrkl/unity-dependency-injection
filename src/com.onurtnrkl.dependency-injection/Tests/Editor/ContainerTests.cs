using DependencyInjection.Core;
using DependencyInjection.EditorTests.Fakes;
using NUnit.Framework;

namespace DependencyInjection.EditorTests
{
    internal partial class ContainerTests
    {

        [Test]
        public void Resolve_InstanceOfZeroParameterClassWithRegistrationType_ShouldReturnInstanceOfImplementation()
        {
            var container = new Container();
            container.AddInstance<IZeroParameterClass, ZeroParameterClass>(new ZeroParameterClass());
            var instance = container.Resolve(typeof(IZeroParameterClass));
            Assert.IsInstanceOf<IZeroParameterClass>(instance);
        }

        [Test]
        public void Resolve_SingletonOfZeroParameterClassWithRegistrationType_ShouldReturnInstanceOfImplementation()
        {
            var container = new Container();
            container.AddSingleton<IZeroParameterClass, ZeroParameterClass>();
            var instance = container.Resolve(typeof(IZeroParameterClass));
            Assert.IsInstanceOf<IZeroParameterClass>(instance);
        }
    }
}
