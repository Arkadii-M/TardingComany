﻿using System;
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
using DalEF;

namespace DalEfTests.Tests
{
    public class CreateDTOs
    {
        public static AccountDTO CreateAccountDTO()
        {
            var Salt = "1627ebdkdns";
            byte[] bytes = Encoding.ASCII.GetBytes("Pwd" + Salt);
            byte[] pass;
            using (var crypt = SHA1.Create())
            {
                pass = crypt.ComputeHash(bytes);

            }
            AccountDTO account = new AccountDTO() { UserLogin = "login", UserPassword = pass, Salt = Salt };
            return account;
        }
        public static BankCardInfoDTO CreateBankCardInfoDTO()
        {
            BankCardInfoDTO card = new BankCardInfoDTO()
            {
                BankID = 1,
                CardNumber = "number",
                CVV = 123,
                ExtendDate = DateTime.Now
                
                
            };
            return card;
        }
        public static BankDTO CreateBankDTO()
        {
            BankDTO bank = new BankDTO()
            {
                Name = "Universal Bank",
                Swift = "Test"
            };
            return bank;
        }
        public static UserInfoDTO CreateUserInfoDTO()
        {
            UserInfoDTO user = new UserInfoDTO()
            {
                FirstName = "FN",
                LastName = "LN",
                Email = "Some_Email@gmai.com",
                Gender = 0,
                MobilePhone = "12345",
                BankCardInfoID =1,
                AdressID =7,
                UserID = 24
                
            };
            return user;
        }
        public static CountryDTO CreateCountryDTO()
        {
            return new CountryDTO() { Name = "Ukraine" };
        }
        public static AdressDTO CreateAdressDTO()
        {
            return new AdressDTO() { City = "Lviv", Street = "Some street", CountryID = 7 };
        }
        public static CategoryDTO CreateCategoryDTO()
        {
            return new CategoryDTO { Name = "Some category name" };
        }
        public static ItemDTO CreateItemDTO()
        {
            return new ItemDTO { InStock = 10, ItemTitle = "test item", CategoryID = 1, Price = 777 };
        }
        public static OrderStatusDTO CreateOrderStatusDTO()
        {
            return new OrderStatusDTO { Name = "test status" };
        }
        public static OrderDTO CreateOrderDTO()
        {
            return new OrderDTO { Ordernumber = "123", UserID = 1, Comment = "test", Date = DateTime.Now, StatusID = 1 };
        }
        public static OrderedDTO CreateOrderedDTO()
        {
            return new OrderedDTO { Amount = 3, OrderID = 1, ItemID = 1 };
        }
    }
}
