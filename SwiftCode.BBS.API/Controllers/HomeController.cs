using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftCode.BBS.IServices.BASE;
using SwiftCode.BBS.Model;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.Model.ViewModels.Article;
using SwiftCode.BBS.Model.ViewModels.Question;
using SwiftCode.BBS.Model.ViewModels.UserInfo;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiftCode.BBS.API.Controllers
{
    /// <summary>
    /// 主页
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IBaseService<UserInfo> _userInfoService;
        private readonly IBaseService<Article> _articleService;
        private readonly IBaseService<Question> _questionService;
        private readonly IBaseService<Advertisement> _advertisementService;
        private readonly IMapper _mapper;

        public HomeController(
            IBaseService<UserInfo> userInfoService,
            IBaseService<Article> articleService,
            IBaseService<Question> questionService,
            IBaseService<Advertisement> advertisementService
            ,IMapper mapper)
        {
            _userInfoService = userInfoService;
            _articleService = articleService;
            _questionService = questionService;
            _advertisementService = advertisementService;
            _mapper = mapper;
        }

        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel< List<ArticleDto> > > GetArticle()
        {
            var entityList = await _articleService.GetPageListAsync(0, 10, nameof(Article.CreateTime));
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
        /// 获取问答列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel <List <QuestionDto> > > GetQuestion()
        {
            var questionList = await _questionService.GetPageListAsync(0, 10, nameof(Question.CreateTime));
            var response = _mapper.Map<List <QuestionDto> > (questionList);
            return new MessageModel<List<QuestionDto>>()
            {
                success = true,
                message = TipsModel.GetSuccess,
                response = response,
            };
        }

        /// <summary>
        /// 获取作者列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel <List <UserInfoDto> > > GetUserInfo()
        {
            var userInfoList = await _userInfoService.GetPageListAsync(0, 5, nameof(UserInfo.CreateTime));
            var response = _mapper.Map<List<UserInfoDto>>(userInfoList);
            foreach (var item in response)
            {
                item.QuestionsCount =await _questionService.GetCountAsync(x => x.CreateUserId == item.Id);
                item.ArticlesCount = await _articleService.GetCountAsync(x => x.CreateUserId == item.Id);
            }
            return new MessageModel<List <UserInfoDto>>()
            {
                success = true,
                message = TipsModel.GetSuccess,
                response = response,
            };
        }

        /// <summary>
        /// 获取广告列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel <List <Advertisement> > > GetAdvertisement()
        {
            var advertisementList = await _advertisementService.GetPageListAsync(0,10,nameof(Advertisement.CreateTime));
            var response = _mapper.Map<List<Advertisement>>(advertisementList);
            return new MessageModel<List<Advertisement>>()
            {
                success = true,
                message = TipsModel.GetSuccess,
                response = response,
            };
        }
    }
}
