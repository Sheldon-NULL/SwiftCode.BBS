using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Common.MemoryCache
{
    /// <summary>
    /// 实例化缓存接口
    /// </summary>
    public class MemoryCachingProvider : ICachingProvider
    {
        //引用Microsoft.Extensions.Caching.Memory;5.0.0
        private readonly IMemoryCache _cache;

        public MemoryCachingProvider(IMemoryCache cache)
        {
            _cache = cache;
        }
       
        public object Get(string CacheKey)
        {
            return _cache.Get(CacheKey);
        }

        public void Set(string cacheKey, object CacheValue)
        {
            _cache.Set(cacheKey, CacheValue,TimeSpan.FromSeconds(7200));
        }
    }
}
