namespace OnlineStore.Services.Common.Contracts
{
    using System;

    public interface ICacheService : IService
    {
        T Get<T>(string cacheId, Func<T> getItemCallback, int cacheMinutes) where T : class;
    }
}
