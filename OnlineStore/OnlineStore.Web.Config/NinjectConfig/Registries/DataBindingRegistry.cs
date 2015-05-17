namespace OnlineStore.Web.Config.Registries
{
    using Ninject;

    using OnlineStore.Data;
    using OnlineStore.Web.Config.Registries.Contracts;

    public class DataBindingsRegistry : INinjectRegistry
    {
        public void Register(IKernel kernel)
        {
            kernel.Bind<IOnlineStoreDbContext>().To<OnlineStoreDbContext>();
            kernel.Bind<IOnlineStoreData>().To<OnlineStoreData>();
        }
    }
}
