using BusinessLogic.Concrete;
using DalEF.Interfaces;
using DTO;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicTests.Tests
{
    public class BankManagerTest
    {
        private Mock<IBankDal> bankDal;
        private BankManager manager;

        [SetUp]
        public void Setup()
        {
            bankDal = new Mock<IBankDal>(MockBehavior.Strict);

            manager = new BankManager(bankDal.Object);
        }
        [Test]
        public void GetAllBanksTest()
        {
            var to_ret = new List<BankDTO>() { new BankDTO { BankID = 1 } };
            bankDal.Setup(d => d.GetAllBanks()).Returns(to_ret);
            var res = manager.GetAllBanks();
            Assert.IsNotNull(res);
            Assert.IsTrue(res.Count != 0);
        }
    }
}
