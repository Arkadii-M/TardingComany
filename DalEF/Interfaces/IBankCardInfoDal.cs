using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DalEF.Interfaces
{
    public interface IBankCardInfoDal
    {
        BankCardInfoDTO CreateBankCardInfo(BankCardInfoDTO card);

        BankCardInfoDTO GetBankCardInfoById(int id);
        bool DeleteBankCardInfoById(int id);
        List<BankCardInfoDTO> GetAllBankCardInfo();
        BankCardInfoDTO UpdateBankCardInfo(BankCardInfoDTO card);
    }
}
