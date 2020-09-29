using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalEF.Profiles
{
    class UserInfoProfile: Profile
    {
        public UserInfoProfile()
        {
            CreateMap<UserInfo, UserInfoDTO>().ReverseMap();

        }
    }
}
