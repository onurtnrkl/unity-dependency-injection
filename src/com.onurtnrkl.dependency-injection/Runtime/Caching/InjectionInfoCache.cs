using System;
using System.Collections.Generic;

namespace DependencyInjection.Caching
{
    internal sealed class InjectionInfoCache
    {
        private readonly IDictionary<Type, InjectionInfo> _injectionInfosByImplementationTypes;

        public InjectionInfoCache()
        {
            _injectionInfosByImplementationTypes = new Dictionary<Type, InjectionInfo>();
        }

        public void Add(Type implementationType, InjectionInfo injectionInfo)
        {
            _injectionInfosByImplementationTypes.Add(implementationType, injectionInfo);
        }

        public InjectionInfo Get(Type type)
        {
            return _injectionInfosByImplementationTypes[type];
        }
    }
}
