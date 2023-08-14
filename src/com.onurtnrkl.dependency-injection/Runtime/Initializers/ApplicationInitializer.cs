using DependencyInjection.Containers;
using DependencyInjection.Injectors;
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
            ApplicationInjector.Inject(scene, loadSceneMode);
        }

        private static void OnApplicationQuit()
        {
            Application.quitting -= OnApplicationQuit;
            ApplicationContainer.DestroyInstance();
        }
    }
}
