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
    /// 问答服务实现类
    /// </summary>
    public class QuestionService : BaseService<Question>, IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IBaseRepository<Question> baseRepository, IQuestionRepository questionRepository) : base(baseRepository)
        {
            _questionRepository = questionRepository;
        }

        /// <summary>
        /// 功能描述：根据问答Id和用户Id添加问答
        /// </summary>
        /// <param name="id">文章Id</param>
        /// <param name="userId">用户Id</param>
        /// <param name="content">问答内容</param>
        /// <param name="cancellationToken">取消令牌（当CancellatiuonToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        public async Task AddQusetionCommentAsync(int id, int userId, string content, CancellationToken cancellationToken = default)
        {
            var entity = await _questionRepository.GetByIdAsync(id, cancellationToken);
            entity.QuestionComments.Add(new QuestionComment
            {
                CreateUserId = userId,
                Content = content,
                CreateTime = DateTime.Now,
            });

            await _questionRepository.UpdateAsync(entity, true, cancellationToken);
        }

        /// <summary>
        /// 功能描述：根据问答Id获取问答内容
        /// </summary>
        /// <param name="id">问答Id</param>
        /// <param name="cancellationToken">取消令牌（当CancellatiuonToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        public async Task<Question> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _questionRepository.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// 功能描述：根据问答Id获取问答详情
        /// </summary>
        /// <param name="id">问答Id</param>
        /// <param name="cancellationToken">取消令牌（当CancellatiuonToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        public async Task<Question> GetQuestionDetailsAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _questionRepository.GetByIdAsync(id, cancellationToken);
            entity.Traffic += 1;

            await _questionRepository.UpdateAsync(entity, true, cancellationToken: cancellationToken);

            return entity;
        }
    }
}
