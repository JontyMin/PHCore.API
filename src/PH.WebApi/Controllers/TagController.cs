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
    [Route("[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        [HttpPost]
        public async Task<ExecuteResult> Post(TagViewModel tagViewModel)
        {
            return new ExecuteResult();
        }
    }
}