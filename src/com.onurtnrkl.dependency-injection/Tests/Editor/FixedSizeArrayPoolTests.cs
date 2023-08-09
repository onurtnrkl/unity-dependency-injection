using DependencyInjection.Pool;
using NUnit.Framework;

namespace DependencyInjection.EditorTests
{
    internal sealed class FixedSizeArrayPoolTests
    {
        [Test]
        public void Get_WithReferenceType_ShouldBeEmptyAfterUsingScope()
        {
            object[] array;

            using (FixedSizeArrayPool<object>.Get(2, out var tempArray))
            {
                array = tempArray;
            }

            var expected = new object[2];
            Assert.AreEqual(array, expected);
        }

        [Test]
        public void Release_ItemMultipleTimes_ShouldReturnFixedSizeOfArray()
        {
            var array1 = FixedSizeArrayPool<object>.Get(1);
            FixedSizeArrayPool<object>.Release(array1);
            var array2 = FixedSizeArrayPool<object>.Get(2);
            FixedSizeArrayPool<object>.Release(array2);
            var array3 = FixedSizeArrayPool<object>.Get(3);
            FixedSizeArrayPool<object>.Release(array3);

            var actual = FixedSizeArrayPool<object>.Get(2).Length;
            var expected = 2;
            Assert.AreEqual(actual, expected);
        }
    }
}
