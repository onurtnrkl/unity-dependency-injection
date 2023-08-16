using DependencyInjection.Core;
using DependencyInjection.EditorTests.Fakes;
using NUnit.Framework;

namespace DependencyInjection.EditorTests
{
    internal sealed class ContainerTests : TestsBase
    {
        [Test]
        public void Dispose_ParentContainer_ChildContainerResolverShouldReturnNull()
        {
            var parentBuilder = new ContainerBuilder(Container.Root);
            parentBuilder.AddSingleton(typeof(ZeroParameterClass));
            var parentContainer = parentBuilder.Build();
            var childBuilder = new ContainerBuilder(parentContainer);
            childBuilder.AddSingleton(typeof(OneParameterClass));
            var childContainer = childBuilder.Build();
            var childOfChildBuilder = new ContainerBuilder(childContainer);
            childOfChildBuilder.AddSingleton(typeof(ClassWithInjectableMethod));
            var childOfChildContainer = childOfChildBuilder.Build();
            parentContainer.Dispose();

            Assert.IsNull(childOfChildContainer.Resolve(typeof(ClassWithInjectableMethod)));
        }

        [Test]
        public void Dispose_Container_ResolvedDisposableShouldBeDisposed()
        {
            var containerBuilder = new ContainerBuilder(Container.Root);
            containerBuilder.AddSingleton(typeof(IDisposableClass), typeof(DisposableClass));
            var container = containerBuilder.Build();
            var disposableInstance = (IDisposableClass)container.Resolve(typeof(IDisposableClass));
            container.Dispose();

            Assert.IsTrue(disposableInstance.Disposed);
        }

        [Test]
        public void Dispose_ParentContainer_ResolvedChildDisposableShouldBeDisposed()
        {
            var parentBuilder = new ContainerBuilder(Container.Root);
            parentBuilder.AddSingleton(typeof(ZeroParameterClass));
            var parentContainer = parentBuilder.Build();
            var childBuilder = new ContainerBuilder(parentContainer);
            childBuilder.AddSingleton(typeof(IDisposableClass), typeof(DisposableClass));
            var childContainer = childBuilder.Build();
            var disposableInstance = (IDisposableClass)childContainer.Resolve(typeof(IDisposableClass));
            parentContainer.Dispose();

            Assert.IsTrue(disposableInstance.Disposed);
        }

        [Test]
        public void Resolve_ParentImplementationFromChild_ChildContainerResolverShouldReturnInstanceOfParentImplementation()
        {
            var parentBuilder = new ContainerBuilder(Container.Root);
            var zeroParameterClass = new ZeroParameterClass();
            parentBuilder.AddInstance(zeroParameterClass);
            var parentContainer = parentBuilder.Build();
            var childBuilder = new ContainerBuilder(parentContainer);
            var childContainer = childBuilder.Build();
            var expected = zeroParameterClass;
            var actual = childContainer.Resolve(typeof(ZeroParameterClass));

            Assert.AreSame(expected, actual);
        }
    }
}
