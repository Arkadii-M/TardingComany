using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using DalEF.Concrete;
using System.Security.Cryptography;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApplicationTC.Menu.MenuFunctions
{
    static class UserFunctions
    {
        private static IMapper SetupMapperA()
        {
            MapperConfiguration conf = new MapperConfiguration(
                    cfg => cfg.AddMaps(typeof(AccountDalEf).Assembly)
                );
            return conf.CreateMapper();
        }
        private static IMapper SetupMapperU()
        {
            MapperConfiguration conf = new MapperConfiguration(
                    cfg => cfg.AddMaps(typeof(UserInfoDalEf).Assembly)
                );
            return conf.CreateMapper();
        }
        public static void Create()
        {
            var _mapper = SetupMapperA();
            DalEF.Concrete.AccountDalEf accDal = new DalEF.Concrete.AccountDalEf(_mapper);
            var Salt = "1627ebdkdns"; // some random salt
            Console.WriteLine("Login:");
            var log = Console.ReadLine();
            Console.WriteLine("Password");
            var pwd = Console.ReadLine();
            byte[] bytes = Encoding.ASCII.GetBytes(pwd + Salt) ;
            byte[] pass;
            using (var crypt = SHA1.Create())
            {
                pass = crypt.ComputeHash(bytes);

            }
            AccountDTO account = new AccountDTO() { UserLogin = log, UserPassword = pass, Salt = Salt };
            account = accDal.CreateAccount(account);

            _mapper = SetupMapperU();
            DalEF.Concrete.UserInfoDalEf uDal = new DalEF.Concrete.UserInfoDalEf(_mapper);
            Console.WriteLine("Name:");
            var FirstName = Console.ReadLine();
            Console.WriteLine("Last Name");
            var LastName = Console.ReadLine();
            Console.WriteLine("Email");
            var Email = Console.ReadLine();
            Console.WriteLine("Gender(1-0)");
            var Gender =Convert.ToByte( Console.ReadLine());
            Console.WriteLine("Mobile Phone");
            var MobilePhone =Console.ReadLine();
            Console.WriteLine("Bank Card Info id:");
            var BankCardInfoID =Convert.ToInt32( Console.ReadLine());
            Console.WriteLine("Adress id");
            var AdressID = Convert.ToInt32(Console.ReadLine());

            UserInfoDTO user = new UserInfoDTO()
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Gender = Gender,
                MobilePhone = MobilePhone,
                BankCardInfoID = BankCardInfoID,
                AdressID = AdressID,
                UserID = account.UserID

            };
            uDal.CreateUserInfo(user);
        }
        public static void Delete()
        {
            Console.WriteLine("Id:");
            var id = Convert.ToInt32(Console.ReadLine());

            var _mapper = SetupMapperU();
            DalEF.Concrete.UserInfoDalEf uDal = new DalEF.Concrete.UserInfoDalEf(_mapper);
            uDal.DeleteUserInfoById(id);

            _mapper = SetupMapperA();
            DalEF.Concrete.AccountDalEf accDal = new DalEF.Concrete.AccountDalEf(_mapper);
            accDal.DeleteAccount(id);



        }
        public static void GetById()
        {
            Console.WriteLine("Id:");
            var id = Convert.ToInt32(Console.ReadLine());
            var _mapper = SetupMapperA();
            DalEF.Concrete.AccountDalEf accDal = new DalEF.Concrete.AccountDalEf(_mapper);
            var acc = accDal.GetAccountByID(id);

            _mapper = SetupMapperU();
            DalEF.Concrete.UserInfoDalEf uDal = new DalEF.Concrete.UserInfoDalEf(_mapper);
            var user = uDal.GetUserInfoById(id);

            Console.WriteLine("UserID \t"+ "UserLogin \t"+ "UserPassword \t"+ "Salt");
            Console.WriteLine("{0} \t{1} \t{2} \t{3}", acc.UserID,acc.UserLogin,acc.UserPassword,acc.Salt);
            Console.WriteLine("UserID \t" + "First Name \t" + "Last Name \t" + "Mobile phone \t" + "Gender \t" + "Banc card info if \t" + "Adress id \t");
            Console.WriteLine("{0} \t{1} \t{2} \t{3} \t{4} \t{5} \t{6} \t{7} \t", user.UserID, user.FirstName,
                user.LastName,
                user.MobilePhone,
                user.Gender,
                user.BankCardInfoID,
                user.AdressID
                );


        }
        public static void GetAll()
        {
            var _mapper = SetupMapperA();
            DalEF.Concrete.AccountDalEf accDal = new DalEF.Concrete.AccountDalEf(_mapper);
            var accs = accDal.GetAllAccounts();

            _mapper = SetupMapperU();
            DalEF.Concrete.UserInfoDalEf uDal = new DalEF.Concrete.UserInfoDalEf(_mapper);
            var users = uDal.GetAllUserInfo();


            Console.WriteLine("UserID \t" + "UserLogin \t" + "UserPassword \t" + "Salt");
            foreach (var acc in accs)
            {
                Console.WriteLine("{0} \t{1} \t{2} \t{3}", acc.UserID, acc.UserLogin, acc.UserPassword, acc.Salt);
            }
            Console.WriteLine("UserID \t" + "First Name \t" + "Last Name \t" + "Mobile phone \t" + "Gender \t" + "Banc card info if \t" + "Adress id \t");
           
            foreach (var user in users)
            {
                Console.WriteLine("{0} \t{1} \t{2} \t{3} \t{4} \t{5} \t{6} \t{7} \t", user.UserID, user.FirstName,
               user.LastName,
               user.MobilePhone,
               user.Gender,
               user.BankCardInfoID,
               user.AdressID
               );
            }
        }
        public static void Update()
        {
            Console.WriteLine("Id:");
            var id = Convert.ToInt32(Console.ReadLine());
            var _mapper = SetupMapperA();
            DalEF.Concrete.AccountDalEf accDal = new DalEF.Concrete.AccountDalEf(_mapper);
            var acc = accDal.GetAccountByID(id);

          
            
            Console.WriteLine("User Login:");
            var UserLogin = Console.ReadLine();
            Console.WriteLine("Password:");
            var UserPassword = Console.ReadLine();

            Console.WriteLine("First Name:");
            var FirstName = Console.ReadLine();
            Console.WriteLine("Last Name:");
            var LastName = Console.ReadLine();
            Console.WriteLine("Mobile Phone:");
            var MobilePhone = Console.ReadLine();
            Console.WriteLine("Gender(0,1)");
            var Gender = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Bank card info id:");
            var BankCardInfoID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Adress id:");
            var AdressID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Email:");
            var Email = Console.ReadLine();


            var Salt = "hwf3njTGG"; // some random salt

            byte[] bytes = Encoding.ASCII.GetBytes(UserPassword + Salt);
            byte[] pass;
            using (var crypt = SHA1.Create())
            {
                pass = crypt.ComputeHash(bytes);
            }
            acc.UserPassword = pass;
            acc.Salt = Salt;
            acc.UserLogin = UserLogin;
            accDal.UpdateAccount(acc);


            _mapper = SetupMapperU();
            DalEF.Concrete.UserInfoDalEf uDal = new DalEF.Concrete.UserInfoDalEf(_mapper);
            var user = uDal.GetUserInfoById(id);
            user.AdressID = AdressID;
            user.BankCardInfoID = BankCardInfoID;
            user.FirstName = FirstName;
            user.LastName = LastName;
            user.MobilePhone = MobilePhone;
            user.Gender = Gender;
            user.Email = Email;
            uDal.UpdateUserInfo(user);

        }
    }
}
