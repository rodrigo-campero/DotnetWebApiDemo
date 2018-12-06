[assembly: WebActivator.PostApplicationStartMethod(typeof(DotnetWebApiDemo.Service.WebAPI.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace DotnetWebApiDemo.Service.WebAPI.App_Start
{
    using DotnetWebApiDemo.Infra.CrossCutting;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using SimpleInjector.Lifestyles;
    using System.Web.Http;

    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            Container container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void InitializeContainer(Container container)
        {
            Bootstrap.RegisterServices(container);
        }
    }
}