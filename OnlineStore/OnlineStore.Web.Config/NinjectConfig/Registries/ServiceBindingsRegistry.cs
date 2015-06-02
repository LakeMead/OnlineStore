namespace OnlineStore.Web.Config.NinjectConfig.Registries
{
    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Web.Common;

    using OnlineStore.Common.Constants;
    using OnlineStore.Web.Config.Registries.Contracts;

    public class ServiceBindingsRegistry : INinjectRegistry
    {
        public void Register(IKernel kernel)
        {
            kernel.Bind(s => s.From(
                    Assemblies.CommonServices, 
                    Assemblies.ShoppingCartServices, 
                    Assemblies.ImageResizer, 
                    Assemblies.ValidationService)
                .SelectAllClasses()
                .BindAllInterfaces()
                .Configure(c => c.InRequestScope()));
        }
    }
}
