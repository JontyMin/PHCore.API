namespace PH.Entities
{
    using Entities.Core;
    /// <summary>
    /// 文章表
    /// </summary>
    public class Article:BaseEntity
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 文章标题
        /// </summary>
        public string ArtTitle { get; set; }
        /// <summary>
        /// 文章内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 浏览量
        /// </summary>
        public int Views { get; set; }
        /// <summary>
        /// 评论数
        /// </summary>
        public int ArtComCount { get; set; }
        /// <summary>
        /// 点赞数
        /// </summary>
        public int ArtLikeCount { get; set; }

        public User User { get; set; }
    }
}