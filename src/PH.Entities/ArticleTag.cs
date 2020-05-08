namespace PH.Entities
{
    using Entities.Core;
    /// <summary>
    /// 文章标签表
    /// </summary>
    public class ArticleTag:IEntity
    {
        /// <summary>
        /// 文章id
        /// </summary>
        public long ArticleId { get; set; }
        /// <summary>
        /// 标签id
        /// </summary>
        public long TagId { get; set;}

        public Article Article { get; set; }

        public Tag Tag { get; set; }
    }
}