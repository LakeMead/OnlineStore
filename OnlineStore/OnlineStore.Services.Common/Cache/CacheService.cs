namespace OnlineStore.Services.Common.Cache
{
    using System;
    using System.Web;
    using System.Web.Caching;

    using OnlineStore.Services.Common.Contracts;

    public class CacheService : ICacheService
    {
        public T Get<T>(string cacheId, Func<T> getItemCallback, int cacheMinutes) where T : class
        {
            var item = HttpRuntime.Cache.Get(cacheId) as T;
            if (item == null)
            {
                item = getItemCallback();
                HttpContext.Current.Cache.Add(
                    cacheId,
                    item,
                    null,
                    DateTime.Now.AddMinutes(cacheMinutes),
                    TimeSpan.Zero,
                    CacheItemPriority.Default,
                    null);
            }

            return item;
        }
    }
}
