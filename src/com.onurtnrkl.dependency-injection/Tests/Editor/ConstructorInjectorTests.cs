using System.Runtime.CompilerServices;
using DependencyInjection.Caching;
using DependencyInjection.EditorTests.Fakes;
using DependencyInjection.Injectors;
using DependencyInjection.Resolution;
using NUnit.Framework;

namespace DependencyInjection.EditorTests
{
    [TestFixture]
    internal sealed class ConstructorInjectorTests
    {
        [SetUp]
        public void Setup()
        {
            ObjectActivatorCache.Clear();
        }

        [TearDown]
        public void TearDown()
        {
            ObjectActivatorCache.Clear();
        }

        [Test]
        public void Inject_OneParameterClassWithConstructor_ShouldReturnSameInstanceOfParameter()
        {
            var contaienrResolver = new ContainerResolver();
            var zeroParameterClass = new ZeroParameterClass();
            var objectResolver = new InstanceResolver(zeroParameterClass);
            contaienrResolver.AddObjectResolver(typeof(IZeroParameterClass), objectResolver);
            var oneParameterClass = (OneParameterClass)RuntimeHelpers.GetUninitializedObject(typeof(OneParameterClass));
            ConstructorInjector.Inject(oneParameterClass, contaienrResolver);
            var actual = oneParameterClass.GetZeroParameterClass();
            var expected = zeroParameterClass;
            Assert.AreEqual(actual, expected);
        }
    }
}
