using SwiftCode.BBS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SwiftCode.BBS.Model.ViewModels.Article
{
    /// <summary>
    /// 文章评论Dto
    /// </summary>
    public class ArticleCommentDto : RootEntityTkey<int>
    {
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        public int CreateUserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string HeadPortrait { get; set; }
    }
}
