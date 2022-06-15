using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using SwiftCode.BBS.Common.Helper;
using SwiftCode.BBS.EntityFramework;
using SwiftCode.BBS.Extensions.ServiecsExtensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddDbContextPool<SwiftCodeBbsDbContext>(
                options =>options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DB"), oo => oo.MigrationsAssembly("SwiftCode.BBS.EntityFramework"))
                );
            services.AddSingleton(new Appsettings(Configuration));

            services.AddMemoryCacheSetup(); 
            services.AddAutoMapperSetup();
           /* services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SwiftCode.BBS.API", Version = "v1" });
            });*/

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v0.1.0",
                    Title = "SwiftCode.BBS.API",
                    Description = "框架说明文档",
                    Contact = new OpenApiContact
                    {
                        Name = "SwiftCode",
                        Email = "SwiftCode@xxx.com",
                    }
                });
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "SwiftCode.BBS.API.xml");
                c.IncludeXmlComments(xmlPath,true);

                var xmlModelPath = Path.Combine(basePath, "SwiftCode.BBS.Model.xml");
                c.IncludeXmlComments(xmlModelPath);

                // 开启小锁
                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                // 在header中添加token，传递到后台
                c.OperationFilter<SecurityRequirementsOperationFilter>();

                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {

                    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
                    Name = "Authorization",//jwt默认的参数名称
                    In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.ApiKey
                });

            });
            #endregion

            #region JWT认证
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                var audienceConfig = Configuration["Audience:Audience"];
                var symmetricKeyAsBase64 = Configuration["Audience:Secret"];
                var iss = Configuration["Audience:Issuer"];
                var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
                var signingKey = new SymmetricSecurityKey(keyByteArray);

                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signingKey,
                    ValidateIssuer = true,
                    ValidIssuer = iss,//发行人
                    ValidateAudience = true,
                    ValidAudience = audienceConfig,//订阅人
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,//这个是缓冲过期时间，也就是说，即使我们配置了过期时间，这里也要考虑进去，过期时间+缓冲，默认好像是7分钟，你可以直接设置为0
                    RequireExpirationTime = true,
                };
            });
            
            

            #endregion

            #region 策略配置
            services.AddAuthorization(o =>
            {
                o.AddPolicy("Client", policy => policy.RequireRole("Client").Build());
                o.AddPolicy("Admin", policy => policy.RequireRole("Admin").Build());
                o.AddPolicy("SystemOrAdmin",policy => policy.RequireRole("Admin","System"));
                o.AddPolicy("SystemAndClient", policy => policy.RequireRole("Admin").RequireRole("System"));
            });
            #endregion
        }

        // 注意在Program.CreateHostBuilder，添加Autofac服务工厂
        public void ConfigureContainer(ContainerBuilder builder)
        {

            builder.RegisterModule<AutofacModuleRegister>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SwiftCode.BBS.API v1"));
            }

            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(o=>
                {
                    o.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiHelp v1");
                    o.RoutePrefix = "";
                });
            #endregion
            app.UseHttpsRedirection();

            app.UseRouting();
            // 1.开启认证中间件
            app.UseAuthentication();
            // 2.开启授权中间件
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
