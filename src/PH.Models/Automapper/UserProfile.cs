using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using PH.Component.Jwt.UserClaim;
using PH.Entities;

namespace PH.Models.Automapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserData>()
                .ForMember(a => a.Id, t => t.MapFrom(b => b.Id));
        }
    }
}
