using System;

namespace DependencyInjection.Resolution
{
    internal interface IDisposableCollection : IDisposable
    {
        void TryAdd(object disposableObject);
    }
}
