using System.Collections.Generic;
using DependencyInjection.Resolution;
using UnityEngine;

namespace DependencyInjection.Injectors
{
    internal static class GameObjectInjector
    {
        public static void Inject(GameObject gameObject, IRegistrationResolver registrationResolver)
        {
            var components = new List<Component>();
            gameObject.GetComponents(components);

            foreach (var component in components)
            {
                MethodInjector.Inject(component, registrationResolver);
            }
        }
    }
}
