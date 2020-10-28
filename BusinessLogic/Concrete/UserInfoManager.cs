using BusinessLogic.Interfaces;
using DAL.Interfaces;
using DTO;
using DalEF;
using DalEF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class UserInfoManager : IUserInfoManager
    {
        private readonly IAccountDal _accountDal;
        private readonly IUserInfoDal _userInfoDal;
        public UserInfoManager(IAccountDal accountDal, IUserInfoDal userInfoDal)
        {
            _accountDal = accountDal;
            _userInfoDal = userInfoDal;

        }

        public UserInfoDTO AddUserInfo(UserInfoDTO user)
        {
            return _userInfoDal.CreateUserInfo(user);
        }

        public UserInfoDTO GetUserInfoById(int id)
        {
            return _userInfoDal.GetUserInfoById(id);
        }

        public UserInfoDTO GetUserInfoByLogin(string login)
        {
            return _userInfoDal.GetUserInfoById(_accountDal.GetAccountByLogin(login).UserID);
        }

        public UserInfoDTO UpdateUserInfo(UserInfoDTO user)
        {
            return _userInfoDal.UpdateUserInfo(user);
        }
    }
}
