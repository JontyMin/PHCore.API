using System.ComponentModel.DataAnnotations;

namespace PH.Models.ViewModel
{
    using DbContexts;
    using UnitOfWork.UnitOfWork;
    using WebCore.Core;
    using Entities;

    public class TagViewModel
    {
        public long Id { get; set; }
        [Display(Name = "标签名")]
        [Required(ErrorMessage = "{0}必填")]
        [StringLength(16, ErrorMessage = "不能超过{0}个字符")]
        [RegularExpression(@"^[a-zA-Z0-9_]{4,16}$", ErrorMessage = "只能包含字符、数字和下划线")]
        public string TagName { get; set; }
        [Display(Name = "标签名")]
        [Required(ErrorMessage = "{0}必填")]
        [StringLength(50, ErrorMessage = "不能超过{0}个字符")]
        public string DisplayName { get; set; }
        [Display(Name = "备注")]
        [StringLength(4000, ErrorMessage = "不能超过{0}个字符")]
        public string Description { get; set; }


        public ExecuteResult CheckField(ExecuteType executeType, IUnitOfWork<PHDbContext> unitOfWork)
        {
            ExecuteResult result = new ExecuteResult();
            var repo = unitOfWork.GetRepository<Tag>();

            //不是新增，先检查角色是否存在
            if (executeType !=ExecuteType.Create && !repo.Exists(a=>a.Id==Id))
            {
                return result.SetFailMessage("标签不存在");
            }

            //针对不同的操作，检查逻辑不同
            switch (executeType)
            {
                case ExecuteType.Delete:
                    // 先检查是否有文章使用该标签
                    if (unitOfWork.GetRepository<ArticleTag>().Exists(a=>a.TagId==Id))
                    {
                        return result.SetFailMessage("此标签正在使用");
                    }

                    break;
                case ExecuteType.Update:
                    // 如果存在ID不同，标签名相同的实体，则返回报错
                    if (repo.Exists(a=>a.TagName==TagName && a.Id!=Id))
                    {
                        return result.SetFailMessage($"已存在相同的标签名称：{TagName}");
                    }

                    break;
                case ExecuteType.Create:
                    default:
                    //如果存在相同的标签名则返回报错
                    if (repo.Exists(a=>a.TagName==TagName))
                    {
                        return result.SetFailMessage($"已存在相同的标签名称：{TagName}");
                    }
                    break;
            }

            return result;//没有错误，默认返回成功
        }
    }
}
