using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PH.WebApi.Controllers
{
    using WebCore.Core;
    using Models.ViewModel;
    using Services;

    [Route("[controller]")]
    [ApiController]
    public class TagController : AuthorizeController
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        /// <summary>
        /// 添加标签
        /// </summary>
        /// <param name="tagViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ExecuteResult> Post(TagViewModel tagViewModel)
        {
            return await _tagService.Create(tagViewModel);
        }
        /// <summary>
        /// 修改标签
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ExecuteResult> Put(TagViewModel viewModel)
        {
            return await _tagService.Update(viewModel);
        }
        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ExecuteResult> Delete(long id)
        {
            return await _tagService.Delete(new TagViewModel { Id = id });
        }
    }
}