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
            var rootGameObjects = new List<GameObject>();
            scene.GetRootGameObjects(rootGameObjects);
            Inject(scene, rootGameObjects);
        }

        public static void Inject(Scene scene, IEnumerable<GameObject> rootGameObjects)
        {
            var sceneContainer = SceneContainerCollection.Get(scene);

            foreach (var rootGameObject in rootGameObjects)
            {
                GameObjectInjector.Inject(rootGameObject, sceneContainer);
            }
        }
    }
}
