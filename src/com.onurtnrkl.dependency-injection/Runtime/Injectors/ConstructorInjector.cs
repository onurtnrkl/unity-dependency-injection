using System;
using System.Reflection;
using DependencyInjection.Activators;
using DependencyInjection.Caching;
using DependencyInjection.Resolution;

namespace DependencyInjection.Injectors
{
    internal static class ConstructorInjector
    {
        private const BindingFlags CostructorBindingFlags = BindingFlags.Public | BindingFlags.Instance;

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
                var constructorInfo = FindConstructorInfo(implementationType);
                objectActivator = new MethodBaseActivator(constructorInfo);
                ObjectActivatorCache.Add(implementationType, objectActivator);
            }

            return objectActivator;
        }

        private static ConstructorInfo FindConstructorInfo(Type implementationType)
        {
            var constructorInfos = implementationType.GetConstructors(CostructorBindingFlags);
            var foundConstructorInfo = default(ConstructorInfo);
            var foundParametersCount = int.MinValue;

            foreach (var constructorInfo in constructorInfos)
            {
                var parametersCount = constructorInfo.GetParameters().Length;

                if (foundParametersCount > parametersCount) continue;

                foundConstructorInfo = constructorInfo;
                foundParametersCount = parametersCount;
            }

            return foundConstructorInfo;
        }
    }
}
