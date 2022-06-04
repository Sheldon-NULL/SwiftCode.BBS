using SwiftCode.BBS.IServices.BASE;
using SwiftCode.BBS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SwiftCode.BBS.IServices
{
    /// <summary>
    /// 问答服务接口
    /// </summary>
    public interface IQuestionService :IBaseService<Question>
    {
        /// <summary>
        /// 功能描述：根据问答Id获取问答内容
        /// </summary>
        /// <param name="id">问答Id</param>
        /// <param name="cancellationToken">取消令牌（当CancellatiuonToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        Task<Question> GetByIdAsync(int id,CancellationToken cancellationToken = default);

        /// <summary>
        /// 功能描述：根据问答Id获取问答详情
        /// </summary>
        /// <param name="id">问答Id</param>
        /// <param name="cancellationToken">取消令牌（当CancellatiuonToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        Task<Question> GetQuestionDetailsAsync(int id,CancellationToken cancellationToken = default);

        /// <summary>
        /// 功能描述：根据问答Id和用户Id添加问答内容
        /// </summary>
        /// <param name="id">问答Id</param>
        /// <param name="userId">用户Id</param>
        /// <param name="content">文字内容</param>
        /// <param name="cancellationToken">取消令牌（当CancellatiuonToken是取消状态，Task内部未启动的任务不会启动新线程）</param>
        /// <returns></returns>
        Task AddQusetionCommentAsync(int id,int userId,string content,CancellationToken cancellationToken = default);
       
    }
}
