using System;

namespace DependencyInjection.EditorTests.Fakes
{
    internal interface IDisposableClass : IDisposable
    {
        bool Disposed { get; }
    }
}
