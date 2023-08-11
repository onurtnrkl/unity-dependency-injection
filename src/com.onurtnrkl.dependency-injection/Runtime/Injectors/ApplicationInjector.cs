using DependencyInjection.Containers;
using DependencyInjection.Installers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DependencyInjection.Injectors
{
    internal static class ApplicationInjector
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        public static void Inject()
        {
            SceneManager.sceneLoaded -= OnFirstSceneLoaded;
            SceneManager.sceneLoaded += OnFirstSceneLoaded;
            SceneManager.sceneLoaded -= OnSceneLoaded;
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.sceneUnloaded -= OnSceneUnloaded;
            SceneManager.sceneUnloaded += OnSceneUnloaded;
            Application.quitting -= OnApplicationQuit;
            Application.quitting += OnApplicationQuit;
        }

        private static void OnFirstSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            SceneManager.sceneLoaded -= OnFirstSceneLoaded;
            // TODO: Replace resources with addressables
            var applicationInstaller = Resources.Load<ApplicationInstaller>(nameof(ApplicationInstaller));
            ApplicationContainer.CreateInstance(applicationInstaller);
        }

        private static void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            SceneInjector.Inject(scene);
        }

        private static void OnSceneUnloaded(Scene scene)
        {
            
        }

        private static void OnApplicationQuit()
        {
            Application.quitting -= OnApplicationQuit;
            ApplicationContainer.DestroyInstance();
        }
    }
}
