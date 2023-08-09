using DependencyInjection.Resolution;

namespace DependencyInjection.Core
{
    internal class Container : IContainer
    {
        private readonly IContainerResolver _containerResolver;

        public Container(IContainerResolver containerResolver)
        {
            _containerResolver = containerResolver;
        }
    }
}
