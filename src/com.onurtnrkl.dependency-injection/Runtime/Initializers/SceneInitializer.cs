using DependencyInjection.Core;
using DependencyInjection.Injectors;
using DependencyInjection.Installers;
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
            SceneInjector.Inject(scene);
        }

        private static void CreateSceneContainer(Scene scene)
        {
            var containerBuilder = new ContainerBuilder();
            var sceneInstaller = Resources.Load<SceneInstaller>($"{scene.name}Installer");

            if (sceneInstaller != null)
            {
                sceneInstaller.Install(containerBuilder);
            }

            var applicationContainer = ApplicationContainerProvider.Get();
            containerBuilder.SetParent(applicationContainer);
            var sceneContainer = containerBuilder.Build();
            applicationContainer.AddChild(sceneContainer);
            SceneContainerCollection.Add(scene, sceneContainer);
        }

        private static void OnSceneUnloaded(Scene scene)
        {
            var applicationContainer = ApplicationContainerProvider.Get();
            var sceneContainer = SceneContainerCollection.Get(scene);
            applicationContainer.RemoveChild(sceneContainer);
            //sceneContainer.Dispose();
        }
    }
}
