using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Model.Model.RootTKey
{
    /// <summary>
    /// 泛型主键类
    /// </summary>
    /// <typeparam name="Tkey"></typeparam>
    public class RootEntityTKey<Tkey> where Tkey : IEquatable<Tkey>
    {
        /// <summary>
        /// 泛型主键
        /// </summary>
        public Tkey Id { get; set; }
    }
}
