using DependencyInjection.Core;

namespace DependencyInjection.Installers
{
    internal interface IInstaller
    {
        public void Install(IContainerConfigurer containerConfigurer);
    }
}
