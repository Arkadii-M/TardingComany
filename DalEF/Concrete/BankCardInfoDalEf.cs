using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DalEF.Interfaces;
using DTO;

namespace DalEF.Concrete
{
    public class BankCardInfoDalEf : IBankCardInfoDal
    {
        private readonly IMapper _mapper;
        public BankCardInfoDalEf(IMapper mapper)
        {
            this._mapper = mapper;
        }
        public BankCardInfoDTO CreateBankCardInfo(BankCardInfoDTO card)
        {

            using (var e = new EntityTC())
            {
                BankCardInfo info = _mapper.Map<BankCardInfo>(card);
                e.BankCardInfo.Add(info);
                e.SaveChanges();
                return _mapper.Map<BankCardInfoDTO>(info);
            }
        }

        public bool DeleteBankCardInfoById(int id)
        {

            using (var e = new EntityTC())
            {
                var info  = e.BankCardInfo.SingleOrDefault(a => a.BankCardInfoID == id);
                if (info == null)
                {
                    return false;
                }
                e.BankCardInfo.Remove(info);
                e.SaveChanges();
                return true;
            }
        }

        public List<BankCardInfoDTO> GetAllBankCardInfo()
        {
            using (var e = new EntityTC())
            {
                return _mapper.Map<List<BankCardInfoDTO>>(e.BankCardInfo);
            }
        }

        public BankCardInfoDTO GetBankCardInfoById(int id)
        {
            using (var e = new EntityTC())
            {
                var info = e.BankCardInfo.SingleOrDefault(a => a.BankCardInfoID == id);
                if (info == null)
                {
                    return null;
                }
                return _mapper.Map<BankCardInfoDTO>(info);
            }
        }

        public BankCardInfoDTO UpdateBankCardInfo(BankCardInfoDTO card)
        {
            using (var e = new EntityTC())
            {
                e.BankCardInfo.AddOrUpdate(_mapper.Map<BankCardInfo>(card));
                var res = e.BankCardInfo.Single(p => p.BankCardInfoID == card.BankCardInfoID);
                return _mapper.Map<BankCardInfoDTO>(res);
            }
        }
    }
}
