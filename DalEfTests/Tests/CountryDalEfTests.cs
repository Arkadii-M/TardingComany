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
    public class CountryDalEfTests : ServicedComponent
    {

        public CountryDalEfTests()
        {
        }
        private static IMapper SetupMapper()
        {
            MapperConfiguration conf = new MapperConfiguration(
                    cfg => cfg.AddMaps(typeof(CountryDalEf).Assembly)
                );
            return conf.CreateMapper();
        }

        [Test]
        public void CreateCountryTest()
        {
            var c = CreateDTOs.CreateCountryDTO();
            var _mapper = SetupMapper();
            DalEF.Concrete.CountryDalEf Dal = new DalEF.Concrete.CountryDalEf(_mapper);
            var res = Dal.CreateCountry(c);
            Assert.IsTrue(res.CountryID != 0, "Error.Create coutry failed");
        }


        [Test]
        public void DeleteCountryTest()
        {
            var _mapper = SetupMapper();
            DalEF.Concrete.CountryDalEf Dal = new DalEF.Concrete.CountryDalEf(_mapper);
            var res = Dal.CreateCountry(CreateDTOs.CreateCountryDTO());
            bool check = Dal.DeleteCountry(res.CountryID);
            Assert.IsTrue(check, "Can't delete account");
        }
        [Test]
        public void GetCountryTest()
        {
            var _mapper = SetupMapper();
            DalEF.Concrete.CountryDalEf Dal = new DalEF.Concrete.CountryDalEf(_mapper);
            var c = CreateDTOs.CreateCountryDTO();
            c = Dal.CreateCountry(c);
            var res = Dal.GetCountryByID(c.CountryID);
            Assert.IsTrue(res.CountryID != 0, "Get account by id fail");
        }
        [Test]
        public void GetAllCountryTest()
        {
            var _mapper = SetupMapper();
            DalEF.Concrete.CountryDalEf Dal = new DalEF.Concrete.CountryDalEf(_mapper);
            Dal.CreateCountry(CreateDTOs.CreateCountryDTO());
            var res = Dal.GetAllCountries();
            Assert.IsTrue(res.Count() > 0, "Get all account fail");
        }
        [Test]
        public void UpdateCountryTest()
        {
            var _mapper = SetupMapper();
            DalEF.Concrete.CountryDalEf Dal = new DalEF.Concrete.CountryDalEf(_mapper);
            var c1 = CreateDTOs.CreateCountryDTO();
            c1 = Dal.CreateCountry(c1);
            var c2 = c1;
            c1.Name = "test";
            c1 = Dal.UpdateCountry(c1);
            Assert.IsTrue(c1.Name == c2.Name);
        }

        [TearDown]
        public void TeardownFunc()
        {
            if (ContextUtil.IsInTransaction)
            {
                ContextUtil.SetAbort();
            }
        }

    }
}
