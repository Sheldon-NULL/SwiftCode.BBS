using SwiftCode.BBS.Model.Models;
using SwitfCode.BBS.IRepositories.BASE;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SwitfCode.BBS.IRepositories
{
    /// <summary>
    /// 文章仓储接口
    /// </summary>
    public interface IArticleRepository : IBaseRepository<Article>
    {
        /// <summary>
        /// 功能描述：根据id查找文章
        /// </summary>
        /// <param name="id">文章id</param>
        /// <param name="cancellationToken">取消令牌（当Cancellation是取消状态时，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        Task<Article> GetByIdAsync(int id,CancellationToken cancellationToken = default);

        /// <summary>
        /// 功能描述：根据id查找收藏文章
        /// </summary>
        /// <param name="id">文章id</param>
        /// <param name="cancellationToken">取消令牌（当Cancellation是取消状态时，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        Task<Article> GetCollectionArticleByIdAsync(int id,CancellationToken cancellationToken = default);
    }
}
