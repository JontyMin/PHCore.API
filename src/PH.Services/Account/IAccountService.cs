using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PH.Component.Jwt.UserClaim;
using PH.WebCore.Core;

namespace PH.Services.Account
{
    using Models.ViewModel;
    public interface IAccountService : IBaseService
    {
        Task<ExecuteResult<UserData>> Login(LoginViewModel viewModel);
    }
}
