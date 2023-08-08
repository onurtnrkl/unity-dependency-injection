using System;
using System.Collections;
using System.Reflection;

namespace DependencyInjection.Caching
{
    internal sealed class InjectionInfo
    {
        public Action<object, object[]> Activator { get; }
        public Type[] ParameterTypes { get; }

        private InjectionInfo(Action<object, object[]> activator, Type[] parameterTypes)
        {
            Activator = activator;
            ParameterTypes = parameterTypes;
        }

        public static InjectionInfo FromMethodBase(MethodBase methodBase)
        {
            var parameterInfos = methodBase.GetParameters();
            var parameterTypes = Array.ConvertAll(parameterInfos, (parameterInfo) => parameterInfo.ParameterType);

            void Activator(object obj, object[] parameters)
            {
                methodBase.Invoke(obj, parameters);
            }

            return new InjectionInfo(Activator, parameterTypes);
        }
    }
}
