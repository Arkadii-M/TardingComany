using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.EnterpriseServices;
using System.Configuration;
using DTO;
using DalEF.Concrete;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using AutoMapper;

namespace DalEfTests.Tests
{
    [TestFixture]
    [Transaction(TransactionOption.RequiresNew), ComVisible(true)]
    public class AccountDalEfTests : ServicedComponent
    {
        public AccountDalEfTests()
        {
           


        }
        private static IMapper SetupMapper()
        {
            MapperConfiguration conf = new MapperConfiguration(
                    cfg => cfg.AddMaps(typeof(AccountDalEf).Assembly)
                );
            return conf.CreateMapper();
        }
       
        [Test]
        public void CreateAccountTest()
        {
            var _mapper = SetupMapper();
            DalEF.Concrete.AccountDalEf accDal = new DalEF.Concrete.AccountDalEf(_mapper);
            var res = accDal.CreateAccount(CreateDTOs.CreateAccountDTO());
            Assert.IsTrue(res.UserID != 0,"Error.CreateAccout failed");
        }
        [Test]
        public void DeleteAccountTest()
        {
            var _mapper = SetupMapper();
            DalEF.Concrete.AccountDalEf accDal = new DalEF.Concrete.AccountDalEf(_mapper);
            var res = accDal.CreateAccount(CreateDTOs.CreateAccountDTO());
            bool check = accDal.DeleteAccount(res.UserID);
            Assert.IsTrue(check,"Can't delete account");
        }
        [Test]
        public void GetAccountTest()
        {
            var _mapper = SetupMapper();
            DalEF.Concrete.AccountDalEf accDal = new DalEF.Concrete.AccountDalEf(_mapper);
            var acc = CreateDTOs.CreateAccountDTO();
            acc = accDal.CreateAccount(acc);
            var res = accDal.GetAccountByID(acc.UserID);
            Assert.IsTrue(res.UserID != 0,"Get account by id fail");
        }
        [Test]
        public void GetAllAccountsTest()
        {
            var _mapper = SetupMapper();
            DalEF.Concrete.AccountDalEf accDal = new DalEF.Concrete.AccountDalEf(_mapper);
            var res = accDal.GetAllAccounts();
            Assert.IsTrue(res.Count() > 0,"Get all account fail");
        }
        [Test]
        public void UpdateAccountTest()
        {
            var _mapper = SetupMapper();
            DalEF.Concrete.AccountDalEf accDal = new DalEF.Concrete.AccountDalEf(_mapper);
            var acc = CreateDTOs.CreateAccountDTO();
            acc = accDal.CreateAccount(acc);
            var upAcc = CreateDTOs.CreateAccountDTO();
            upAcc.UserID = acc.UserID;
            upAcc.UserLogin = "NEW LOGIN";

            var res = accDal.UpdateAccount(upAcc);
            Assert.IsTrue(res.UserLogin == upAcc.UserLogin,"Update test failde");
        }

        [OneTimeSetUp]
        public void SetupFixture()
        {
            Console.WriteLine("SetupFixture");
        }

        [SetUp]
        public void SetupTest()
        {
            Console.WriteLine("SetupTest");
        }

        [OneTimeTearDown]
        public void TearDownFixture()
        {
            Console.WriteLine("TearDownFixture");
        }

        [TearDown]
        public void Teardown()
        {
            if (ContextUtil.IsInTransaction)
            {
                ContextUtil.SetAbort();
            }
        }



    }
}
