using System.Collections.Generic;
using DependencyInjection.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DependencyInjection.Initializers
{
    internal static class SceneInitializer
    {
        public static void Initialize()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.sceneUnloaded -= OnSceneUnloaded;
            SceneManager.sceneUnloaded += OnSceneUnloaded;
        }

        private static void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            CreateSceneContainer(scene);
        }

        private static void CreateSceneContainer(Scene scene)
        {
            var applicationContainer = ApplicationContainerProvider.Get();
            var sceneContainerBuilder = new ContainerBuilder(applicationContainer);
            var rootGameObjects = new List<GameObject>();
            scene.GetRootGameObjects(rootGameObjects);

            foreach (var rootGameObject in rootGameObjects)
            {
                if (!rootGameObject.TryGetComponent<Installer>(out var installer)) continue;

                installer.Install(sceneContainerBuilder);
                break;
            }

            var sceneContainer = sceneContainerBuilder.Build();
            SceneContainerCollection.Add(scene, sceneContainer);
            applicationContainer.AddChild(sceneContainer);
        }

        private static void OnSceneUnloaded(Scene scene)
        {
            var applicationContainer = ApplicationContainerProvider.Get();
            var sceneContainer = SceneContainerCollection.Get(scene);
            applicationContainer.RemoveChild(sceneContainer);
            sceneContainer.Dispose();
        }
    }
}
