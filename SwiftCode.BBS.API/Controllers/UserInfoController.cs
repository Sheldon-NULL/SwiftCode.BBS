using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftCode.BBS.Common.Helper;
using SwiftCode.BBS.IServices;
using SwiftCode.BBS.IServices.BASE;
using SwiftCode.BBS.Model;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.Model.ViewModels.UserInfo;
using SwiftCode.BBS.Services;
using System.Threading.Tasks;

namespace SwiftCode.BBS.API.Controllers
{
    /// <summary>
    /// 个人中心
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserInfoController : ControllerBase
    {
        private readonly IBaseService<UserInfo> _unserInfoService;
        private readonly IMapper _mapper;
        private readonly IArticleService _articleService;
        private readonly IBaseService<Question> _questionService;

        public UserInfoController(IBaseService<UserInfo> unserInfoService,IMapper mapper,IArticleService articleService,IBaseService<Question> questionService)
        {
            _unserInfoService = unserInfoService;
            _mapper = mapper;
            _articleService = articleService;
            _questionService = questionService;
        }
        /// <summary>
        /// 获取用户个人信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel <UserInfoDetailsDto> > GetAsync()
        {
            var token = JwtHelper.ParsingJwtToken(HttpContext);
            var userInfo = await _unserInfoService.GetAsync(x => x.Id == token.Uid);

            return new MessageModel<UserInfoDetailsDto>()
            {
                success = true,
                message = TipsModel.GetSuccess,
                response = _mapper.Map<UserInfoDetailsDto>(userInfo),
            };
        }

        /// <summary>
        /// 修改个人信息
        /// </summary>
        /// <param name="input">要修改的个人信息</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<MessageModel <string> > UpdateAsync(UpdateUserInfoInputDto input)
        {
            var token = JwtHelper.ParsingJwtToken(HttpContext);
            var userInfo = await _unserInfoService.GetAsync(x => x.Id == token.Uid);
            userInfo = _mapper.Map<UserInfo>(input);
            await _unserInfoService.UpdateAsync(userInfo, true);

            return new MessageModel<string>()
            {
                success = true,
                message = TipsModel.UpdateSuccess,
            };
        }

        /// <summary>
        /// 获取文章作者
        /// </summary>
        /// <param name="id">文章Id</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel <UserInfoDto> > GetAuthor(int id)
        {
            var entity = await _articleService.GetAsync(x => x.Id == id);
            var user = await _unserInfoService.GetAsync(x => x.Id == entity.CreateUserId);
            var respone = _mapper.Map<UserInfoDto>(user);
            respone.ArticlesCount = await _articleService.GetCountAsync(x => x.CreateUserId == user.Id);
            respone.QuestionsCount = await _questionService.GetCountAsync(x => x.CreateUserId == user.Id);
            return new MessageModel<UserInfoDto>()
            {
                success = true,
                message = TipsModel.GetSuccess,
                response = respone,
            };
        }
    }
}
