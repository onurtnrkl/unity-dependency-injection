namespace DependencyInjection.Resolution
{
    internal sealed class InstanceResolver : IObjectResolver
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
