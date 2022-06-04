using Autofac;
using Autofac.Extras.DynamicProxy;
using SwiftCode.BBS.Common.Helper;
using SwiftCode.BBS.Extensions.AOP;
using SwiftCode.BBS.IServices.BASE;
using SwiftCode.BBS.Repositories.BASE;
using SwiftCode.BBS.Services.BASE;
using SwitfCode.BBS.IRepositories.BASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Extensions.ServiecsExtensions
{
    public class AutofacModuleRegister :Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var cacheType = new List<Type>();

            if (Appsettings.app(new string[] { "AppSettings", "MemoryCachingAOP", "Enabled" }).ObjToBool())
            {
                builder.RegisterType<BbsCacheAOP>();
                cacheType.Add(typeof(BbsCacheAOP));
            }

            if (Appsettings.app(new string[] { "AppSettings", "LogAOP", "Enabled" }).ObjToBool())
            {
                builder.RegisterType<BbsLogAOP>();
                cacheType.Add(typeof(BbsLogAOP));
            }

            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerDependency();
            builder.RegisterGeneric(typeof(BaseService<>)).As(typeof(IBaseService<>)).InstancePerDependency();

            // builder.RegisterType<ArticleService>().As<IArticleService>();
            var assemblysServices = Assembly.Load("SwiftCode.BBS.Services");// 这里注入的是实现层，不是接口层

            builder.RegisterAssemblyTypes(assemblysServices)
                .AsImplementedInterfaces()// 在Load方法中，指定要扫描的程序集的类库名称，这样系统会自动把改程序集中所有的接口和实现类注册到服务中。
                .EnableInterfaceInterceptors()// 引用Autofac.Extras.DynamicProxy 对目标类型启用接口拦截。拦截器将被确定，通过在类或接口上截取属性, 或添加 InterceptedBy ()
                .InterceptedBy(cacheType.ToArray()); ////允许将拦截器服务的列表分配给注册。
            var assemblysRepository = Assembly.Load("SwiftCode.BBS.Repositories");
            builder.RegisterAssemblyTypes(assemblysRepository).AsImplementedInterfaces();
        }
    }
}
