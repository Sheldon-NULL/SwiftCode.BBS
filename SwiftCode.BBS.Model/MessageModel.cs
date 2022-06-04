using System;
using System.Collections.Generic;

namespace SwiftCode.BBS.Model
{
    /// <summary>
    /// 负责返回通用信息类
    /// </summary>
    public class MessageModel<T>
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int status { get; set; } = 200;

        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool success { get; set; } = false;

        /// <summary>
        /// 返回信息
        /// </summary>
        public string message { get; set; } = "服务器异常";

        /// <summary>
        /// 返回数据集合
        /// </summary>
        public T response { get; set; }
    }


}
