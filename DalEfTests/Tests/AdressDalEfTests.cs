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
    public class AdressDalEfTests : ServicedComponent
    {
        
        public AdressDalEfTests()
        {



        }
        private static IMapper SetupMapper()
        {
            MapperConfiguration conf = new MapperConfiguration(
                    cfg => cfg.AddMaps(typeof(AdressDalEf).Assembly)
                );
            return conf.CreateMapper();
        }

        [Test]
        public void CreateAdressTest()
        {
            var _mapper = SetupMapper();
            DalEF.Concrete.AdressDalEf Dal = new DalEF.Concrete.AdressDalEf(_mapper);
            var res = Dal.CreateAdress(CreateDTOs.CreateAdressDTO());
            Assert.IsTrue(res.AdressID != 0, "Error.Create Adress failed");
        }
        [Test]
        public void DeleteAdressTest()
        {
            var _mapper = SetupMapper();
            DalEF.Concrete.AdressDalEf Dal = new DalEF.Concrete.AdressDalEf(_mapper);
            var res = Dal.CreateAdress(CreateDTOs.CreateAdressDTO());
            bool check = Dal.DeleteAdress((int)res.AdressID);
            Assert.IsTrue(check, "Delete adress failed");
        }
        [Test]
        public void GetAdressTest()
        {
            var _mapper = SetupMapper();
            DalEF.Concrete.AdressDalEf Dal = new DalEF.Concrete.AdressDalEf(_mapper);
            var c = Dal.CreateAdress(CreateDTOs.CreateAdressDTO());
            var res = Dal.GetAdressByID((int)c.AdressID);
            Assert.IsTrue(res.AdressID != 0, "Get adress by id fail");
        }
        [Test]
        public void GetAllAdressTest()
        {
            var _mapper = SetupMapper();
            DalEF.Concrete.AdressDalEf Dal = new DalEF.Concrete.AdressDalEf(_mapper);
            var c = Dal.CreateAdress(CreateDTOs.CreateAdressDTO());
            var res = Dal.GetAllAdresses();
            Assert.IsTrue(res.Count() > 0);
        }
        [Test]
        public void UpdateAdressTest()
        {
            var _mapper = SetupMapper();
            DalEF.Concrete.AdressDalEf Dal = new DalEF.Concrete.AdressDalEf(_mapper);
            var c1 = CreateDTOs.CreateAdressDTO();
            c1 = Dal.CreateAdress(c1);
            var c2 = c1;
            c1.City = "Another";

            c1 = Dal.UpdateAdress(c1);
            Assert.IsTrue(c1.City == c2.City, "Update test fail");
        }

        [OneTimeTearDown]
        public void TearDownFixture()
        {
            Console.WriteLine("TearDownFixture");
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
