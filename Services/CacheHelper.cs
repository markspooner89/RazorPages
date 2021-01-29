using System;
using Microsoft.Extensions.Caching.Memory;
using RazorPageApp.Services.Interfaces;

namespace RazorPageApp.Services
{    
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