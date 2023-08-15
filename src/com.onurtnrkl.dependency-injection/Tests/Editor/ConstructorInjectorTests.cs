using System.Runtime.CompilerServices;
using DependencyInjection.Core;
using DependencyInjection.EditorTests.Fakes;
using DependencyInjection.Injectors;
using DependencyInjection.Resolution;
using NUnit.Framework;

namespace DependencyInjection.EditorTests
{
    internal sealed class ConstructorInjectorTests : TestsBase
    {
        [Test]
        public void Inject_OneParameterClassWithConstructor_ShouldReturnSameInstanceOfParameter()
        {
            var containerResolver = new ContainerResolver(Container.Empty);
            var zeroParameterClass = new ZeroParameterClass();
            var objectResolver = new InstanceResolver(zeroParameterClass);
            containerResolver.AddObjectResolver(typeof(IZeroParameterClass), objectResolver);
            var oneParameterClass = (OneParameterClass)RuntimeHelpers.GetUninitializedObject(typeof(OneParameterClass));
            ConstructorInjector.Inject(oneParameterClass, containerResolver);
            var actual = oneParameterClass.GetZeroParameterClass();
            var expected = zeroParameterClass;
            Assert.AreEqual(expected, actual);
        }
    }
}
