using Castle.DynamicProxy;
using SwiftCode.BBS.Common.MemoryCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Extensions.AOP
{
    /// <summary>
    /// 面向切面的缓存
    /// </summary>
    public class BbsCacheAOP : IInterceptor
    {
        private readonly ICachingProvider _cache;

        public BbsCacheAOP(ICachingProvider cache)
        {
            _cache = cache;
        }
        public void Intercept(IInvocation invocation)
        {
            // 获取自定义缓存键
            var cacheKey = CustomCacheKey(invocation);
        }

        // 自定义缓存键
        private string CustomCacheKey(IInvocation invocation)
        {
            var typeName = invocation.TargetType.Name;
            var methodName = invocation.Method.Name;
            var methodArguments = invocation.Arguments.Select(GetArgumentValue).Take(3).ToList(); // 获取参数列表，最多需要三个即可

            string key = $"{typeName}:{methodName}:";
            foreach (var param in methodArguments)
            {
                key += $"{param}:";
            }
            return key.TrimEnd(':');
        }

        // object转string
        private string GetArgumentValue(object arg)
        {
            if (arg is int || arg is long || arg is string)
            {
                return arg.ToString();
            }

            if (arg is DateTime)
            {
                return ((DateTime)arg).ToString("yyyyMMddHHmmss");
            }
            return string.Empty;
        }
    }
}
