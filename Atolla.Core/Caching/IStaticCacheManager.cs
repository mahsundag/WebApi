using System;
using System.Threading.Tasks;

namespace Atolla.Core.Caching
{
    public interface IStaticCacheManager
    {
        /// <summary>
        /// Get a cached item.
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="key">Cache key</param>
        /// <returns>The cached value associated with the specified key</returns>
        T Get<T>(string key) where T : new();

        /// <summary>
        /// Removes the value with the specified key from the cache
        /// </summary>
        /// <param name="key">Key of cached item</param>
        void Remove(string key);

        /// <summary>
        /// Adds the specified key and object to the cache
        /// </summary>
        /// <param name="key">Key of cached item</param>
        /// <param name="data">Value for caching</param>
        void Set(string key, object data);

        /// <summary>
        /// Gets a value indicating whether the value associated with the specified key is cached
        /// </summary>
        /// <param name="key">Key of cached item</param>
        /// <returns>True if item already is in cache; otherwise false</returns>
        bool IsSet(string key);

        T Reload<T>(string key, T data) where T : new();

        /// <summary>
        /// Clear all cache data
        /// </summary>
        void Clear();
    }
}
