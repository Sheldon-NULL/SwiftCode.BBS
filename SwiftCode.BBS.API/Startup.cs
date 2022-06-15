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
                    Description = "���˵���ĵ�",
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

                // ����С��
                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                // ��header�����token�����ݵ���̨
                c.OperationFilter<SecurityRequirementsOperationFilter>();

                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {

                    Description = "JWT��Ȩ(���ݽ�������ͷ�н��д���) ֱ�����¿�������Bearer {token}��ע������֮����һ���ո�\"",
                    Name = "Authorization",//jwtĬ�ϵĲ�������
                    In = ParameterLocation.Header,//jwtĬ�ϴ��Authorization��Ϣ��λ��(����ͷ��)
                    Type = SecuritySchemeType.ApiKey
                });

            });
            #endregion

            #region JWT��֤
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
                    ValidIssuer = iss,//������
                    ValidateAudience = true,
                    ValidAudience = audienceConfig,//������
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,//����ǻ������ʱ�䣬Ҳ����˵����ʹ���������˹���ʱ�䣬����ҲҪ���ǽ�ȥ������ʱ��+���壬Ĭ�Ϻ�����7���ӣ������ֱ������Ϊ0
                    RequireExpirationTime = true,
                };
            });
            
            

            #endregion

            #region ��������
            services.AddAuthorization(o =>
            {
                o.AddPolicy("Client", policy => policy.RequireRole("Client").Build());
                o.AddPolicy("Admin", policy => policy.RequireRole("Admin").Build());
                o.AddPolicy("SystemOrAdmin",policy => policy.RequireRole("Admin","System"));
                o.AddPolicy("SystemAndClient", policy => policy.RequireRole("Admin").RequireRole("System"));
            });
            #endregion
        }

        // ע����Program.CreateHostBuilder�����Autofac���񹤳�
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
            // 1.������֤�м��
            app.UseAuthentication();
            // 2.������Ȩ�м��
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
