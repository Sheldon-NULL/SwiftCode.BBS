using Microsoft.EntityFrameworkCore;
using SwiftCode.BBS.EntityFramework;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.Repositories.BASE;
using SwitfCode.BBS.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Repositories
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(SwiftCodeBbsDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// 功能描述：根据问答Id查找有评论、有发表人的问答内容
        /// </summary>
        /// <param name="id">问答Id</param>
        /// <param name="cancellationToken">取消令牌（当CancelltionToken为取消状态时，内部未启动的Task任务不会开启新线程）</param>
        /// <returns></returns>
        public Task<Question> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return DbContext().Questions.Where(x => x.Id == id)
                .Include(x => x.QuestionComments).ThenInclude(x => x.CreateUser).SingleOrDefaultAsync(cancellationToken);
        }
    }
}
