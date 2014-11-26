using System;

namespace Trendie.Core.Cache
{
    public interface IWebCache
    {
        T Get<T>(string cacheKey, Func<T> getItemCallback, int expireInMinutes) where T : class;
    }
}