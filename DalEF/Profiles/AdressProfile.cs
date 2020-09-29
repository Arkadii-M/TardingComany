using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalEF.Profiles
{
    class AdressProfile: Profile
    {
        public AdressProfile()
        {
            CreateMap<Adress, AdressDTO>().ReverseMap();
        }
    }
}
