namespace DependencyInjection.Core
{
    internal sealed class InstanceResolver : IResolver
    {
        private readonly object _implementation;

        public InstanceResolver(object implementation)
        {
            _implementation = implementation;
        }

        public object Resolve()
        {
            return _implementation;
        }
    }
}
