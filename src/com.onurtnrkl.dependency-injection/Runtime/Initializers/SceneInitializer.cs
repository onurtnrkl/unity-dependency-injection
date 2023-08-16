using System.Collections.Generic;
using DependencyInjection.Core;
using DependencyInjection.Injectors;
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
            var rootGameObjects = new List<GameObject>();
            scene.GetRootGameObjects(rootGameObjects);
            CreateSceneContainer(scene, rootGameObjects);
            SceneInjector.Inject(scene, rootGameObjects);
        }

        private static void CreateSceneContainer(Scene scene, IEnumerable<GameObject> rootGameObjects)
        {
            var applicationContainer = ApplicationContainerProvider.Get();
            var sceneContainerBuilder = new ContainerBuilder(applicationContainer);

            foreach (var rootGameObject in rootGameObjects)
            {
                if (!rootGameObject.TryGetComponent<Installer>(out var installer)) continue;

                installer.Install(sceneContainerBuilder);
            }

            var sceneContainer = sceneContainerBuilder.Build();
            applicationContainer.AddChild(sceneContainer);
            SceneContainerCollection.Add(scene, sceneContainer);
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
