using UnityEngine;

namespace DependencyInjection.Core
{
    internal abstract class MonoInstaller : MonoBehaviour, IMonoInstaller
    {
        public abstract void Install(IContainerBuilder containerBuilder);
    }
}
