using SwiftCode.BBS.Model.Model.RootTKey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Model.Models
{
    /// <summary>
    /// 用户文章收藏表
    /// </summary>
    public class UserCollectionArticle : RootEntityTKey<int>
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 文章Id
        /// </summary>
        public int ArticleId { get; set; }
    }
}
