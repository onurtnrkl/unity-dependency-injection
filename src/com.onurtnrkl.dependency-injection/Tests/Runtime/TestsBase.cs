using DependencyInjection.Activators;
using DependencyInjection.Core;
using DependencyInjection.Pool;
using NUnit.Framework;

namespace DependencyInjection.Tests
{
    internal abstract class TestsBase
    {
        [SetUp]
        public void Setup()
        {
            ObjectActivatorCache.Clear();
            FixedSizeArrayPool<object>.Clear();
            SceneContainerCollection.Clear();
        }

        [TearDown]
        public void TearDown()
        {
            ObjectActivatorCache.Clear();
            FixedSizeArrayPool<object>.Clear();
            SceneContainerCollection.Clear();
        }
    }
}