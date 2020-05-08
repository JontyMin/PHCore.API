using System;
using System.Collections.Generic;
using System.Text;

namespace PH.Component.Jwt.UserClaim
{
    public class UserData
    {
        public long Id { get; set; }
        public string Account { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string Token { get; set; }
    }
}
