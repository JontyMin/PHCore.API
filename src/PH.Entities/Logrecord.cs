using System;

namespace PH.Entities
{
    using Core;

    /// <summary>
    /// 日志表
    /// </summary>
    public class Logrecord : IEntity
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 日志日期
        /// </summary>
        public DateTime LogDate { get; set; }
        /// <summary>
        /// 日志等级
        /// </summary>
        public string LogLevel { get; set; }
        /// <summary>
        /// 记录器
        /// </summary>
        public string Logger { get; set; }
        /// <summary>
        /// 信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 异常
        /// </summary>
        public string Exception { get; set; }
        /// <summary>
        /// 机器名
        /// </summary>
        public string MachineName { get; set; }
        /// <summary>
        /// 机器Ip
        /// </summary>
        public string MachineIp { get; set; }
        /// <summary>
        /// 请求方法
        /// </summary>
        public string NetRequestMethod { get; set; }
        /// <summary>
        /// 请求url
        /// </summary>
        public string NetRequestUrl { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string NetUserIdentity { get; set; }
    }
}
