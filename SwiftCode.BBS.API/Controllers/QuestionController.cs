using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftCode.BBS.Common.Helper;
using SwiftCode.BBS.IServices;
using SwiftCode.BBS.IServices.BASE;
using SwiftCode.BBS.Model;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.Model.ViewModels.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiftCode.BBS.API.Controllers
{
    /// <summary>
    /// 问答
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _qusetionService;
        private readonly IBaseService<UserInfo> _userInfoServcie;
        private readonly IMapper _mapper;

        public QuestionController(IQuestionService questionService, IBaseService<UserInfo> userInfoService, IMapper mapper)
        {
            _qusetionService = questionService;
            _userInfoServcie = userInfoService;
            _mapper = mapper;
        }

        /// <summary>
        /// 分页获取问答列表
        /// </summary>
        /// <param name="page">页数</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel< List<QuestionDto> > > GetList(int page, int pageSize)
        {
            var entityList = await _qusetionService.GetPageListAsync(page,pageSize,nameof(Question.CreateTime));

            return new MessageModel< List<QuestionDto> >()
            {
                success = true,
                message = TipsModel.GetSuccess,
                response = _mapper.Map< List<QuestionDto> >(entityList),
            };
        }
        /// <summary>
        /// 根据Id查询问答
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel <QuestionDetailsDto> > Get(int id)
        {
            var entity = await _qusetionService.GetQuestionDetailsAsync(id);
            var result = _mapper.Map< QuestionDetailsDto >(entity);
            return new MessageModel<QuestionDetailsDto> 
            { 
                success = true,

            };
        }

        /// <summary>
        /// 创建问答
        /// </summary>
        /// <param name="input">问答内容</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageModel <string> > CreateAsync(CreateQuestionInputDto input)
        {
            var token = JwtHelper.ParsingJwtToken(HttpContext);
            var entity = _mapper.Map<Question>(input);
            entity.Traffic = 1;
            entity.CreateTime = DateTime.Now;
            entity.CreateUserId = token.Uid;
            await _qusetionService.InsertAsync(entity, true);
            return new MessageModel<string>()
            {
                success = true,
                message = TipsModel.CreateSucccess,
            };
        }
        /// <summary>
        /// 根据Id修改问答
        /// </summary>
        /// <param name="id">问答Id</param>
        /// <param name="input">修改内容</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<MessageModel <string> > UpdateAsync(int id, UpdateQuestionInputDto input)
        {
            var entity = await _qusetionService.GetAsync(x => x.Id == id);
            entity = _mapper.Map(input,entity);
            await _qusetionService.UpdateAsync(entity,true);
            return new MessageModel<string>()
            {
                success = true,
                message = TipsModel.UpdateSuccess,
            };
        }

        /// <summary>
        /// 根据问答Id删除问答
        /// </summary>
        /// <param name="id">问答Id</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<MessageModel <string> > DeleteAsync(int id)
        {
            var entity = await _qusetionService.GetAsync(x => x.Id == id);
            await _qusetionService.DeleteAsync(entity,true);
            return new MessageModel<string>()
            {
                success = true,
                message = TipsModel.DeleteSuccess,
            };
        }

        /// <summary>
        /// 根据Id添加问答评论
        /// </summary>
        /// <param name="id">问答Id</param>
        /// <param name="input">评论内容</param>
        /// <returns></returns>
        [HttpPost(Name = "CreateQuestionComments")]
        public async Task<MessageModel <string> > CreateQuestionCommentsAsync(int id,CreateQuestionCommentsInputDto input)
        {
            var token = JwtHelper.ParsingJwtToken(HttpContext);
            await _qusetionService.AddQusetionCommentAsync(id, token.Uid, input.Content);

            return new MessageModel<string>()
            {
                success = true,
                message = TipsModel.CommentSuccess,
            };
        }
        /// <summary>
        /// 删除问答评论
        /// </summary>
        /// <param name="questionId">问答Id</param>
        /// <param name="id">评论Id</param>
        /// <returns></returns>
        [HttpDelete(Name = "DeleteQuestionComments")]
        public async Task<MessageModel <string> > DeleteQuestionCommentsAsync(int questionId,int id)
        {
            var entity =await _qusetionService.GetByIdAsync(questionId);
            entity.QuestionComments.Remove(entity.QuestionComments.FirstOrDefault(x => x.Id == id));
            return new MessageModel<string>() 
            {
                success = true,
                message = TipsModel.DeleteCommentSuccess,
            };
        }
    }
}
