using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IAccountManager
    {
        AccountDTO GetAccountByID(int id);
        AccountDTO GetAccountByLogin(string login);
    }
}
