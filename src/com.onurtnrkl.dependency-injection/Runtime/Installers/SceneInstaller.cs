using System.Collections.Generic;
using DependencyInjection.Core;

namespace DependencyInjection.Installers
{
    internal sealed class SceneInstaller : Installer
    {
        public override void Install(IContainerBuilder containerBuilder)
        {
            // TODO: GetComponents causes memory allocation. Use pooling instead.
            var installers = new List<IInstaller>();
            GetComponents(installers);
            installers.RemoveAt(0);

            foreach (var installer in installers)
            {
                installer.Install(containerBuilder);
            }
        }
    }
}
