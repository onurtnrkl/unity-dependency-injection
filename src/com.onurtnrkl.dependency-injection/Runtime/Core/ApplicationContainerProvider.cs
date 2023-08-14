namespace DependencyInjection.Core
{
    internal static class ApplicationContainerProvider
    {
        private static IContainer s_applicationContainer;

        public static IContainer Get()
        {
            return s_applicationContainer;
        }

        public static void Set(IContainer applicationContainer)
        {
            s_applicationContainer = applicationContainer;
        }
    }
}
