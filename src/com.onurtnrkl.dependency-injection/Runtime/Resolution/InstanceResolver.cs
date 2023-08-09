namespace DependencyInjection.Resolution
{
    internal sealed class InstanceResolver : IObjectResolver
    {
        private readonly object _instance;

        public InstanceResolver(object instance)
        {
            _instance = instance;
        }

        public object Resolve()
        {
            return _instance;
        }
    }
}
