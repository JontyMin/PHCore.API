using System;
using System.Collections.Generic;
using System.Text;

namespace PH.Component.Jwt.UserClaim
{
    public interface IClaimsAccessor
    {
        string UserName { get; }
        long UserId { get; }
        string UserAccount { get; }
    }
}
