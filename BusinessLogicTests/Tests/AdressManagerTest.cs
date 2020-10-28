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
    [TestFixture]
    public class AdressManagerTest
    {
        private Mock<IAdressDal> adressDal;
        private AdressManager manager;

        [SetUp]
        public void Setup()
        {
            adressDal = new Mock<IAdressDal>(MockBehavior.Strict);

            manager = new AdressManager(adressDal.Object);
        }

        [Test]
        public void GetAllAdressesTest()
        {
            var to_ret = new List<AdressDTO> { new AdressDTO { AdressID = 1, City = "City", CountryID = 1, Street = "Street" } };
            adressDal.Setup(d => d.GetAllAdresses()).Returns(to_ret);
            var res = manager.GetAllAdresses();

            NUnit.Framework.Assert.IsTrue(res.Count != 0);
        }

        [Test]
        public void AddAdressTest()
        {
            var to_ret = new AdressDTO { AdressID = 1, City = "City", CountryID = 1, Street = "Street" };
            var get = new AdressDTO { City = "City", CountryID = 1, Street = "Street" };
            adressDal.Setup(d => d.CreateAdress(It.Is<AdressDTO>(t => t.City != null && t.CountryID != 0 && t.Street != null))).Returns(to_ret);
            
            var res = manager.AddAdress(get.CountryID, get.City, get.Street);
            NUnit.Framework.Assert.IsTrue(res.AdressID == 1);

        }
    }
}
