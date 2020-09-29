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
    public class UserInfoDalEfTests : ServicedComponent
    {
        public UserInfoDalEfTests()
        {

        }
        private static IMapper SetupMapper()
        {
            MapperConfiguration conf = new MapperConfiguration(
                    cfg => cfg.AddMaps(typeof(UserInfoDalEf).Assembly)
                );
            return conf.CreateMapper();
        }

        

        
        [Test]
        public void CreateUserInfoTest()
        {
            var _mapper = SetupMapper();
            DalEF.Concrete.UserInfoDalEf Dal = new DalEF.Concrete.UserInfoDalEf(_mapper);
            var user = CreateDTOs.CreateUserInfoDTO();

            user = Dal.CreateUserInfo(user);

            Assert.IsTrue(user.UserID != 0,"Fail CreateUserInfo");

        }


        [Test]
        public void DeleteUserInfoTest()
        {
            var _mapper = SetupMapper();
            DalEF.Concrete.UserInfoDalEf Dal = new DalEF.Concrete.UserInfoDalEf(_mapper);
            var user = CreateDTOs.CreateUserInfoDTO();
            user = Dal.CreateUserInfo(user);
            bool check = Dal.DeleteUserInfoById(user.UserID);
            Assert.IsTrue(check, "Can't delete userinfo");
        }
        [Test]
        public void GetUserInfoTest()
        {
            var _mapper = SetupMapper();
            DalEF.Concrete.UserInfoDalEf Dal = new DalEF.Concrete.UserInfoDalEf(_mapper);
            var user = CreateDTOs.CreateUserInfoDTO();
            user = Dal.CreateUserInfo(user);
            var res = Dal.GetUserInfoById(user.UserID);
            Assert.IsTrue(res.UserID != 0, "Get user info by id fail");
        }
        [Test]
        public void GetAllUserInfoTest()
        {
            var _mapper = SetupMapper();
            DalEF.Concrete.UserInfoDalEf Dal = new DalEF.Concrete.UserInfoDalEf(_mapper);
            var user = CreateDTOs.CreateUserInfoDTO();
            user = Dal.CreateUserInfo(user);
            var res = Dal.GetAllUserInfo();
            Assert.IsTrue(res.Count() > 0, "Get all userinfo fail");
        }
        [Test]
        public void UpdateUserInfoTest()
        {
            var _mapper = SetupMapper();
            DalEF.Concrete.UserInfoDalEf Dal = new DalEF.Concrete.UserInfoDalEf(_mapper);
            var ui1 = CreateDTOs.CreateUserInfoDTO();
            ui1 = Dal.CreateUserInfo(ui1);
            ui1.FirstName = "New";
            ui1 = Dal.UpdateUserInfo(ui1);
            Assert.IsTrue(ui1.FirstName == "New", "Update test failde");
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
