namespace PH.Entities
{
    using Entities.Core;
    public class Tag:IEntity
    {
        /// <summary>
        /// 标签id
        /// </summary>
        public long Tid { get; set; }
        /// <summary>
        /// 标签名
        /// </summary>
        public string TagName { get; set; }
        /// <summary>
        /// 别名
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }
}