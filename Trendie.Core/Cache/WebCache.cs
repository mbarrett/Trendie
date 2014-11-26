using System;

namespace Trendie.Core.Cache
{
    public class WebCache : IWebCache
    {
        private readonly IHttpRuntimeCacheWrapper _httpRuntimeCacheWrapper;

        public WebCache(IHttpRuntimeCacheWrapper httpRuntimeCacheWrapper)
        {
            _httpRuntimeCacheWrapper = httpRuntimeCacheWrapper;
        }

        public T Get<T>(string cacheKey, Func<T> getItemCallback, int expireInMinutes) where T : class
        {
            var result = _httpRuntimeCacheWrapper.Get<T>(cacheKey);

            if (result != null)
                return result;

            result = getItemCallback();

            if (result != null)
                _httpRuntimeCacheWrapper.Insert(cacheKey, result, expireInMinutes);

            return result;
        }
    }
}