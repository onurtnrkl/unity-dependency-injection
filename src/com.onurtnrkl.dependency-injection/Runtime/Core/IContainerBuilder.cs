namespace DependencyInjection.Core
{
    public interface IContainerBuilder : IContainerConfigurer
    {
        void SetParent(IContainer parent);
        IContainer Build();
    }
}
