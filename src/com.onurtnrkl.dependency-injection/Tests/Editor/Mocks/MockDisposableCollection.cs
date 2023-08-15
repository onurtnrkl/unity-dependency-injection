using DependencyInjection.Resolution;

namespace DependencyInjection.EditorTests.Mocks
{
    internal sealed class MockDisposableCollection : IDisposableCollection
    {
        public MockDisposableCollection()
        {
        }

        public void Dispose()
        {
        }

        public void TryAdd(object disposableObject)
        {
        }
    }
}
