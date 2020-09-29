using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class UserInfoDTO
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public int BankCardInfoID { get; set; }

        public int Gender { get; set; }
        public int AdressID { get; set; }

    }
}
