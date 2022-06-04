﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftCode.BBS.Model.Models;

namespace SwiftCode.BBS.Model.ViewModels.UserInfo
{
    /// <summary>
    /// 个人信息Dto
    /// </summary>
    public class UserInfoDto : RootEntityTkey<int>
    {

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string HeadPortrait { get; set; }
        /// <summary>
        /// 文章数量
        /// </summary>
        public long ArticlesCount { get; set; }
        /// <summary>
        /// 问答数量
        /// </summary>
        public long QuestionsCount { get; set; }


    }
}
