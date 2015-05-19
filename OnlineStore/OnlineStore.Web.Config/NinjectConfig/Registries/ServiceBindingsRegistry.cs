namespace OnlineStore.Web.Config.NinjectConfig.Registries
{
    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Web.Common;

    using OnlineStore.Common.Constants;

    public class ServiceBindingsRegistry
    {
        public void Register(IKernel kernel)
        {
            kernel.Bind(s => s.From(Assemblies.CommonServices)
                .SelectAllClasses()
                .BindAllInterfaces()
                .Configure(c => c.InRequestScope()));
        }
    }
}
