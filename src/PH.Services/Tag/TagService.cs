using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Localization;

namespace PH.Services
{
    using Common.IDCode.Snowflake;
    using DbContexts;
    using Entities;
    using Models.ViewModel;
    using UnitOfWork.UnitOfWork;
    using WebCore.Core;
    using Component.Jwt.UserClaim;
    public class TagService:BaseService,ITagService
    {
        public TagService(IUnitOfWork<PHDbContext> unitOfWork, IMapper mapper, IdWorker idWorker,IClaimsAccessor claimsAccessor, IStringLocalizer localizer) : base(unitOfWork, mapper, idWorker, claimsAccessor, localizer)
        {
        }

        public async  Task<ExecuteResult<Tag>> Create(TagViewModel viewModel)
        {
            ExecuteResult<Tag> result=new ExecuteResult<Tag>();
            //检查字段
            if (viewModel.CheckField(ExecuteType.Create, _unitOfWork) is ExecuteResult checkResult && !checkResult.IsSucceed)
            {
                return result.SetFailMessage(checkResult.Message);
            }
            using (var tran = _unitOfWork.BeginTransaction())//开启一个事务
            {
                Tag newRow = _mapper.Map<Tag>(viewModel);
                newRow.Id = _idWorker.NextId();//获取一个雪花Id
                newRow.Creator = _claimsAccessor.UserId;//由于暂时还没有做登录，所以拿不到登录者信息，先随便写一个后面再完善
                newRow.CreateTime = DateTime.Now;
                _unitOfWork.GetRepository<Tag>().Insert(newRow);
                await _unitOfWork.SaveChangesAsync();
                await tran.CommitAsync();//提交事务

                result.SetData(newRow);//添加成功，把新的实体返回回去
            }
            return result;
        }

        public async Task<ExecuteResult> Update(TagViewModel viewModel)
        {
            ExecuteResult result = new ExecuteResult();
            //检查字段
            if (viewModel.CheckField(ExecuteType.Update, _unitOfWork) is ExecuteResult checkResult && !checkResult.IsSucceed)
            {
                return checkResult;
            }

            //从数据库中取出该记录
            var row = await _unitOfWork.GetRepository<Tag>().FindAsync(viewModel.Id);//在viewModel.CheckField中已经获取了一次用于检查，所以此处不会重复再从数据库取一次，有缓存
            //修改对应的值
            row.TagName = viewModel.TagName;
            row.DisplayName = viewModel.DisplayName;
            row.Description = viewModel.Description;
            row.Modifier = 1219490056771866624;//由于暂时还没有做登录，所以拿不到登录者信息，先随便写一个后面再完善
            row.ModifyTime = DateTime.Now;
            _unitOfWork.GetRepository<Tag>().Update(row);
            await _unitOfWork.SaveChangesAsync();//提交

            return result;
        }

        public async Task<ExecuteResult> Delete(TagViewModel viewModel)
        {
            ExecuteResult result = new ExecuteResult();
            //检查字段
            if (viewModel.CheckField(ExecuteType.Delete, _unitOfWork) is ExecuteResult checkResult && !checkResult.IsSucceed)
            {
                return checkResult;
            }
            _unitOfWork.GetRepository<Tag>().Delete(viewModel.Id);
            await _unitOfWork.SaveChangesAsync();//提交
            return result;
        }
    }
}
