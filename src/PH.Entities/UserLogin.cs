using System;

namespace PH.Entities
{
    using Entities.Core;
    public class UserLogin:IEntity
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 哈希密码
        /// </summary>
        public string HashedPassword { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? LastLoginTime { get; set; }
        /// <summary>
        /// 登陆失败次数
        /// </summary>
        public int AccessFailedCount { get; set; }
        /// <summary>
        /// 是否锁定
        /// </summary>
        public bool IsLocked { get; set; }
        /// <summary>
        /// 多顶时间
        /// </summary>
        public DateTime? LockedTime { get; set; }

        public User User { get; set; }
    }
}