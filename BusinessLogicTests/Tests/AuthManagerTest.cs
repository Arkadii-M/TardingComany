using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using DalEF.Concrete;
using BusinessLogic.Concrete;
using DAL.Interfaces;

namespace BusinessLogicTests
{
    [TestFixture]
    public class AuthManagerTest
    {
        public AuthManagerTest()
        {

        }
        private Mock<IAccountDal> accountDal;
        private AuthManager manager;

        [SetUp]
        public void Setup()
        {
            accountDal = new Mock<IAccountDal>(MockBehavior.Strict);

            manager = new AuthManager(accountDal.Object);
        }


        [Test]
        public void LoginUserTest()
        {
            string username = "user";
            string password = "pass";
            accountDal.Setup(d => d.Login(username, password)).Returns(true);
            var res = manager.Login(username, password);

            NUnit.Framework.Assert.IsTrue(res);
        }
    }
}
