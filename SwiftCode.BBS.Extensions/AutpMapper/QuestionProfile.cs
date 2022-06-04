using AutoMapper;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.Model.ViewModels.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Extensions.AutpMapper
{
    /// <summary>
    /// 配置构造函数，用来创建关系映射
    /// </summary>
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<CreateQuestionCommentsInputDto,QuestionComment>();
            CreateMap<CreateQuestionInputDto, Question>();
            CreateMap<UpdateQuestionInputDto, Question>();
            CreateMap<Question, QuestionDto>()
                .ForMember(a => a.QuestionCommentCount,o => o.MapFrom(x => x.QuestionComments.Count));
            CreateMap<Question,QuestionDetailsDto>();
            CreateMap<QuestionComment, QuestionCommentDto>()
                .ForMember(a => a.UserName,o => o.MapFrom(x => x.CreateUser.UserName))
                .ForMember(a => a.HeadPortrait,o => o.MapFrom(x => x.CreateUser.HeadPortrait));
        }
    }
}
