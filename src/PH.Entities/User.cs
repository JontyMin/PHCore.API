namespace PH.Entities
{
    using Entities.Core;
    /// <summary>
    /// 用户表
    /// </summary>
    public class User:BaseEntity
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 座右铭
        /// </summary>
        public string Motto { get; set; }
    }
}
