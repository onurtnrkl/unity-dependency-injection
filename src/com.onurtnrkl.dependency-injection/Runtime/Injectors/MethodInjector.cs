﻿using System;
using System.Reflection;
using DependencyInjection.Activators;
using DependencyInjection.Attributes;
using DependencyInjection.Caching;
using DependencyInjection.Resolution;

namespace DependencyInjection.Injectors
{
    internal static class MethodInjector
    {
        private const BindingFlags MethodBindingFlags = BindingFlags.Public | BindingFlags.Instance;

        public static void Inject(object uninitializedObject, IContainerResolver containerResolver)
        {
            var implementationType = uninitializedObject.GetType();
            var objectActivator = GetOrCreateObjectActivator(implementationType);
            MethodBaseInjector.Inject(uninitializedObject, objectActivator, containerResolver);
        }

        private static IObjectActivator GetOrCreateObjectActivator(Type implementationType)
        {
            if (!ObjectActivatorCache.TryGet(implementationType, out var objectActivator))
            {
                var methodInfo = FindMethodInfo(implementationType);
                objectActivator = new MethodBaseActivator(methodInfo);
                ObjectActivatorCache.Add(implementationType, objectActivator);
            }

            return objectActivator;
        }

        private static MethodInfo FindMethodInfo(Type implementationType)
        {
            var methodInfos = implementationType.GetMethods(MethodBindingFlags);
            var foundMethodInfo = default(MethodInfo);
            var foundParametersCount = int.MinValue;

            foreach (var methodInfo in methodInfos)
            {
                if (!methodInfo.IsDefined(typeof(InjectAttribute))) continue;

                var parametersCount = methodInfo.GetParameters().Length;

                if (foundParametersCount > parametersCount) continue;

                foundMethodInfo = methodInfo;
                foundParametersCount = parametersCount;
            }

            return foundMethodInfo;
        }
    }
}
