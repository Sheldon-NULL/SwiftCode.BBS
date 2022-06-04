using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Model.ViewModels.Article
{
    /// <summary>
    /// 创建文章评论Dto
    /// </summary>
    public class CreateArticleCommentsInputDto
    {
        /// <summary>
        /// 评论内容
        /// </summary>
        public string Content { get; set; }

    }
}
