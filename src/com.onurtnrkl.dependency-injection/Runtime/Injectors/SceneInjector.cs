using System.Collections.Generic;
using DependencyInjection.Containers;
using DependencyInjection.Installers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DependencyInjection.Injectors
{
    internal static class SceneInjector
    {
        public static void Inject(Scene scene)
        {
            // TODO: GetRootGameObjects causes memory allocation. Use pooling instead.
            var sceneInstaller = Resources.Load<SceneInstaller>($"{scene.name}Installer");
            SceneContainer.CreateInstance(sceneInstaller);
            var sceneContainer = SceneContainer.Instance;
            var gameObjects = new List<GameObject>();
            scene.GetRootGameObjects(gameObjects);

            foreach (var gameObject in gameObjects)
            {
                GameObjectInjector.Inject(gameObject, sceneContainer);
            }
        }
    }
}
