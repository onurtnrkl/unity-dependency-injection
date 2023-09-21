using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace DependencyInjection.Utilities
{
    internal static class AddressablesUtilities
    {
        public static AsyncOperationHandle<T> LoadComponentAsync<T>(object key) where T : Component
        {
            var resourceManager = Addressables.ResourceManager;

            return resourceManager.CreateChainOperation(Addressables.LoadAssetAsync<GameObject>(key), (AsyncOperationHandle<GameObject> handle) =>
            {
                var gameObject = handle.Result;
                var component = gameObject.GetComponent<T>();
                return resourceManager.CreateCompletedOperation(component, string.Empty);
            });
        }
    }
}
