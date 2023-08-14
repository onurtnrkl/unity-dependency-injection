using DependencyInjection.Core;
using UnityEngine;

namespace DependencyInjection.Installers
{
    public abstract class MonoInstaller : MonoBehaviour, IMonoInstaller
    {
        public abstract void Install(IContainerConfigurer containerConfigurer);
    }
}
