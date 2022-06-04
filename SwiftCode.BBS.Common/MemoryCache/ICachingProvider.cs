using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Common.MemoryCache
{
    /// <summary>
    /// 缓存接口
    /// </summary>
    public interface ICachingProvider
    {
        object Get(string CacheKey);

        void Set(string cacheKey, object CacheValue);
    }
}
