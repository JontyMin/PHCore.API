using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PH.Common.Security;
using PH.DbContexts;
using PH.Entities;
using PH.Entities.Core;
using PH.UnitOfWork.UnitOfWork;

namespace PH.WebApi.Initialize
{
    public static class DBSeed
    {
        /// <summary>
        /// 数据初始化
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <returns>返回是否创建了数据库（非迁移）</returns>
        public static bool Initialize(IUnitOfWork<PHDbContext> unitOfWork)
        {
            bool isCreateDb = false;
            //直接自动执行迁移,如果它创建了数据库，则返回true
            if (unitOfWork.DbContext.Database.EnsureCreated())
            {
                isCreateDb = true;
                //打印log-创建数据库及初始化期初数据

                long saUserId = 1219490056771866624;

                #region 用户
                User saUser = new User()
                {
                    Id = saUserId,
                    Account = "admin",
                    Name="SuperAdmin",
                    StatusCode = StatusCode.Enable,
                    Creator = saUserId,
                    CreateTime = DateTime.Now

                };
                unitOfWork.GetRepository<User>().Insert(saUser);

                unitOfWork.GetRepository<UserLogin>().Insert(new UserLogin
                {
                    UserId = saUserId,
                    Account = saUser.Account,
                    HashedPassword = Crypto.HashPassword(saUser.Account),//默认密码同账号名
                    IsLocked = false
                });

                unitOfWork.SaveChanges();
                #endregion



            }
            return isCreateDb;
        }
    }
}
