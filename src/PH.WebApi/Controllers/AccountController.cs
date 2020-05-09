using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PH.Component.Jwt.UserClaim;
using PH.WebCore.Core;

namespace PH.WebApi.Controllers
{
    using Models.ViewModel;
    using Services.Account;

    /// <summary>
    /// 登录认证
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class AccountController : AuthorizeController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ExecuteResult<UserData>> Login(LoginViewModel viewModel)
        {
            return await _accountService.Login(viewModel);
        }
    }
}