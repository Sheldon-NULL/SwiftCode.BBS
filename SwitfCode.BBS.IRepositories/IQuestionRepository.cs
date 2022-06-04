using SwiftCode.BBS.Model.Models;
using SwitfCode.BBS.IRepositories.BASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SwitfCode.BBS.IRepositories
{
    /// <summary>
    /// 问答仓储接口
    /// </summary>
    public interface IQuestionRepository : IBaseRepository <Question>
    {
        /// <summary>
        /// 功能评论：根据问答Id查找问答内容
        /// </summary>
        /// <param name="id">问答Id</param>
        /// <param name="cancellationToken">取消令牌（当CancelltionToken为取消状态时，内部未启动的Task任务不会开启新线程）</param>
        /// <returns></returns>
        Task<Question> GetByIdAsync(int id,CancellationToken cancellationToken = default);
    }
}
