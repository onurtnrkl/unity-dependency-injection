using DependencyInjection.Activators;
using DependencyInjection.Pool;
using NUnit.Framework;

namespace DependencyInjection.EditorTests
{
    internal abstract class TestsBase
    {
        [SetUp]
        public void Setup()
        {
            ObjectActivatorCache.Clear();
            FixedSizeArrayPool<object>.Clear();
        }

        [TearDown]
        public void TearDown()
        {
            ObjectActivatorCache.Clear();
            FixedSizeArrayPool<object>.Clear();
        }
    }
}
