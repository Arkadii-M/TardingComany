using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TradingCompanyMVC.Models;

namespace TradingCompanyMVC.App.Profiles
{
    public class FullOrderInfoProfile:Profile
    {
       public FullOrderInfoProfile()
        {
            CreateMap<FullOrderInfo, OrderDTO>().ReverseMap();
        }
    }
}