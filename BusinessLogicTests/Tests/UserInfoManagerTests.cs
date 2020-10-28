using BusinessLogic.Interfaces;
using BusinessLogic.Concrete;
using DAL.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalEF;
using DTO;

namespace BusinessLogicTests
{
    [TestFixture]
    class UserInfoManagerTests
    {

        private Mock<IAccountDal> accountDal;
        private Mock<IUserInfoDal> userDal;
        private UserInfoManager manager;
        [SetUp]
        public void Setup()
        {
            accountDal = new Mock<IAccountDal>(MockBehavior.Strict);
            userDal = new Mock<IUserInfoDal>(MockBehavior.Strict);

            manager = new UserInfoManager(accountDal.Object,userDal.Object);
        }

        [Test]
        public void AddUserInfoTest()
        {
            UserInfoDTO inUser = new UserInfoDTO
            {
                AdressID =1,
                BankCardInfoID =1,
                Email ="some email",
                FirstName ="A",
                LastName = "B",
                Gender =1,
                MobilePhone ="+38000000",
            };

            UserInfoDTO outUser = new UserInfoDTO { UserID =1 };

            userDal.Setup(d => d.CreateUserInfo(inUser)).Returns(outUser);
            var res = manager.AddUserInfo(inUser);

            Assert.IsNotNull(res);
            Assert.AreEqual(outUser.UserID, res.UserID);
        }

        [Test]
        public void  GetUserInfoByIdTest()
        {
            int id = 1;
            UserInfoDTO outUser = new UserInfoDTO { UserID = 1 };

            userDal.Setup(d => d.GetUserInfoById(id)).Returns(outUser);
            var res = manager.GetUserInfoById(id);
            Assert.IsNotNull(res);
            Assert.AreEqual(id, res.UserID);
        }

        [Test]
        public void GetUserInfoByLoginTest()
        {
            string login = "login";

            UserInfoDTO outUser = new UserInfoDTO { UserID = 1 };
            AccountDTO outAccout = new AccountDTO { UserID = 1 };
            accountDal.Setup(d => d.GetAccountByLogin(login)).Returns(outAccout);
            userDal.Setup(d => d.GetUserInfoById(outAccout.UserID)).Returns(outUser);
            var res = manager.GetUserInfoByLogin(login);

            Assert.IsNotNull(res);
            Assert.AreEqual(outUser.UserID, res.UserID);
            
        }

        [Test]
        public void UpdateUserInfo()
        {
            UserInfoDTO inUser = new UserInfoDTO
            {
                UserID =2,
                AdressID = 1,
                BankCardInfoID = 1,
                Email = "some email",
                FirstName = "A",
                LastName = "B",
                Gender = 1,
                MobilePhone = "+38000000",
            };

            UserInfoDTO outUser = inUser;

            userDal.Setup(d => d.UpdateUserInfo(inUser)).Returns(outUser);
            var res = manager.UpdateUserInfo(inUser);

            Assert.IsNotNull(res);
            Assert.AreEqual(outUser.UserID, res.UserID);
        }
    }
}
