using DependencyInjection.Core;
using DependencyInjection.Utilities;
using UnityEngine;
using UnityEngine.AddressableAssets;
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
            var applicationContainer = ApplicationContainerProvider.Get();
            applicationContainer.Dispose();
        }

        private static void CreateApplicationContainer()
        {
            var containerBuilder = new ContainerBuilder(Container.Root);
            var loadInstallerHandle = AddressablesUtilities.LoadComponentAsync<Installer>("ApplicationInstaller");
            var installer = loadInstallerHandle.WaitForCompletion();

            if (installer != null)
            {
                installer.Install(containerBuilder);
            }

            Addressables.Release(loadInstallerHandle);
            var applicationContainer = containerBuilder.Build();
            ApplicationContainerProvider.Set(applicationContainer);
        }
    }
}
