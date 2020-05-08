using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace PH.Component.Jwt.UserClaim
{
    public class ClaimsAccessor : IClaimsAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClaimsAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal UserPrincipal
        {
            get
            {
                ClaimsPrincipal user = _httpContextAccessor.HttpContext.User;
                if (user.Identity.IsAuthenticated)
                {
                    return user;
                }
                else
                {
                    throw new Exception("用户未认证");
                }
            }
        }

        public string UserName
        {
            get { return UserPrincipal.Claims.First(x => x.Type == UserClaimType.Name).Value; }
        }

        public long UserId
        {
            get { return long.Parse(UserPrincipal.Claims.First(x => x.Type == UserClaimType.Id).Value); }

        }

        public string UserAccount
        {
            get { return UserPrincipal.Claims.First(x => x.Type == UserClaimType.Account).Value; }
        }
    }
}
