using System.Runtime.CompilerServices;
using System;
using System.Reflection;

namespace DependencyInjection.Core
{
    internal sealed class SingletonResolver : IResolver
    {
        private readonly Type _implementationType;
        private object _implementation;

        public SingletonResolver(Type implementationType)
        {
            _implementationType = implementationType;
        }

        public object Resolve()
        {
            if (_implementation == null)
            {
                var constructor = _implementationType.GetConstructors(BindingFlags.Public | BindingFlags.Instance)[0];
                _implementation = RuntimeHelpers.GetUninitializedObject(_implementationType);
                constructor.Invoke(_implementation, null);
            }

            return _implementation;
        }
    }
}
