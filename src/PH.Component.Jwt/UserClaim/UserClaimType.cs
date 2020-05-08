using System;
using System.Collections.Generic;
using System.Text;

namespace PH.Component.Jwt.UserClaim
{
    public static class UserClaimType
    {
        public const string Id = "http://schemas.microsoft.com/ws/2008/06/identity/claims/primarysid";
        public const string Account = "http://schemas.microsoft.com/ws/2008/06/identity/claims/serialnumber";
        public const string Name = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
        public const string Email = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress";
        public const string Phone = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/mobilephone";
    }
}
