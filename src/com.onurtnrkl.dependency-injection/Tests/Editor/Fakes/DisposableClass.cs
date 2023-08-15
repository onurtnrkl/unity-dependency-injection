namespace DependencyInjection.EditorTests.Fakes
{
    internal sealed class DisposableClass : IDisposableClass
    {
        public bool Disposed { get; private set; }

        public DisposableClass()
        {
        }

        public void Dispose()
        {
            Disposed = true;
        }
    }
}
