namespace DependencyInjection.Core
{
    internal interface IInstaller
    {
        public void Install(IContainerBuilder containerBuilder);
    }
}
