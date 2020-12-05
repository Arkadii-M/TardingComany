using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using DTO;

namespace TradingCompanyMVC.App.Security
{
    public class CustomMembershipUser:MembershipUser
    {

        public int UserID { get; set; }
        public ICollection<PrivilegeDTO> Roles { get; set; }

        public CustomMembershipUser(UserInfoDTO user,AccountDTO account)
            :base("CustomMembership",
                account.UserLogin,
                account.UserID,
                user.Email,
                string.Empty,
                string.Empty,
                true,
                false,
                DateTime.Now,
                DateTime.Now,
                DateTime.Now,
                DateTime.Now,
                DateTime.Now)
        {
            UserID = account.UserID;
            Roles = account.Privileges;
        }
    }
}