using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Extensions.AOP
{
    /// <summary>
    /// 使用AOP实现对Service层进行日志记录
    /// </summary>
    public class BbsLogAOP : IInterceptor
    {
       /// <summary>
       /// 实例化IInterceptor方法
       /// </summary>
       /// <param name="invocation">包含被拦截方法的信息</param>
        public void Intercept(IInvocation invocation)
        {
            // 记录被拦截方法信息的日志信息
            var dataIntercept = $"{DateTime.Now.ToString("yyyyMMddHHmmss")}" +
                               $"当前执行方法：{invocation.Method.Name}"+
                               $"参数是：{string.Join(", ",invocation.Arguments.Select(x => (x ?? "").ToString().ToArray()))} \r\n";
            // 注意：下面的方法仅针对同步的策略，如果service是异步的，则在这里获取不到
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                dataIntercept += ($"方法之中出现异常：{ex.Message}");
                
            }

            dataIntercept += $"被拦截的方法执行完毕，返回结果：{invocation.ReturnValue}";

            #region 输出到当前项目日志
            var path = Directory.GetCurrentDirectory() + @"\Log";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fileName = path + $@"\InterceptLog-{DateTime.Now.ToString("yyyyMMddHHmmss")}.log";
            using (StreamWriter sw = File.AppendText(fileName))
            {
                sw.WriteLine(dataIntercept);
            }
           /* StreamWriter sw = File.AppendText(fileName);
            sw.WriteLine(dataIntercept);
            sw.Close();*/
            #endregion
        }
    }
}
