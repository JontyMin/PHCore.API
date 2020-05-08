namespace PH.Entities
{
    using Entities.Core;
    /// <summary>
    /// 标签表
    /// </summary>
    public class Tag:BaseEntity
    {
        
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