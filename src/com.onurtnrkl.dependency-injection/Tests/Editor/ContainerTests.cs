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
            var parentBuilder = new ContainerBuilder(Container.Null);
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
    }
}
