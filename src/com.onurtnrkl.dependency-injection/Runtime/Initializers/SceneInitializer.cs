using DependencyInjection.Injectors;
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
            SceneInjector.Inject(scene);
        }

        private static void OnSceneUnloaded(Scene scene)
        {

        }
    }
}
