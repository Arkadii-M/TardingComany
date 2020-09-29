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
    public class BankDalEf : IBankDal
    {
        private readonly IMapper _mapper;
        public BankDalEf(IMapper mapper)
        {
            _mapper = mapper;
        }
        public BankDTO CreateBank(BankDTO bank)
        {
            using (var e = new Traiding_CompanyEntities2())
            {
                Bank to_add = _mapper.Map<Bank>(bank);
                e.Bank.Add(to_add);
                e.SaveChanges();
                return _mapper.Map<BankDTO>(to_add);
            }
        }

        public bool DeleteBankById(int id)
        {
            using (var e = new Traiding_CompanyEntities2())
            {
                var bank = e.Bank.SingleOrDefault(a => a.BankID == id);
                if (bank == null)
                {
                    return false;
                }
                e.Bank.Remove(bank);
                e.SaveChanges();
                return true;
            }
        }

        public List<BankDTO> GetAllBanks()
        {
            using (var e = new Traiding_CompanyEntities2())
            {
                return _mapper.Map<List<BankDTO>>(e.Bank.ToList());
            }
        }

        public BankDTO GetBankById(int id)
        {
            using (var e = new Traiding_CompanyEntities2())
            {
                var bank = e.Bank.SingleOrDefault(a => a.BankID == id);
                if (bank == null)
                {
                    return null;
                }
                return _mapper.Map<BankDTO>(bank);
            }
        }

        public BankDTO UpdateBank(BankDTO bank)
        {
            using (var e = new Traiding_CompanyEntities2())
            {
                e.Bank.AddOrUpdate(_mapper.Map<Bank>(bank));
                e.SaveChanges();
                var res = e.Bank.Single(p => p.BankID == bank.BankID);
                return _mapper.Map<BankDTO>(res);
            }
        }
    }
}
