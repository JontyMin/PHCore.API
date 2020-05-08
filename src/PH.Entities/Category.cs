namespace PH.Entities
{
    using Entities.Core;
    /// <summary>
    /// 分类表
    /// </summary>
    public class Category:BaseEntity
    {
        /// <summary>
        /// 类型名称
        /// </summary>
        public string CatName { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }
}