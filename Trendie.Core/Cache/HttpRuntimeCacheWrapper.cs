using System;
using System.Web;

namespace Trendie.Core.Cache
{
    public class HttpRuntimeCacheWrapper : IHttpRuntimeCacheWrapper
    {
        public T Get<T>(string cacheKey) where T : class
        {
            return HttpRuntime.Cache.Get(cacheKey) as T;
        }

        public void Insert<T>(string cacheKey, T cacheValue, int expireInMinutes) where T : class
        {
            HttpRuntime.Cache.Insert(cacheKey, cacheValue, null, DateTime.UtcNow.AddMinutes(expireInMinutes), System.Web.Caching.Cache.NoSlidingExpiration);
        }
    }
}