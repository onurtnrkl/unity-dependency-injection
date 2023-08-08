using DependencyInjection.EditorTests.Fakes;
using DependencyInjection.Resolution;
using NUnit.Framework;

namespace DependencyInjection.EditorTests
{
    internal sealed class RootResolverTests
    {
        [Test]
        public void GetOrCreateObjectActivator_MultipleTimesWithSameImplementationType_ShouldReturnSameObjectActivator()
        {
            var rootResolver = new RootResolver();
            var activator1 = rootResolver.GetOrCreateObjectActivator(typeof(ZeroParameterClass));
            var activator2 = rootResolver.GetOrCreateObjectActivator(typeof(ZeroParameterClass));
            Assert.AreSame(activator1, activator2);
        }
    }
}
