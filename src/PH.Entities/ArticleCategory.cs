namespace PH.Entities
{
    public class ArticleCategory
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
        /// 类型id
        /// </summary>
        public long CategoryId { get; set; }
    }
}