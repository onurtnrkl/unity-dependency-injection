using DependencyInjection.Caching;
using DependencyInjection.EditorTests.Fakes;
using DependencyInjection.Injectors;
using DependencyInjection.Resolution;
using NUnit.Framework;

namespace DependencyInjection.EditorTests
{
    [TestFixture]
    internal sealed class MethodInjectorTests
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
        public void Inject_ClassWithInjectableMethod_ShouldReturnSameInstanceOfParameter()
        {
            var rootResolver = new RootResolver();
            var zeroParameterClass = new ZeroParameterClass();
            var objectResolver = new InstanceResolver(zeroParameterClass);
            rootResolver.AddObjectResolver(typeof(IZeroParameterClass), objectResolver);
            var classWithInjectableMethod = new ClassWithInjectableMethod();
            MethodInjector.Inject(classWithInjectableMethod, rootResolver);
            var actual = classWithInjectableMethod.GetZeroParameterClass();
            var expected = zeroParameterClass;
            Assert.AreEqual(actual, expected);
        }
    }
}
