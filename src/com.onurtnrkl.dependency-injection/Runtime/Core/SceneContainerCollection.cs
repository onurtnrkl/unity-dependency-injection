using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace DependencyInjection.Core
{
    internal static class SceneContainerCollection
    {
        private readonly static Dictionary<Scene, IContainer> s_sceneContainersByScenes = new();

        public static IContainer Get(Scene scene)
        {
            return s_sceneContainersByScenes[scene];
        }

        public static void Add(Scene scene, IContainer sceneContainer)
        {
            s_sceneContainersByScenes.Add(scene, sceneContainer);
        }

        public static void Clear()
        {
            s_sceneContainersByScenes.Clear();
        }
    }
}
