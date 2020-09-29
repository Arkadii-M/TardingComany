using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace DAL.Interfaces
{
    public interface IAccountDal
    {
        AccountDTO GetAccountByID(int id);
        List<AccountDTO> GetAllAccounts();
        AccountDTO CreateAccount(AccountDTO Account);
        
        AccountDTO UpdateAccount(AccountDTO Account);
        bool DeleteAccount(int id);


    }
}
