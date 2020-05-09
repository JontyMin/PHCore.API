using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

namespace PH.Services.Account
{
    using Component.Jwt;
    using Common.IDCode.Snowflake;
    using Component.Jwt.UserClaim;
    using DbContexts;
    using Models.ViewModel;
    using UnitOfWork.UnitOfWork;
    using WebCore;
    using WebCore.Core;
    using Component.Jwt.UserClaim;
    public class AccountService : BaseService, IAccountService
    {
        private readonly JwtService _jwtService;
        private readonly SiteSetting _siteSetting;

        public AccountService(JwtService jwtService, IOptions<SiteSetting> options, IUnitOfWork<PHDbContext> unitOfWork, IMapper mapper, IdWorker idWorker,IClaimsAccessor claimsAccessor, IStringLocalizer localizer) : base(unitOfWork, mapper, idWorker, claimsAccessor, localizer)
        {
            _jwtService = jwtService;
            _siteSetting = options.Value;
        }

        public async Task<ExecuteResult<UserData>> Login(LoginViewModel viewModel)
        {
            var result = await viewModel.LoginValidate(_unitOfWork, _mapper, _siteSetting, _localizer);
            if (result.IsSucceed)
            {
                result.Result.Token = _jwtService.BuildToken(_jwtService.BuildClaims(result.Result));
                return new ExecuteResult<UserData>(result.Result);
            }
            else
            {
                return new ExecuteResult<UserData>(result.Message);
            }
        }
    }
}
