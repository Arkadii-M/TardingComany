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
    public class BankDalEfTests : ServicedComponent
    {
        public BankDalEfTests()
        {

        }
        
        private static IMapper SetupMapper()
        {
            MapperConfiguration conf = new MapperConfiguration(
                    cfg => cfg.AddMaps(typeof(BankDalEf).Assembly)
                );
            return conf.CreateMapper();
        }

        [Test]
        public void CreateBankTest()
        {
            var bank = CreateDTOs.CreateBankDTO();
            
            var _mapper = SetupMapper();
            DalEF.Concrete.BankDalEf bankDal = new DalEF.Concrete.BankDalEf(_mapper);
            bank = bankDal.CreateBank(bank);
            Assert.IsTrue(bank.BankID != 0, "Fail create Bank");

        }
        [Test]
        public void DeleteBankByIdTest()
        {
            var bank = CreateDTOs.CreateBankDTO();
            var _mapper = SetupMapper();
            DalEF.Concrete.BankDalEf bankDal = new DalEF.Concrete.BankDalEf(_mapper);
            bank = bankDal.CreateBank(bank);
            bool check =bankDal.DeleteBankById(bank.BankID);
            Assert.IsTrue(check, "Fail to delete bank");
        }
        [Test]
        public void GetAllBanksTest()
        {
            var _mapper = SetupMapper();
            DalEF.Concrete.BankDalEf bankDal = new DalEF.Concrete.BankDalEf(_mapper);
            var res = bankDal.GetAllBanks();
            Assert.IsTrue(res.Count > 0, "Fail to get all banks");

        }
        [Test]
        public void GetBankByIdTest()
        {
            var _mapper = SetupMapper();
            DalEF.Concrete.BankDalEf bankDal = new DalEF.Concrete.BankDalEf(_mapper);
            var res = bankDal.GetBankById(1);
            Assert.IsTrue(res.BankID != 0, "Fail to get bank");
        }
        [Test]
        public void UpdateBankTest()
        {
            var upBank = CreateDTOs.CreateBankDTO();
            var _mapper = SetupMapper();
            DalEF.Concrete.BankDalEf bankDal = new DalEF.Concrete.BankDalEf(_mapper);
            upBank = bankDal.CreateBank(upBank);
            upBank.Swift = "Another Swift";
            var res = bankDal.UpdateBank(upBank);
            Assert.IsTrue(upBank.Swift == res.Swift, "Fail to update bank");

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
