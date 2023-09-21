using UnityEngine;

namespace DependencyInjection.Core
{
    public abstract class Installer : MonoBehaviour
    {
        public abstract void Install(IContainerConfigurer containerConfigurer);
    }
}
