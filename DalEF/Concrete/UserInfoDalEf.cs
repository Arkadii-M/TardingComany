using AutoMapper;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalEF.Concrete
{
    public class UserInfoDalEf:IUserInfoDal
    {
        private readonly IMapper _mapper;
        public UserInfoDalEf(IMapper mapper)
        {
            _mapper = mapper;
        }

        public UserInfoDTO CreateUserInfo(UserInfoDTO info)
        {
            using (var e = new Traiding_CompanyEntities2())
            {
                UserInfo user = _mapper.Map<UserInfo>(info);
                e.UserInfo.Add(user);
                e.SaveChanges();
                return _mapper.Map<UserInfoDTO>(user);
            }
        }

        public bool DeleteUserInfoById(int id)
        {
            using (var e = new Traiding_CompanyEntities2())
            {
                UserInfo user = e.UserInfo.SingleOrDefault(p => p.UserID == id);
                if (user == null)
                {
                    return false;
                }
                e.UserInfo.Remove(user);
                e.SaveChanges();
                return true;
            }
        }

        public List<UserInfoDTO> GetAllUserInfo()
        {
            using (var e = new Traiding_CompanyEntities2())
            {
                return _mapper.Map<List<UserInfoDTO>>(e.UserInfo.ToList());

            }
        }

        public UserInfoDTO GetUserInfoById(int id)
        {
            using (var e = new Traiding_CompanyEntities2())
            {
                return _mapper.Map<UserInfoDTO>(e.UserInfo.SingleOrDefault(p => p.UserID == id));
            }
        }

        public UserInfoDTO UpdateUserInfo(UserInfoDTO info)
        {
            using (var e = new Traiding_CompanyEntities2())
            {
                e.UserInfo.AddOrUpdate(_mapper.Map<UserInfo>(info));
                e.SaveChanges();
                return _mapper.Map<UserInfoDTO>(e.UserInfo.Single(p=> p.UserID == info.UserID));
            }
        }
    }
}
