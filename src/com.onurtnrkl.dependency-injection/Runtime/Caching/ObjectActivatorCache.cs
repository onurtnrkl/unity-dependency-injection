using System.Collections.Generic;
using System;
using DependencyInjection.Activators;
using System.Reflection;

namespace DependencyInjection.Caching
{
    internal static class ObjectActivatorCache
    {
        private readonly static Dictionary<Type, IObjectActivator> s_objectActivatorsByImplementationTypes = new();

        public static IObjectActivator GetOrCreateObjectActivator(Type implementationType)
        {
            if (!s_objectActivatorsByImplementationTypes.TryGetValue(implementationType, out var objectActivator))
            {
                var constructor = implementationType.GetConstructors(BindingFlags.Public | BindingFlags.Instance)[0];
                objectActivator = new MethodBaseActivator(constructor);
                s_objectActivatorsByImplementationTypes.Add(implementationType, objectActivator);
            }

            return objectActivator;
        }

        public static void Clear()
        {
            s_objectActivatorsByImplementationTypes.Clear();
        }
    }
}
