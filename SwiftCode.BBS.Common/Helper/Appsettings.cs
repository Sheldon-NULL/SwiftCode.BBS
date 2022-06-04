
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Common.Helper
{
    /// <summary>
    /// appseting.json 操作类
    /// </summary>
    public class Appsettings
    {
        static IConfiguration Configuration { get; set; }

        static string contentPath { get; set; }

        public Appsettings(string contentPath)
        {
            string Path = "Appsetting.json";

            // 如果配置环境是根据环境变量来区分的，可以这样配置
            // Path = $"appsetting.json.{Environment.GetEnvironmentVariable("ASPNETCODE_ENVIRONMENT")}.JSON";

            Configuration = new ConfigurationBuilder()
                .SetBasePath(contentPath)
                .Add(new JsonConfigurationSource { Path =Path,Optional = false,ReloadOnChange = true})
                .Build();

        }

        public Appsettings(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 封装要操作的字符
        /// </summary>
        /// <param name="sections"></param>
        /// <returns></returns>
        public static string app(params string[] sections)
        {
            try
            {
                if (sections.Any())
                {
                    return Configuration[string.Join(":", sections)];
                }
            }
            catch (Exception)
            {

                throw;
            }
            return string.Empty;
        }

        /// <summary>
        /// 递归获取配置信息数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sections"></param>
        /// <returns></returns>
        public static List<T> app<T> (params string[] sections)
        {
            List<T> list = new List<T>();
            Configuration.Bind(string.Join(":", sections), list);
            return list;
        }


    }
}
