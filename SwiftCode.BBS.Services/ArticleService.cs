using SwiftCode.BBS.IServices;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.Services.BASE;
using SwitfCode.BBS.IRepositories;
using SwitfCode.BBS.IRepositories.BASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Services
{
    /// <summary>
    /// 文章服务实现类
    /// </summary>
    public class ArticleService : BaseService<Article>, IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IBaseRepository<Article> baseRepository,IArticleRepository articleRepository) : base(baseRepository)
        {
            _articleRepository = articleRepository;
        }

        /// <summary>
        /// 功能描述：根据文章Id和UserId
        /// </summary>
        /// <param name="id">文章Id</param>
        /// <param name="userId">用户Id</param>
        /// <param name="cancellationToken">取消令牌（当CancelltionToken为取消状态时，内部未启动的Task任务不会开启新线程）</param>
        /// <returns></returns>
        public async Task AddArticleCollectionByIdAndUserIdAsync(int id, int userId, CancellationToken cancellationToken = default)
        {
            var entity = await _articleRepository.GetByIdAsync(id,cancellationToken);
            entity.CollectionArticles.Add( new UserCollectionArticle()
            {
                ArticleId = id,
                UserId = userId,
            });
            
            await _articleRepository.UpdateAsync(entity,true,cancellationToken);
        }

        /// <summary>
        /// 功能描述：根据文章Id和UserId来添加文章评论
        /// </summary>
        /// <param name="id">文章Id</param>
        /// <param name="userId">用户Id</param>
        /// <param name="content">评论内容</param>
        /// <param name="cancellationToken">取消令牌（当CancelltionToken为取消状态时，内部未启动的Task任务不会开启新线程）</param>
        /// <returns></returns>
        public async Task AddArticleCommentByIdAndUserIdAsync(int id, int userId,string content, CancellationToken cancellationToken = default)
        {
            var entity = await _articleRepository.GetByIdAsync(id,cancellationToken);

            entity.ArticleComments.Add(new ArticleComment()
            {
                ArticleId = id,
                CreateUserId = userId,
                CreateTime = DateTime.Now, 
            });

            await _articleRepository.UpdateAsync(entity,true,cancellationToken);
        }
        /// <summary>
        /// 功能描述：补录文章
        /// </summary>
        /// <param name="entity">文章实体类</param>
        /// <param name="v"></param>
        /// <param name="n">时间天数</param>
        /// <returns></returns>
        public async Task AdditionalItemAsync(Article entity, bool v, int n = 0)
        {
           entity.CreateTime = DateTime.Now.AddDays(-n);
           await _articleRepository.InsertAsync(entity,true);
        }

        /// <summary>
        /// 功能描述：根据文章Id获取文章详细内容
        /// </summary>
        /// <param name="id">文章Id</param>
        /// <param name="cancellationToken">取消令牌（当CancellatiuonToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        public async Task<Article> GetArticleDetailsByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity =  await _articleRepository.GetByIdAsync(id, cancellationToken);
            entity.Traffic++;
            await _articleRepository.UpdateAsync(entity,true,cancellationToken);
            return entity;
        }

        /// <summary>
        /// 功能描述：根据文章Id获取文章
        /// </summary>
        /// <param name="id">文章</param>
        /// <param name="cancellationToken">取消令牌（当CancellatiuonToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        public async Task<Article> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _articleRepository.GetByIdAsync(id,cancellationToken);
        }
    }
}
