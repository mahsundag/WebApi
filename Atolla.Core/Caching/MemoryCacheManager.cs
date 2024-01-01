using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Atolla.Core.Caching
{
    /// <summary>
    ///  Cache için thread safe nesneler kullanıldı . Farklı instanceler birbirleini locklamsın
    /// </summary>
    public class MemoryCacheManager : ILocker, IStaticCacheManager
    {

        private bool _disposed;

        private readonly IMemoryCache _memoryCache;

        private static readonly ConcurrentDictionary<string, CancellationTokenSource> _prefixes = new ConcurrentDictionary<string, CancellationTokenSource>();
        private static CancellationTokenSource _clearToken = new CancellationTokenSource();


        public MemoryCacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        private MemoryCacheEntryOptions PrepareEntryOptions(string key)
        {
            //set expiration time for the passed cache key
            var options = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60),
                Size = 1000
            };

            //add tokens to clear cache entries
            options.AddExpirationToken(new CancellationChangeToken(_clearToken.Token));
            _prefixes.GetOrAdd(key, new CancellationTokenSource());
            return options;
        }



        public T Get<T>(string key) where T : new()
        {
            if (_memoryCache.TryGetValue<T>(key, out T data))
                return data;
            else
                return default;
        }

        public void Set(string key, object data)
        {
            if (data == null)
                return;

            _memoryCache.Set(key, data, PrepareEntryOptions(key));
        }


        public bool IsSet(string key)
        {
            return _memoryCache.TryGetValue(key, out _);
        }


        public bool PerformActionWithLock(string key, TimeSpan expirationTime, Action action)
        {
            //ensure that lock is acquired
            if (IsSet(key))
                return false;

            try
            {
                _memoryCache.Set(key, key, expirationTime);

                //perform action
                action();

                return true;
            }
            finally
            {
                //release lock even if action fails
                Remove(key);
            }
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }
        public void Clear()
        {
            _clearToken.Cancel();
            _clearToken.Dispose();

            _clearToken = new CancellationTokenSource();

            foreach (var prefix in _prefixes.Keys.ToList())
            {
                _prefixes.TryRemove(prefix, out var tokenSource);
                tokenSource?.Dispose();
            }
        }

        public T Reload<T>(string key, T data) where T : new()
        {
            if (IsSet(key))
            {
                Remove(key);
                Set(key, data);
            }
            return Get<T>(key);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _memoryCache.Dispose();
            }

            _disposed = true;
        }


    }
}
