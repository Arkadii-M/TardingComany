using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IUserInfoManager
    {
        UserInfoDTO AddUserInfo(UserInfoDTO user);
        UserInfoDTO UpdateUserInfo(UserInfoDTO user);
        UserInfoDTO GetUserInfoById(int id);
        UserInfoDTO GetUserInfoByLogin(string login);
    }
}
