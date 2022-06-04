using SwiftCode.BBS.IServices.BASE;
using SwiftCode.BBS.Model.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SwiftCode.BBS.IServices
{
    /// <summary>
    /// 文章服务接口
    /// </summary>
    public interface IArticleService : IBaseService<Article>
    {
        /// <summary>
        /// 根据文章Id获取文章
        /// </summary>
        /// <param name="id">文章Id</param>
        /// <param name="cancellationToken">取消令牌（当CancelltionToken为取消状态时，内部未启动的Task任务不会开启新线程）</param>
        /// <returns></returns>
        Task<Article> GetByIdAsync(int id,CancellationToken cancellationToken = default);

        /// <summary>
        /// 功能描述：根据文章Id获取文章详情
        /// </summary>
        /// <param name="id">文章Id</param>
        /// <param name="cancellationToken">取消令牌（当CancelltionToken为取消状态时，内部未启动的Task任务不会开启新线程）</param>
        /// <returns></returns>
        Task<Article> GetArticleDetailsByIdAsync(int id,CancellationToken cancellationToken = default);

        /// <summary>
        /// 功能描述：根据文章Id和UserId来添加收藏文章
        /// </summary>
        /// <param name="id">文章Id</param>
        /// <param name="userId">用户Id</param>
        /// <param name="cancellationToken">取消令牌（当CancelltionToken为取消状态时，内部未启动的Task任务不会开启新线程）</param>
        /// <returns></returns>
        Task AddArticleCollectionByIdAndUserIdAsync(int id,int userId,CancellationToken cancellationToken = default);

        /// <summary>
        /// 功能描述：根据文章Id和UerId来添加文章评论
        /// </summary>
        /// <param name="id">w文章Id</param>
        /// <param name="userId">用户Id</param>
        /// <param name="content">文章品论</param>
        /// <param name="cancellationToken">取消令牌（当CancelltionToken为取消状态时，内部未启动的Task任务不会开启新线程）</param>
        /// <returns></returns>
        Task AddArticleCommentByIdAndUserIdAsync(int id,int userId,string content,CancellationToken cancellationToken = default);

        /// <summary>
        /// 功能描述：补录文章
        /// </summary>
        /// <param name="entity">文章实体类</param>
        /// <param name="v"></param>
        /// <param name="n">天数</param>
        /// <returns></returns>
        Task AdditionalItemAsync(Article entity, bool v, int n = 0);

    }
}
