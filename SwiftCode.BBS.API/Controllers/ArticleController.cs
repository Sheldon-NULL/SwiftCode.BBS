using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftCode.BBS.Common.Helper;
using SwiftCode.BBS.IServices;
using SwiftCode.BBS.Model;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.Model.ViewModels.Article;
using SwiftCode.BBS.Services.BASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiftCode.BBS.API.Controllers
{
    /// <summary>
    /// 文章
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _atticleService;
        private readonly BaseService<UserInfo> _userInfoService;
        private readonly IMapper _mapper;

        public ArticleController(IArticleService articleService, BaseService<UserInfo> userInfoService, IMapper mapper)
        {
            _atticleService = articleService;
            _userInfoService = userInfoService;
            _mapper = mapper;
        }
        /// <summary>
        /// 分页获取文章列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>

        [HttpGet]
        public async Task<MessageModel<List<ArticleDto>>> GetList(int page, int pageSize)
        {
            var entityList = await _atticleService.GetPageListAsync(page, pageSize, nameof(Article.CreateTime));

            var articleUserIdList = entityList.Select(x => x.CreateUserId);
            var userList = await _userInfoService.GetListAsync(x => articleUserIdList.Contains(x.Id));
            var response = _mapper.Map<List<ArticleDto>>(entityList);
            foreach (var item in response)
            {
                var user = userList.FirstOrDefault(x => x.Id == item.CreateUserId);
                item.UserName = user.UserName;
                item.HeadPortrait = user.HeadPortrait;
            }
            return new MessageModel<List<ArticleDto>>()
            {
                success = true,
                message = TipsModel.GetSuccess,
                response = response,
            };
        }
        /// <summary>
        /// 根据文章Id获取文章详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<ArticleDetailsDto>> Get(int id)
        {
            var entity = await _atticleService.GetArticleDetailsByIdAsync(id);
            var result = _mapper.Map<ArticleDetailsDto>(entity);
            return new MessageModel<ArticleDetailsDto>()
            {
                success = true,
                message = TipsModel.GetSuccess,
                response = result,
            };
        }

        /// <summary>
        /// 创建文章
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageModel<string>> CreateAsync(CreateArticleInputDto input)
        {
            var token = JwtHelper.ParsingJwtToken(HttpContext);

            var entity = _mapper.Map<Article>(input);
            entity.CreateTime = DateTime.Now;
            entity.CreateUserId = token.Uid;
            await _atticleService.InsertAsync(entity, true);

            return new MessageModel<string>()
            {
                success = true,
                message = TipsModel.CreateSucccess,
            };
        }

        /// <summary>
        /// 修改文章
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<MessageModel<string>> UpdateAsync(int id, UpdateArticleInputDto input)
        {
            var entity = await _atticleService.GetAsync(x => x.Id == id);
            entity = _mapper.Map(input, entity);
            await _atticleService.UpdateAsync(entity, true);
            return new MessageModel<string>()
            {
                success = true,
                message = TipsModel.UpdateSuccess,
            };

        }

        /// <summary>
        /// 删除文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<MessageModel<string>> DeleteAsync(int id)
        {
            var entity = await _atticleService.GetAsync(x => x.Id == id);
            await _atticleService.DeleteAsync(entity, true);
            return new MessageModel<string>
            {
                success = true,
                message = TipsModel.DeleteSuccess
            };
        }

        /// <summary>
        /// 收藏文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("{id}",Name = "CreateCollection")]
        public async Task<MessageModel<string>> CreatCollectionAsync(int id)
        {
            var token = JwtHelper.ParsingJwtToken(HttpContext);
            await _atticleService.AddArticleCollectionByIdAndUserIdAsync(id,token.Uid);
            return new MessageModel<string>()
            {
                success = true,
                message = TipsModel.CollectionSuccess,
            };
        }
        /// <summary>
        /// 添加文章评论
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateArticleComments")]
        public async Task<MessageModel <string>> CreateArticleCommentsAsync(int id,CreateArticleCommentsInputDto input)
        {
            var token = JwtHelper.ParsingJwtToken(HttpContext);
            await _atticleService.AddArticleCommentByIdAndUserIdAsync(id, token.Uid, input.Content);
            return new MessageModel<string>()
            {
                success = true,
                message = TipsModel.CommentSuccess,
            };
        }

        /// <summary>
        /// 根据文章Id和评论Id删除文章评论
        /// </summary>
        /// <param name="articleId">文章Id</param>
        /// <param name="id">评论Id</param>
        /// <returns></returns>
        [HttpDelete(Name = "DeleteArticleComments")]
        public async Task<MessageModel <string>> DeleteArticleCommentAsync(int articleId,int id)
        {
            var entity = await _atticleService.GetByIdAsync(articleId);
            entity.ArticleComments.Remove(entity.ArticleComments.FirstOrDefault(x => x.Id == id));
            await _atticleService.UpdateAsync(entity, true);

            return new MessageModel<string> ()
            { 
                success = true,
                message = TipsModel.DeleteCommentSuccess,
            };
        }
    }
}
