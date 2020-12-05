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
using System.Security.Cryptography;
using System.Data.Entity;

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
            using (var e = new EntityTC())
            {
                if(e.Account.Any(a => a.UserLogin == Account.UserLogin))
                {
                    throw new Exception("User already exists!");
                }
                Account acc = _mapper.Map<Account>(Account);
                e.Account.Add(acc);
                e.SaveChanges();
                return _mapper.Map<AccountDTO>(acc);
            }
        }
        public AccountDTO CreateAccount(string username, string password)
        {
            using (var e = new EntityTC())
            {
                if (e.Account.Any(a => a.UserLogin == username))
                {
                    throw new Exception("User already exists!");
                }
                Guid salt = Guid.NewGuid();

                Account acc = new Account {
                    UserLogin = username,
                    UserPassword =  hash(password,salt.ToString()),
                    Salt = salt.ToString() 
                };
                e.Account.Add(acc);
                e.SaveChanges();
                return _mapper.Map<AccountDTO>(acc);
            }
        }

         public bool DeleteAccount(int id)
        {
            using (var e = new EntityTC())
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
            using (var e = new EntityTC())
            {
                var acc = e.Account.SingleOrDefault(a => a.UserID == id);
                if (acc == null)
                {
                    return null;
                }
                return _mapper.Map<AccountDTO>(acc);
            }
        }
        public AccountDTO GetAccountByLogin(string login)
        {
            using (var e = new EntityTC())
            {
                return _mapper.Map<AccountDTO>(e.Account.SingleOrDefault(l => l.UserLogin == login));
            }
        }

        public List<AccountDTO> GetAllAccounts()
        {
            using (var e = new EntityTC())
            {
                return _mapper.Map<List<AccountDTO>>(e.Account.ToList());
            }
        }

        public AccountDTO UpdateAccount(AccountDTO Account)
        {
            using (var e = new EntityTC())
            {
                e.Account.AddOrUpdate(_mapper.Map<Account>(Account));
                e.SaveChanges();
                var acc = e.Account.Single(p => p.UserID == Account.UserID);
                return _mapper.Map<AccountDTO>(acc);
            }
        }

        public bool Login(string username, string password)
        {
            using (var e = new EntityTC())
            {
                var account = e.Account.SingleOrDefault(acc => acc.UserLogin == username);

                return account != null && account.UserPassword.SequenceEqual(hash(password, account.Salt));
            }
        }

        private byte[] hash(string password, string salt)
        {
            var alg = SHA512.Create();
            return alg.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
        }
    }
}
