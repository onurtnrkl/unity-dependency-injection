using System;
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

            if (!ObjectActivatorCache.TryGet(implementationType, out var objectActivator))
            {
                if (!TryCreateObjectActivator(implementationType, out objectActivator))
                {
                    return;
                }

                ObjectActivatorCache.Add(implementationType, objectActivator);
            }

            MethodBaseInjector.Inject(uninitializedObject, objectActivator, containerResolver);
        }

        private static bool TryCreateObjectActivator(Type implementationType, out IObjectActivator objectActivator)
        {
            if (!TryFindMethodInfo(implementationType, out var constructorInfo))
            {
                objectActivator = null;
                return false;
            }

            objectActivator = new MethodBaseActivator(constructorInfo);
            return true;
        }

        private static bool TryFindMethodInfo(Type implementationType, out MethodInfo foundMethodInfo)
        {
            foundMethodInfo = default;
            var methodInfos = implementationType.GetMethods(MethodBindingFlags);
            var foundParametersCount = int.MinValue;

            foreach (var methodInfo in methodInfos)
            {
                if (!methodInfo.IsDefined(typeof(InjectAttribute))) continue;

                var parametersCount = methodInfo.GetParameters().Length;

                if (foundParametersCount > parametersCount) continue;

                foundMethodInfo = methodInfo;
                foundParametersCount = parametersCount;
            }

            return foundMethodInfo != default;
        }
    }
}
