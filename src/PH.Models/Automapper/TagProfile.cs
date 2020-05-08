using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace PH.Models.Automapper
{
    using Models.ViewModel;
    using Entities;
    public class TagProfile: Profile
    {
        public TagProfile()
        {
            CreateMap<TagViewModel, Tag>();
        }
    }
}
