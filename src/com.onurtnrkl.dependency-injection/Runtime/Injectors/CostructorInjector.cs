using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using DependencyInjection.Activators;
using DependencyInjection.Caching;
using DependencyInjection.Resolution;

namespace DependencyInjection.Injectors
{
    internal static class CostructorInjector
    {
        private const BindingFlags CostructorBindingFlags = BindingFlags.Public | BindingFlags.Instance;

        public static object Inject(Type implementationType, IRootResolver rootResolver)
        {
            var uninitializedObject = RuntimeHelpers.GetUninitializedObject(implementationType);
            var objectActivator = GetOrCreateObjectActivator(implementationType);

            return MethodBaseInjector.Inject(uninitializedObject, objectActivator, rootResolver);
        }

        private static IObjectActivator GetOrCreateObjectActivator(Type implementationType)
        {
            if (!ObjectActivatorCache.TryGet(implementationType, out var objectActivator))
            {
                var constructorInfo = FindCostructorInfo(implementationType);
                objectActivator = new MethodBaseActivator(constructorInfo);
                ObjectActivatorCache.Add(implementationType, objectActivator);
            }

            return objectActivator;
        }

        private static ConstructorInfo FindCostructorInfo(Type implementationType)
        {
            var constructorInfos = implementationType.GetConstructors(CostructorBindingFlags);
            var foundConstructorInfo = constructorInfos[0];
            var foundParametersCount = constructorInfos[0].GetParameters().Length;

            for (var i = 1; i < constructorInfos.Length; i++)
            {
                var constructorInfo = constructorInfos[i];
                var parametersCount = constructorInfo.GetParameters().Length;

                if (foundParametersCount > parametersCount) continue;

                foundConstructorInfo = constructorInfo;
                foundParametersCount = parametersCount;
            }

            return foundConstructorInfo;
        }
    }
}
