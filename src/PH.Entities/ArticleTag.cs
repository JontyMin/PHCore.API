namespace PH.Entities
{
    public class ArticleTag
    {
        /// <summary>
        /// 文章类型表
        /// </summary>
        public long id { get; set; }
        /// <summary>
        /// 文章id
        /// </summary>
        public long ArticleId { get; set; }
        /// <summary>
        /// 标签id
        /// </summary>
        public long TagId { get; set;}
    }
}