using System;
using Microsoft.Extensions.Caching.Memory;

namespace Code.Services
{    
    public interface ICacheHelper
    {
        T GetAndCache<T>(string cacheKey, Func<T> func, TimeSpan slidingExpiration, TimeSpan absoluteExpiration);
    }

    public class CacheHelper : ICacheHelper
    {
        private readonly IMemoryCache _cache;

        public CacheHelper(IMemoryCache cache)
        {
            _cache = cache;
        }
        
        public T GetAndCache<T>(string cacheKey, Func<T> func, TimeSpan slidingExpiration, TimeSpan absoluteExpiration)
        {
            var success = _cache.TryGetValue(cacheKey, out T cachedData);

            if (success)
            {
                return cachedData;
            }

            var repoData = func();

            var cacheOptions = new MemoryCacheEntryOptions();
            cacheOptions.SetSlidingExpiration(slidingExpiration);
            cacheOptions.SetAbsoluteExpiration(absoluteExpiration);

            _cache.Set(cacheKey, repoData, cacheOptions);

            return repoData;
        }
    }
}