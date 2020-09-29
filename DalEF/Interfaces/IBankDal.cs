using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DalEF.Interfaces
{
    public interface IBankDal
    {
        BankDTO CreateBank(BankDTO bank);

        BankDTO GetBankById(int id);
        bool DeleteBankById(int id);
        List<BankDTO> GetAllBanks();
        BankDTO UpdateBank(BankDTO bank);
    }
}
