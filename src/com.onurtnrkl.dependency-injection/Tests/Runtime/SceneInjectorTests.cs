using DependencyInjection.Core;
using DependencyInjection.Injectors;
using DependencyInjection.Tests.Fakes;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DependencyInjection.Tests
{
    internal sealed class SceneInjectorTests : TestsBase
    {
        [Test]
        public void Inject_OneParameterMonoBehaviour_ShouldReturnInstanceOfParameter()
        {
            var scene = SceneManager.GetActiveScene();
            var containerBuilder = new ContainerBuilder(Container.Null);
            var zeroParameterClass = new ZeroParameterClass();
            containerBuilder.AddInstance(typeof(IZeroParameterClass), zeroParameterClass);
            var sceneContainer = containerBuilder.Build();
            SceneContainerCollection.Add(scene, sceneContainer);
            var monoBehaviour = new GameObject("MonoBehaviour").AddComponent<OneParameterMonoBehaviour>();
            SceneInjector.Inject(scene);
            var actual = monoBehaviour.GetZeroParameterClass();
            var expected = zeroParameterClass;
            Assert.AreEqual(expected, actual);
        }
    }
}
