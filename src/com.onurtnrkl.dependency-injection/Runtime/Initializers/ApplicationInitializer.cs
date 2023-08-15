using DependencyInjection.Core;
using DependencyInjection.Installers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DependencyInjection.Initializers
{
    internal static class ApplicationInitializer
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        public static void Initialize()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            SceneManager.sceneLoaded += OnSceneLoaded;
            Application.quitting -= OnApplicationQuit;
            Application.quitting += OnApplicationQuit;
            SceneInitializer.Initialize();
        }

        private static void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            CreateApplicationContainer();
        }

        private static void OnApplicationQuit()
        {
            Application.quitting -= OnApplicationQuit;
            //ApplicationContainerProvider.DestroyInstance();
        }

        private static void CreateApplicationContainer()
        {
            var containerBuilder = new ContainerBuilder(Container.Null);
            var applicationInstaller = Resources.Load<ApplicationInstaller>(nameof(ApplicationInstaller));

            if (applicationInstaller != null)
            {
                applicationInstaller.Install(containerBuilder);
            }

            var applicationContainer = containerBuilder.Build();
            ApplicationContainerProvider.Set(applicationContainer);
        }
    }
}
