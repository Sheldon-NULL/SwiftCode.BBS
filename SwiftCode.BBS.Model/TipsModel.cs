using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Model
{
    /// <summary>
    /// 统一提示类
    /// </summary>
    public static class TipsModel
    {
        /// <summary>
        /// 
        /// </summary>
        public static string NameOrPasswordNull { get; } = "用户名或密码不能为空";
        /// <summary>
        /// 
        /// </summary>
        public static string AccountNotFound { get; } = "认证失败";
        /// <summary>
        /// 
        /// </summary>
        public static string GetSuccess { get; } = "获取成功";
        /// <summary>
        /// 
        /// </summary>
        public static string AccountExist { get; } = "账户已存在";
        /// <summary>
        /// 
        /// </summary>
        public static string EmailExist { get; } = "邮箱已存在";
        /// <summary>
        /// 
        /// </summary>
        public static string PhoneExist { get; } = "电话号码已存在";
        /// <summary>
        /// 
        /// </summary>
        public static string NameExist { get; } = "用户名已注册";
        /// <summary>
        /// 
        /// </summary>
        public static string RegistSuccess { get; } = "注册成功";
        /// <summary>
        /// 
        /// </summary>
        public static string CreateSucccess { get; } = "创建成功";
        /// <summary>
        /// 
        /// </summary>
        public static string UpdateSuccess { get; } = "修改成功";
        /// <summary>
        /// 
        /// </summary>
        public static string DeleteSuccess { get; } = "删除成功";
        /// <summary>
        /// 
        /// </summary>
        public static string CollectionSuccess { get; } = "收藏成功";
        /// <summary>
        /// 
        /// </summary>
        public static string CommentSuccess { get; } = "评论成功";
        /// <summary>
        /// 
        /// </summary>
        public static string DeleteCommentSuccess { get; } = "删除评论成功";
    }
}
