using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class AuthManager : IAuthManager
    {
        private readonly IAccountDal _accountDal;
        public AuthManager(IAccountDal accountDal)
        {
            _accountDal = accountDal;
        }

        public bool Login(string username, string password)
        {
            return _accountDal.Login(username, password);
        }
    }
}
