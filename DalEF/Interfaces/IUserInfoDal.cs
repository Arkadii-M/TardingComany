using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    interface IUserInfoDal
    {
        UserInfoDTO CreateUserInfo(UserInfoDTO info);

        UserInfoDTO GetUserInfoById(int id);
        bool DeleteUserInfoById(int id);
        List<UserInfoDTO> GetAllUserInfo();
        UserInfoDTO UpdateUserInfo(UserInfoDTO info);
    }
}
