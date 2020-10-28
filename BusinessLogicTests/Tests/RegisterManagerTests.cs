using BusinessLogic.Concrete;
using DAL.Interfaces;
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
    [TestFixture]
    public class RegisterManagerTests
    {
        private Mock<IAccountDal> accountDal;
        private Mock<IUserInfoDal> userDal;


        private Mock<IAdressDal> adressDal;
        private Mock<IBankCardInfoDal> cardinfoDal;
        private RegisterManager manager;
        [SetUp]
        public void Setup()
        {
            accountDal = new Mock<IAccountDal>(MockBehavior.Strict);
            userDal = new Mock<IUserInfoDal>(MockBehavior.Strict);
            adressDal = new Mock<IAdressDal>(MockBehavior.Strict);
            cardinfoDal = new Mock<IBankCardInfoDal>(MockBehavior.Strict);

            manager = new RegisterManager(accountDal.Object, userDal.Object,adressDal.Object,cardinfoDal.Object);
        }

        [Test]
        public void RegisterTest()
        {
            string uname = "uname";
            string pass = "pass";
            var outAcc = new AccountDTO { UserID = 1,UserLogin=uname };
            accountDal.Setup(d => d.CreateAccount(uname, pass)).Returns(outAcc);

            UserInfoDTO inUser = new UserInfoDTO
            {
                AdressID = 1,
                BankCardInfoID = 1,
                Email = "some email",
                FirstName = "A",
                LastName = "B",
                Gender = 1,
                MobilePhone = "+38000000",
                UserID = 1
            };

            UserInfoDTO outUser = inUser;
            var card = new BankCardInfoDTO() { BankCardInfoID = 1 };
            var addr = new AdressDTO() { AdressID=1 };

            userDal.Setup(d => d.CreateUserInfo(inUser)).Returns(outUser);
            cardinfoDal.Setup(d => d.CreateBankCardInfo(card)).Returns(card);
            adressDal.Setup(d => d.CreateAdress(addr)).Returns(addr);

            var res = manager.Register(uname, pass,inUser,card,addr); 

            Assert.IsNotNull(res);
            Assert.IsTrue(res);
        }

    }
}
