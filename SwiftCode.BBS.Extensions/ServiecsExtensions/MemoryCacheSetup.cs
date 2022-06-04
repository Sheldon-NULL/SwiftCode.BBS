﻿using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using SwiftCode.BBS.Common.MemoryCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Extensions.ServiecsExtensions
{
    /// <summary>
    /// Memory缓存启动服务
    /// </summary>
    public static class MemoryCacheSetup
    {
        public static void AddMemoryCacheSetup(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<ICachingProvider, MemoryCachingProvider>();
            services.AddSingleton<IMemoryCache>(factory =>
            {
                var cache = new MemoryCache(new MemoryCacheOptions());
                return cache;
            });
        }
    }
}
