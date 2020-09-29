using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalEF.Profiles;
using AutoMapper;
using System.Data.Entity.Migrations;

namespace DalEF.Concrete
{
    public class AccountDalEf : IAccountDal
    {
        private readonly IMapper _mapper;
        public AccountDalEf(IMapper mapper)
        {
            _mapper = mapper;
        }
        public AccountDTO CreateAccount(AccountDTO Account)
        {
            using (var e = new Traiding_CompanyEntities2())
            {
                Account acc = _mapper.Map<Account>(Account);
                e.Account.Add(acc);
                e.SaveChanges();
                return _mapper.Map<AccountDTO>(acc);
            }
        }

        public bool DeleteAccount(int id)
        {
            using (var e = new Traiding_CompanyEntities2())
            {
                var acc = e.Account.SingleOrDefault(a => a.UserID == id);
                if(acc == null)
                {
                    return false;
                }
                e.Account.Remove(acc);
                e.SaveChanges();
                return true;
            }
        }

        public AccountDTO GetAccountByID(int id)
        {
            using (var e = new Traiding_CompanyEntities2())
            {
                var acc = e.Account.SingleOrDefault(a => a.UserID == id);
                if (acc == null)
                {
                    return null;
                }
                return _mapper.Map<AccountDTO>(acc);
            }
        }

        public List<AccountDTO> GetAllAccounts()
        {
            using (var e = new Traiding_CompanyEntities2())
            {
                return _mapper.Map<List<AccountDTO>>(e.Account.ToList());
            }
        }

        public AccountDTO UpdateAccount(AccountDTO Account)
        {
            using (var e = new Traiding_CompanyEntities2())
            {
                e.Account.AddOrUpdate(_mapper.Map<Account>(Account));
                e.SaveChanges();
                var acc = e.Account.Single(p => p.UserID == Account.UserID);
                return _mapper.Map<AccountDTO>(acc);
            }
        }
    }
}
