﻿using DependencyInjection.Core;
using DependencyInjection.EditorTests.Fakes;
using DependencyInjection.Injectors;
using DependencyInjection.Resolution;
using NUnit.Framework;

namespace DependencyInjection.EditorTests
{
    internal sealed class MethodInjectorTests : TestsBase
    {
        [Test]
        public void Inject_ClassWithInjectableMethod_ShouldReturnSameInstanceOfParameter()
        {
            var containerResolver = new ContainerResolver(Container.Root);
            var zeroParameterClass = new ZeroParameterClass();
            var objectResolver = new InstanceResolver(zeroParameterClass);
            containerResolver.AddInstanceResolver(typeof(IZeroParameterClass), objectResolver);
            var classWithInjectableMethod = new ClassWithInjectableMethod();
            MethodInjector.Inject(classWithInjectableMethod, containerResolver);
            var actual = classWithInjectableMethod.GetZeroParameterClass();
            var expected = zeroParameterClass;
            Assert.AreEqual(expected, actual);
        }
    }
}
