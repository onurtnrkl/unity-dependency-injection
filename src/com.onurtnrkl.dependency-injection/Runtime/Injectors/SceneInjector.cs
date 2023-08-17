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
            var rootGameObjects = new List<GameObject>();
            scene.GetRootGameObjects(rootGameObjects);

            foreach (var rootGameObject in rootGameObjects)
            {
                GameObjectInjector.Inject(rootGameObject, sceneContainer);
            }
        }
    }
}
