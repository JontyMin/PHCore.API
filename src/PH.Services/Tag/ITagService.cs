using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PH.Services
{
    using Entities;
    using Models.ViewModel;
    using WebCore.Core;
    public interface ITagService:IBaseService
    {
        Task<ExecuteResult<Tag>> Create(TagViewModel viewModel);
        Task<ExecuteResult> Update(TagViewModel viewModel);
        Task<ExecuteResult> Delete(TagViewModel viewModel);
    }
}
