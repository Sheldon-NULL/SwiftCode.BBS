using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Model
{
    /// <summary>
    /// 表格数据，支持分页
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TableModel<T>
    {
        /// <summary>
        /// 返回编码
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 返回总数
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 返回数据集
        /// </summary>
        public List<T> Data { get; set; }
    }
}
