using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TradingCompanyMVC.Models;

namespace TradingCompanyMVC.App.Profiles
{
    public class ItemProfile:Profile
    {
        public ItemProfile()
        {
            CreateMap<ItemDTO,ItemModel>().ReverseMap();
            CreateMap<ItemDTO, EditItemModel>().ReverseMap();
        }
    }
}