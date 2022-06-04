using Microsoft.EntityFrameworkCore;
using SwiftCode.BBS.EntityFramework;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.Repositories.BASE;
using SwitfCode.BBS.IRepositories;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Repositories
{
    public class AtricleRepository : BaseRepository<Article>, IArticleRepository
    {
        public AtricleRepository(SwiftCodeBbsDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// 功能描述：根据Id查找有评论且有作者的文章
        /// </summary>
        /// <param name="id">文章Id</param>
        /// <param name="cancellationToken">取消令牌（当CancellatiuonToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        public Task<Article> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return DbContext().Articles.Where(x => x.Id == id)
                .Include(x => x.ArticleComments).ThenInclude(x => x.CreateUser).SingleOrDefaultAsync(cancellationToken);
        }

        /// <summary>
        /// 功能描述：根据Id查找有收藏的文章
        /// </summary>
        /// <param name="id">文章Id</param>
        /// <param name="cancellationToken">取消令牌（当CancellatiuonToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        public Task<Article> GetCollectionArticleByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return DbContext().Articles.Where(x => x.Id == id)
                .Include(x => x.CollectionArticles).SingleOrDefaultAsync(cancellationToken);
        }
    }
}
