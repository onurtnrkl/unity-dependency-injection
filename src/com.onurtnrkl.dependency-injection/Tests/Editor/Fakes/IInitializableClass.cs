using DependencyInjection.Core;

namespace DependencyInjection.EditorTests.Fakes
{
    internal interface IInitializableClass : IInitializable
    {
        public bool Initialized { get; }
    }
}
