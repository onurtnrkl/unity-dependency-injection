using DependencyInjection.Attributes;

namespace DependencyInjection.EditorTests.Fakes
{
    internal sealed class ClassWithInjectableMethod
    {
        private IZeroParameterClass _zeroParameterClass;

        public ClassWithInjectableMethod()
        {
            _zeroParameterClass = null;
        }

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
