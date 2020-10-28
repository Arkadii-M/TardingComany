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
    public class CountryManagerTest
    {
        private Mock<ICountryDal> countryDal;
        private CountryManager manager;

        [SetUp]
        public void Setup()
        {
            countryDal = new Mock<ICountryDal>(MockBehavior.Strict);

            manager = new CountryManager(countryDal.Object);
        }
        [Test]
        public void GetAllCountriesTest()
        {
            var to_ret = new List<CountryDTO>() { new CountryDTO { CountryID =1} };
            countryDal.Setup(d => d.GetAllCountries()).Returns(to_ret);
            var res = manager.GetAllCountries();
            Assert.IsNotNull(res);
            Assert.IsTrue(res.Count != 0);
        }
    }
}
