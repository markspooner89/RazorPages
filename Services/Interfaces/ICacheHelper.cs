using System;

namespace RazorPageApp.Services.Interfaces
{
    public interface ICacheHelper
    {
        T GetAndCache<T>(string cacheKey, Func<T> func, TimeSpan slidingExpiration, TimeSpan absoluteExpiration);
    }
}