using DependencyInjection.Attributes;
using UnityEngine;

namespace DependencyInjection.Tests.Fakes
{
    internal sealed class OneParameterMonoBehaviour : MonoBehaviour
    {
        private IZeroParameterClass _zeroParameterClass;

        [Inject]
        public void Construct(IZeroParameterClass zeroParameterClass)
        {
            _zeroParameterClass = zeroParameterClass;
        }

        public IZeroParameterClass GetZeroParameterClass()
        {
            return _zeroParameterClass;
        }
    }
}
