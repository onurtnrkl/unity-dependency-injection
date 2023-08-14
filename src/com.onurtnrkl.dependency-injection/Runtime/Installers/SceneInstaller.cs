using System.Collections.Generic;
using DependencyInjection.Core;
using UnityEngine;

namespace DependencyInjection.Installers
{
    internal sealed class SceneInstaller : MonoBehaviour, ISceneInstaller
    {
        public void Install(IContainerConfigurer containerConfigurer)
        {
            // TODO: GetComponents causes memory allocation. Use pooling instead.
            var installers = new List<IMonoInstaller>();
            GetComponents(installers);

            foreach (var installer in installers)
            {
                installer.Install(containerConfigurer);
            }
        }
    }
}
