using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TradingCompanyMVC.Models;

namespace TradingCompanyMVC.App.Profiles
{
    public class OrderedInfoProfile:Profile
    {
        public OrderedInfoProfile()
        {
            CreateMap<OrderedInfo, OrderedDTO>().ReverseMap();
        }
    }
}