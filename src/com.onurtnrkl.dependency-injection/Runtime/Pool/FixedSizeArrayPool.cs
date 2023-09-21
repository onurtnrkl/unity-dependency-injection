using System;
using System.Collections.Generic;
using UnityEngine.Pool;

namespace DependencyInjection.Pool
{
    internal class FixedSizeArrayPool<T>
    {
        private static readonly Dictionary<int, IObjectPool<T[]>> s_poolsBySizes = new();

        public static T[] Get(int size)
        {
            var pool = GetOrCreatePool(size);
            return pool.Get();
        }

        public static IDisposable Get(int size, out T[] array)
        {
            var pool = GetOrCreatePool(size);
            return pool.Get(out array);
        }

        public static void Release(T[] array)
        {
            var size = array.Length;
            var pool = GetOrCreatePool(size);
            pool.Release(array);
        }

        public static void Clear()
        {
            foreach (var pool in s_poolsBySizes.Values)
            {
                pool.Clear();
            }

            s_poolsBySizes.Clear();
        }

        private static IObjectPool<T[]> GetOrCreatePool(int size)
        {
            if (!s_poolsBySizes.TryGetValue(size, out var pool))
            {
                pool = new LinkedPool<T[]>(() => new T[size], null, (T[] array) => Array.Clear(array, 0, size));
                s_poolsBySizes.Add(size, pool);
            }

            return pool;
        }
    }
}
