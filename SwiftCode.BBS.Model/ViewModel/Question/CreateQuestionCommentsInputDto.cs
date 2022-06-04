using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Model.ViewModels.Question
{
    /// <summary>
    /// 创建问答评论Dto
    /// </summary>
    public class CreateQuestionCommentsInputDto
    {
        /// <summary>
        /// 评论内容
        /// </summary>
        public string Content { get; set; }
    }
}
