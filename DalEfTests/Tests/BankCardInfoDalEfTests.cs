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
    public class BankCardInfoDalEfTests : ServicedComponent
    {
        public BankCardInfoDalEfTests()
        {

        }
       
        private static IMapper SetupMapper()
        {
            MapperConfiguration conf = new MapperConfiguration(
                    cfg => cfg.AddMaps(typeof(BankCardInfoDalEf).Assembly)
                );
            return conf.CreateMapper();
        }

        [Test]
        public void CreateBankCardInfoTest()
        {
            var cardInfo = CreateDTOs.CreateBankCardInfoDTO();
            var _mapper = SetupMapper();
            DalEF.Concrete.BankCardInfoDalEf dal = new BankCardInfoDalEf(_mapper);
            var res = dal.CreateBankCardInfo(cardInfo);
            Assert.IsTrue(res.BankCardInfoID != 0, "Fail create Bank");

        }
        
        [Test]
        public void DeleteBankCardInfoByIdTest()
        {
            var info = CreateDTOs.CreateBankCardInfoDTO();
            var _mapper = SetupMapper();
            DalEF.Concrete.BankCardInfoDalEf Dal = new DalEF.Concrete.BankCardInfoDalEf(_mapper);
            info = Dal.CreateBankCardInfo(info);
            bool check = Dal.DeleteBankCardInfoById((int)info.BankCardInfoID);
            Assert.IsTrue(check, "Fail to delete bank");
        }
        [Test]
        public void GetAllBankCardInfoTest()
        {
            var _mapper = SetupMapper();
            DalEF.Concrete.BankCardInfoDalEf Dal = new DalEF.Concrete.BankCardInfoDalEf(_mapper);
            var info = CreateDTOs.CreateBankCardInfoDTO();
            info = Dal.CreateBankCardInfo(info);
            var res = Dal.GetAllBankCardInfo();
            Assert.IsTrue(res.Count > 0, "Fail to get all banks");

        }
        [Test]
        public void GetBankCardInfoByIdTest()
        {
            var _mapper = SetupMapper();
            DalEF.Concrete.BankCardInfoDalEf Dal = new DalEF.Concrete.BankCardInfoDalEf(_mapper);
            var info = CreateDTOs.CreateBankCardInfoDTO();
            info = Dal.CreateBankCardInfo(info);
            var res = Dal.GetBankCardInfoById((int)info.BankCardInfoID);
            Assert.IsTrue(res.BankCardInfoID == info.BankCardInfoID, "Fail to get bank");
        }
        [Test]
        public void UpdateBankCardInfoTest()
        {
            var _mapper = SetupMapper();
            DalEF.Concrete.BankCardInfoDalEf Dal = new DalEF.Concrete.BankCardInfoDalEf(_mapper);

            var info = CreateDTOs.CreateBankCardInfoDTO();
            info = Dal.CreateBankCardInfo(info);
            info.CardNumber = "New card number";

            var res = Dal.UpdateBankCardInfo(info);
            Assert.IsTrue(res.CardNumber == info.CardNumber, "Fail to get bank");

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
