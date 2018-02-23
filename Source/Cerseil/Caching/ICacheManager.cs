namespace Cerseil.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);

        void Set<T>(string key, T data, int cacheTime);

        bool IsSet(string key);

        void Remove(string key);

        void RemoveByPattern(string pattern);

        void Clear();
    }
}
