namespace OnlineStore.Web
{
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using OnlineStore.Common.Constants;
    using OnlineStore.Common.Mapping;
    using OnlineStore.Web.Config;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            NinjectWebCommon.RegisterDependencyResolver();

            var autoMapperConfig = new AutoMapperConfig(
                new[]
                {
                    Assembly.GetExecutingAssembly(),
                    Assembly.Load(Assemblies.WebModels),
                    Assembly.Load(Assemblies.CommonServices)
                });
            autoMapperConfig.Execute();
        }
    }
}
