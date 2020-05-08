using AutoMapper;

namespace PH.Services
{
    using Common.IDCode.Snowflake;
    using DbContexts;
    using UnitOfWork.UnitOfWork;
    public interface IBaseService
    {
    }
    public class BaseService : IBaseService
    {
        public readonly IUnitOfWork<PHDbContext> _unitOfWork;
        public readonly IMapper _mapper;
        public readonly IdWorker _idWorker;

        public BaseService(IUnitOfWork<PHDbContext> unitOfWork, IMapper mapper, IdWorker idWorker)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _idWorker = idWorker;
        }
    }
}
