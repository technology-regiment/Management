using System;
using System.Runtime.Caching;

namespace Background.Common.Cache
{
    public class MemoryCacheManager : ICacheManager
    {
        private readonly MemoryCache _cache;
        private const double DefaultExpirationInSeconds = 30000;

        public MemoryCacheManager()
        {
            _cache = new MemoryCache(Guid.NewGuid().ToString());
        }

        public void Add(string key, object value)
        {
            var policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(DefaultExpirationInSeconds)
            };
            _cache.Add(key, value, policy);
        }

        public void Add(string key, object value, int expirationInSeconds)
        {
            _cache.Add(key, value, new CacheItemPolicy
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(expirationInSeconds)
            });
        }

        public bool Contains(string key)
        {
            return _cache.Contains(key);
        }
        public void Set(string key, object value)
        {
            var policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(DefaultExpirationInSeconds)
            };
            _cache.Set(key, value, policy);
        }

        public void Set(string key, object value, int expirationInSeconds)
        {
            var policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(expirationInSeconds)
            };
            _cache.Set(key, value, policy);
        }


        public T Get<T>(string key)
        {
            if (_cache[key] != null) return (T)_cache[key];
            return default(T);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }
    }
}
