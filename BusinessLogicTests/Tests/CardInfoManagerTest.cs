using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalEF;
using DalEF.Interfaces;
using BusinessLogic.Concrete;
using DTO;

namespace BusinessLogicTests.Tests
{
    [TestFixture]
    class CardInfoManagerTest
    {
        private Mock<IBankCardInfoDal> cardInfoDal;
        private CardInfoMananger manager;

        [SetUp]
        public void Setup()
        {
            cardInfoDal = new Mock<IBankCardInfoDal>(MockBehavior.Strict);

            manager = new CardInfoMananger(cardInfoDal.Object);
        }

        [Test]
        public void GetCardInfoByIdTest()
        {
            int card_id = 1;
            var to_ret = new BankCardInfoDTO { BankCardInfoID=1,BankID=1,CardNumber="12345",CVV=123,ExtendDate= DateTime.Now};
            
            cardInfoDal.Setup(d => d.GetBankCardInfoById(card_id)).Returns(to_ret);
            var res = manager.GetCardInfoById(card_id);

            NUnit.Framework.Assert.AreEqual(res.BankCardInfoID,card_id);
        }

    }
}
