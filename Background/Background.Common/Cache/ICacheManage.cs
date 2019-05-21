namespace Background.Common.Cache
{
    public interface ICacheManager
    {
        void Add(string key, object value);
        void Add(string key, object value, int expirationInSeconds);
        bool Contains(string key);
        T Get<T>(string key);
        void Remove(string key);
        void Set(string key, object value);
        void Set(string key, object value, int expirationInSeconds);
    }
}
