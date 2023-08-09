﻿using System.Collections.Generic;
using System;
using DependencyInjection.Activators;

namespace DependencyInjection.Caching
{
    internal static class ObjectActivatorCache
    {
        private readonly static Dictionary<Type, IObjectActivator> s_objectActivatorsByImplementationTypes = new();

        public static bool TryGet(Type implementationType, out IObjectActivator objectActivator)
        {
            return s_objectActivatorsByImplementationTypes.TryGetValue(implementationType, out objectActivator);
        }

        public static void Add(Type implementationType, IObjectActivator objectActivator)
        {
            s_objectActivatorsByImplementationTypes.Add(implementationType, objectActivator);
        }

        public static void Clear()
        {
            s_objectActivatorsByImplementationTypes.Clear();
        }
    }
}
