using System.Runtime.CompilerServices;
using System;
using System.Reflection;

namespace DependencyInjection.Core
{
    internal sealed class SingletonResolver : IResolver
    {
        private readonly Type _implementationType;
        private readonly IRootResolver _rootResolver;
        private object _implementation;

        public SingletonResolver(Type implementationType, IRootResolver rootResolver)
        {
            _implementationType = implementationType;
            _rootResolver = rootResolver;
        }

        public object Resolve()
        {
            if (_implementation == null)
            {
                var constructor = _implementationType.GetConstructors(BindingFlags.Public | BindingFlags.Instance)[0];
                var parameterInfos = constructor.GetParameters();
                var parameters = new object[parameterInfos.Length];

                for (var i = 0; i < parameterInfos.Length; i++)
                {
                    var parameterInfo = parameterInfos[i];
                    parameters[i] = _rootResolver.Resolve(parameterInfo.ParameterType);
                }

                _implementation = RuntimeHelpers.GetUninitializedObject(_implementationType);
                constructor.Invoke(_implementation, parameters);
            }

            return _implementation;
        }
    }
}
