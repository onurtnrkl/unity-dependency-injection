using DependencyInjection.Activators;
using DependencyInjection.Pool;
using DependencyInjection.Resolution;

namespace DependencyInjection.Injectors
{
    internal static class MethodBaseInjector
    {
        public static void Inject(object uninitializedObject, IObjectActivator objectActivator, IContainerResolver containerResolver)
        {
            var parameterTypes = objectActivator.ParameterTypes;
            var parameterTypesLength = parameterTypes.Length;

            using (FixedSizeArrayPool<object>.Get(parameterTypesLength, out var parameters))
            {
                for (var i = 0; i < parameterTypesLength; i++)
                {
                    var parameterType = parameterTypes[i];
                    parameters[i] = containerResolver.Resolve(parameterType);
                }

                objectActivator.Activate(uninitializedObject, parameters);
            }
        }
    }
}
