
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Extensions.AutpMapper
{
    /// <summary>
    /// 静态全局AutoMapper配置文件
    /// </summary>
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserInfoProfile());
                cfg.AddProfile(new QuestionProfile());
                cfg.AddProfile(new ArticleProfile());
            });
        }
    }
}
