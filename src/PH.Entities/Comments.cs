namespace PH.Entities
{
    using Entities.Core;
    /// <summary>
    /// 评论表
    /// </summary>
    public class Comments:IEntity
    {
        /// <summary>
        /// 评论id
        /// </summary>
        public long ComId { get; set; }
        /// <summary>
        /// 发表用户Id
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 评论文章id
        /// </summary>
        public long ArticleId { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        public string ComText { get; set; }
        /// <summary>
        /// 父评论
        /// </summary>
        public long ParentComId { get; set; }
    }
}