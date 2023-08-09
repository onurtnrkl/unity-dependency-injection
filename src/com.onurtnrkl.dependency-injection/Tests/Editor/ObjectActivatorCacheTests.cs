using DependencyInjection.Caching;
using DependencyInjection.EditorTests.Fakes;
using NUnit.Framework;

namespace DependencyInjection.EditorTests
{
    internal sealed class ObjectActivatorCacheTests
    {
        [TearDown]
        public void TearDown()
        {
            ObjectActivatorCache.Clear();
        }

        [Test]
        public void GetOrCreateObjectActivator_MultipleTimesWithSameImplementationType_ShouldReturnSameObjectActivator()
        {
            var activator1 = ObjectActivatorCache.GetOrCreateObjectActivator(typeof(ZeroParameterClass));
            var activator2 = ObjectActivatorCache.GetOrCreateObjectActivator(typeof(ZeroParameterClass));
            Assert.AreSame(activator1, activator2);
        }
    }
}
