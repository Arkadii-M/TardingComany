using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalEF.Profiles
{
    class OrderStatusProfile:Profile
    {
        public OrderStatusProfile()
        {
            CreateMap<OrderStatus, OrderStatusDTO>().ReverseMap();
        }
    }
}
