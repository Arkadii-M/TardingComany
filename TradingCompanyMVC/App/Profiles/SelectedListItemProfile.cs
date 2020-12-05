using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TradingCompanyMVC.App.Profiles
{
    public class SelectedListItemProfile:Profile
    {
        public SelectedListItemProfile()
        {
            CreateMap<CategoryDTO, SelectListItem>()
                .ForMember(dest => dest.Value, scr => scr.MapFrom(c => c.CategoryID))
                .ForMember(dest => dest.Text, scr => scr.MapFrom(c => c.Name));
        }
    }
}