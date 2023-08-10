using System.Collections.Generic;
using DependencyInjection.Resolution;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DependencyInjection.Injectors
{
    internal static class SceneInjector
    {
        public static void Inject(Scene scene, IContainerResolver containerResolver)
        {
            // TODO: GetRootGameObjects causes memory allocation. Use pooling instead.
            var gameObjects = new List<GameObject>();
            scene.GetRootGameObjects(gameObjects);

            foreach (var gameObject in gameObjects)
            {
                MethodInjector.Inject(gameObject, containerResolver);
            }
        }
    }
}
