using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using SwiftCode.BBS.API;
using SwiftCode.BBS.Common.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Tests
{
    public static class ArticleScenariosBase
    {
/*        public static TestServer GetService()
        {
            var bulider = new WebHostBuilder()
                .UseStartup<Startup>()
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.SetBasePath(Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "..\\..\\..\\..\\AspNetCoreTodo"));
                    config.AddJsonFile("appsetting.json");

                });
            var _server = new TestServer(bulider);
            return _server;
        }*/
        
        public static IHostBuilder GetTestHost()
        {
            return new HostBuilder()
                // 替换autofac作为DI容器
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                    .UseTestServer()
                    .UseStartup<Startup>();
                })
                .ConfigureAppConfiguration((host, builder) =>
                {
                    builder.SetBasePath(Directory.GetCurrentDirectory());
                    builder.AddJsonFile("appsetting.json", optional: true);
                    builder.AddEnvironmentVariables();
                });
        }

        public static HttpClient GetTestClientWithToken(this IHost host)
        {
            // 获取令牌
            TokenModelJwt tokenModel = new TokenModelJwt { Uid = 1, Role = "Admin" };
            var jwtStr = JwtHelper.IssueJwt(tokenModel);

            var client = host.GetTestClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwtStr}");
            return client;
        }
    }
}
