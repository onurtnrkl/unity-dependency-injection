﻿using DependencyInjection.Core;
using DependencyInjection.Injectors;
using DependencyInjection.Resolution;
using DependencyInjection.Tests.Fakes;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DependencyInjection.Tests
{
    [TestFixture]
    internal sealed class SceneInjectorTests : TestsBase
    {
        [Test]
        public void Inject_OneParameterMonoBehaviour_ShouldReturnSameInstanceOfParameter()
        {
            var scene = SceneManager.GetActiveScene();
            var containerBuilder = new ContainerBuilder();
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