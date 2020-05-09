using AutoMapper;
using Microsoft.Extensions.Localization;

namespace PH.Services
{
    using Common.IDCode.Snowflake;
    using DbContexts;
    using UnitOfWork.UnitOfWork;
    using Component.Jwt.UserClaim;
    public interface IBaseService
    {
    }
    public class BaseService : IBaseService
    {
        public readonly IUnitOfWork<PHDbContext> _unitOfWork;
        public readonly IMapper _mapper;
        public readonly IdWorker _idWorker;
        public readonly IClaimsAccessor _claimsAccessor;
        public readonly IStringLocalizer _localizer;

        public BaseService(IUnitOfWork<PHDbContext> unitOfWork, IMapper mapper, IdWorker idWorker, IClaimsAccessor claimsAccessor, IStringLocalizer localizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _idWorker = idWorker;
            _claimsAccessor = claimsAccessor;
            _localizer = localizer;
        }
    }
}
