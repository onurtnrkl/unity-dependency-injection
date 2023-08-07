namespace DependencyInjection.EditorTests.Fakes
{
    internal class OneParameterClass : IOneParameterClass
    {
        private readonly IZeroParameterClass _zeroParameterClass;

        public OneParameterClass(IZeroParameterClass zeroParameterClass)
        {
            _zeroParameterClass = zeroParameterClass;
        }

        public IZeroParameterClass GetZeroParameterClass()
        {
            return _zeroParameterClass;
        }
    }
}
