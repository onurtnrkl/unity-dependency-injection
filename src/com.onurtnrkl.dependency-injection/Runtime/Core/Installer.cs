using UnityEngine;

namespace DependencyInjection.Core
{
    internal abstract class Installer : MonoBehaviour, IInstaller
    {
        public abstract void Install(IContainerBuilder containerBuilder);
    }
}
