using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace DAL.Interfaces
{
    public interface IAccountDal
    {
        AccountDTO GetAccountByID(int id);
        AccountDTO GetAccountByLogin(string login);
        List<AccountDTO> GetAllAccounts();
        AccountDTO CreateAccount(AccountDTO Account);
        
        AccountDTO UpdateAccount(AccountDTO Account);
        bool DeleteAccount(int id);
        bool Login(string username, string password);
        AccountDTO CreateAccount(string username, string password);



    }
}
