using System.Collections.Generic;
using DependencyInjection.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DependencyInjection.Injectors
{
    internal static class SceneInjector
    {
        public static void Inject(Scene scene)
        {
            var sceneContainer = SceneContainerCollection.Get(scene);
            // TODO: GetRootGameObjects causes memory allocation. Use pooling instead.
            var gameObjects = new List<GameObject>();
            scene.GetRootGameObjects(gameObjects);

            foreach (var gameObject in gameObjects)
            {
                GameObjectInjector.Inject(gameObject, sceneContainer);
            }
        }
    }
}
