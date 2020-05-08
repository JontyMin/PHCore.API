using System.Collections.Generic;

namespace PH.Entities
{       
    using Entities.Core;
    /// <summary>
    /// 文章类型表
    /// </summary>
    public class ArticleCategory:IEntity
    {
        /// <summary>
        /// 文章id
        /// </summary>
        public long ArticleId { get; set; }
        /// <summary>
        /// 类型id
        /// </summary>
        public long CategoryId { get; set; }

        public IEnumerable<Article> Article { get; set; }

        public IEnumerable<Category> Category { get; set; }
    }
}