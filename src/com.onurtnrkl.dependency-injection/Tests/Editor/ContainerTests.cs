using DependencyInjection.Core;
using DependencyInjection.EditorTests.Fakes;
using NUnit.Framework;

namespace DependencyInjection.EditorTests
{
    internal sealed class ContainerTests : TestsBase
    {
        [Test]
        public void Dispose_ParentContainer_ChildContainerShouldBeNull()
        {
            var parentBuilder = new ContainerBuilder(Container.Null);
            parentBuilder.AddSingleton(typeof(ZeroParameterClass));
            parentBuilder.AddSingleton(typeof(OneParameterClass));
            var childContainer = default(IContainer);

            using (var parentContainer = parentBuilder.Build())
            {
                var childBuilder = new ContainerBuilder(parentContainer);
                childBuilder.AddSingleton(typeof(ZeroParameterClass));
                childBuilder.AddSingleton(typeof(OneParameterClass));

                using (childContainer = childBuilder.Build())
                {

                }
            }

            Assert.IsNull(childContainer);
        }
    }
}
