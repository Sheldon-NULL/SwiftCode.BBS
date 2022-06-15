using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SwiftCode.BBS.Common.Helper;
using SwiftCode.BBS.IServices.BASE;
using SwiftCode.BBS.Model;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.Model.ViewModels.UserInfo;
using System;
using System.Threading.Tasks;

namespace SwiftCode.BBS.API.Controllers
{
    /// <summary>
    /// 授权
    /// </summary>
    [Route("api/{controller}/{action}")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IBaseService<UserInfo> _userInfoService;
        private readonly IMapper _mapper;

        public AuthController(IBaseService<UserInfo> userInfoService,IMapper mapper)
        {
            _userInfoService = userInfoService;
            _mapper = mapper;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="loginPassword"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel <string>> Login(string loginName,string loginPassword)
        {
            var jwtStr = string.Empty;

            if (string.IsNullOrEmpty(loginName) || string.IsNullOrEmpty(loginPassword))
            {
                return new MessageModel<string>
                {
                    success = false,
                    message = TipsModel.NameOrPasswordNull,
                };
            }

            var pass = MD5Helper.MD5Encrypt32(loginPassword);
            var userInfo = await _userInfoService.FindAsync(x => x.LoginName == loginName && x.LoginPassWord == pass);
            if (userInfo is null)
            {
                return new MessageModel<string>
                {
                    success = false,
                    message = TipsModel.AccountNotFound,
                };
            }

            jwtStr = GetUserJwt(userInfo);
            return new MessageModel<string>
            {
                success = true,
                message = TipsModel.GetSuccess,
                response = jwtStr,
            };
            
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageModel 
            <string> > Register(CreateUserInfoInputDto input)
        {
            var userInfo = await _userInfoService.FindAsync(x => x.LoginName == input.LoginName);
            if (userInfo is not null)
            {
                return new MessageModel<string> {
                    success = false,
                    message = TipsModel.AccountExist };
            }
            userInfo = await _userInfoService.FindAsync(x => x.Email == input.Email);
            if (userInfo is not null)
            {
                return new MessageModel<string>
                {
                    success = false,
                    message = TipsModel.EmailExist,
                };
            }

            userInfo = await _userInfoService.FindAsync(x => x.Phone == input.Phone);
            if (userInfo is not null)
            {
                return new MessageModel<string>
                {
                    success = false,
                    message = TipsModel.PhoneExist,
                };
            }

            userInfo = await _userInfoService.FindAsync(x => x.LoginName == input.LoginName);
            if (userInfo is not null)
            {
                return new MessageModel<string>
                {
                    success = false,
                    message = TipsModel.NameExist,
                };
            }
            input.LoginPassWord = MD5Helper.MD5Encrypt32(input.LoginPassWord);
            var user = _mapper.Map<UserInfo>(input);
            user.CreateTime = DateTime.Now;
            await _userInfoService.InsertAsync(user, true);
            var jwtStr = GetUserJwt(user);
            return new MessageModel<string>
            {
                success = true,
                message = TipsModel.RegistSuccess,
                response = jwtStr,
            };

        }

        private string GetUserJwt(UserInfo userInfo)
        {
            var tokenModel = new TokenModelJwt { Uid = userInfo.Id, Role = "User" };
            var jwtStr = JwtHelper.IssueJwt(tokenModel);
            return jwtStr;
        }
    }
}
