using DependencyInjection.Activators;
using DependencyInjection.EditorTests.Fakes;
using DependencyInjection.EditorTests.Mocks;
using NUnit.Framework;

namespace DependencyInjection.EditorTests
{
    [TestFixture]
    internal sealed class ObjectActivatorCacheTests : TestsBase
    {
        [Test]
        public void TryGet_NotCachedItem_ShouldReturnFalse()
        {
            var actual = ObjectActivatorCache.TryGet(typeof(ZeroParameterClass), out var objectActivator);
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TryGet_CachedItem_ShouldReturnObjectActivator()
        {
            var objectActivator = new MockObjectActivator();
            ObjectActivatorCache.Add(typeof(ZeroParameterClass), objectActivator);
            ObjectActivatorCache.TryGet(typeof(ZeroParameterClass), out var cachedObjectActivator);
            Assert.AreSame(objectActivator, cachedObjectActivator);
        }

        [Test]
        public void TryGet_MultipleTimesWithSameImplementationType_ShouldReturnSameObjectActivator()
        {
            var objectActivator = new MockObjectActivator();
            ObjectActivatorCache.Add(typeof(ZeroParameterClass), objectActivator);
            ObjectActivatorCache.TryGet(typeof(ZeroParameterClass), out var activator1);
            ObjectActivatorCache.TryGet(typeof(ZeroParameterClass), out var activator2);
            Assert.AreSame(activator1, activator2);
        }
    }
}
