namespace OnlineStore.Web.Config.Registries.Contracts
{
    using Ninject;

    public interface INinjectRegistry
    {
        void Register(IKernel kernel);
    }
}
