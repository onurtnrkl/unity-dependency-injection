using DependencyInjection.Core;
using System.Collections.Generic;
using DependencyInjection.Resolution;
using UnityEngine;

namespace DependencyInjection.Injectors
{
    internal static class GameObjectInjector
    {
        public static void Inject(GameObject gameObject, IContainerResolver containerResolver)
        {
            // TODO: GetRootGameObjects causes memory allocation. Use pooling instead.
            var monoBehaviours = new List<IInstaller>();
            gameObject.GetComponents(monoBehaviours);
            monoBehaviours.RemoveAt(0);

            foreach (var monoBehaviour in monoBehaviours)
            {
                MethodInjector.Inject(monoBehaviour, containerResolver);
            }
        }
    }
}
