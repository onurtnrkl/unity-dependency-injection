﻿using DependencyInjection.Containers;
using DependencyInjection.Installers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DependencyInjection.Injectors
{
    internal static class ApplicationInjector
    {
        public static void Inject(Scene scene, LoadSceneMode loadSceneMode)
        {
            // TODO: Replace resources with addressables
            var applicationInstaller = Resources.Load<ApplicationInstaller>(nameof(ApplicationInstaller));
            ApplicationContainer.CreateInstance(applicationInstaller);
        }
    }

    internal static class ApplicationInitializer
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        public static void Initialize()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            SceneManager.sceneLoaded += OnSceneLoaded;
            Application.quitting -= OnApplicationQuit;
            Application.quitting += OnApplicationQuit;
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
