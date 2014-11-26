namespace Trendie.Core.Cache
{
    public interface IHttpRuntimeCacheWrapper
    {
        T Get<T>(string cacheKey) where T : class;
        void Insert<T>(string cacheKey, T cacheValue, int expireInMinutes) where T : class;
    }
}