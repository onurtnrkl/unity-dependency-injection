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
            Application.quitting -= OnApplicationQuit;
            Application.quitting += OnApplicationQuit;
        }

        private static void OnFirstSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            SceneManager.sceneLoaded -= OnFirstSceneLoaded;
            // TODO: Replace resources with addressables
            var applicationInstaller = Resources.Load<ApplicationInstaller>(nameof(ApplicationInstaller));
            var applicationContainer = ApplicationContainer.CreateInstance(applicationInstaller);
            var applicationResolver = applicationContainer.Resolver;
            SceneInjector.Inject(scene, applicationResolver);
        }

        private static void OnApplicationQuit()
        {
            Application.quitting -= OnApplicationQuit;
            ApplicationContainer.DestroyInstance();
        }
    }
}
