using System;

namespace PH.Entities.Core
{
    //没有Id主键的实体继承这个
    public interface IEntity
    {
    }
    //有Id主键的实体继承这个
    public abstract class BaseEntity : IEntity
    {
        public long Id { get; set; }
        public StatusCode StatusCode { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        public long? Creator { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        public long? Modifier { get; set; }
        public DateTime? ModifyTime { get; set; }
    }
}
