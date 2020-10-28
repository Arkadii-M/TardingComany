using BusinessLogic.Interfaces;
using DalEF.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class CardInfoMananger : ICardInfoMananger
    {
        private readonly IBankCardInfoDal _cardInfoDal;
        public CardInfoMananger(IBankCardInfoDal cardInfoDal)
        {
            this._cardInfoDal = cardInfoDal;
        }
        public BankCardInfoDTO GetCardInfoById(int id)
        {
            return this._cardInfoDal.GetBankCardInfoById(id);
        }
    }
}
