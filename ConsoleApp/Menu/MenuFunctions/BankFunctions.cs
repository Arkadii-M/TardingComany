using AutoMapper;
using DalEF;
using DalEF.Concrete;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplicationTC.Menu.MenuFunctions
{
    static class BankFunctions
    {
        private static IMapper SetupMapper()
        {
            MapperConfiguration conf = new MapperConfiguration(
                    cfg => cfg.AddMaps(typeof(BankDalEf).Assembly)
                );
            return conf.CreateMapper();
        }

        public static void Create()
        {
            Console.WriteLine("Enter bank name:");
            var name = Console.ReadLine();
            Console.WriteLine("Enter bank swift:");
            var swift = Console.ReadLine();
            var bank = new BankDTO() { Name = name, Swift = swift };
            var _mapper = SetupMapper();
            DalEF.Concrete.BankDalEf bankDal = new DalEF.Concrete.BankDalEf(_mapper);
            bankDal.CreateBank(bank);
        }
        public static void Delete()
        {
            Console.WriteLine("Enter bank id:");
            var id = Convert.ToInt32(Console.ReadLine());
            var _mapper = SetupMapper();
            DalEF.Concrete.BankDalEf bankDal = new DalEF.Concrete.BankDalEf(_mapper);
            bankDal.DeleteBankById(id);

        }
        public static void GetById()
        {
            Console.WriteLine("Enter bank id:");
            var id = Convert.ToInt32(Console.ReadLine());
            var _mapper = SetupMapper();
            DalEF.Concrete.BankDalEf bankDal = new DalEF.Concrete.BankDalEf(_mapper);
            var bank =bankDal.GetBankById(id);
            Console.WriteLine("BankID \t" + "Name \t"+ "Swift");
            Console.WriteLine("{0} \t {1} \t {2}", bank.BankID,bank.Name, bank.Swift);

        }
        public static void GetAll()
        {
            var _mapper = SetupMapper();
            DalEF.Concrete.BankDalEf bankDal = new DalEF.Concrete.BankDalEf(_mapper);
            var banks = bankDal.GetAllBanks();
            Console.WriteLine("BankID \t" + "Name \t" + "Swift");
            foreach (var bank in banks)
            {
                Console.WriteLine("{0} \t {1} \t {2}", bank.BankID, bank.Name, bank.Swift);
            }

        }
        public static void Update()
        {
            Console.WriteLine("Enter bank id:");
            var id = Convert.ToInt32(Console.ReadLine());
            var _mapper = SetupMapper();
            DalEF.Concrete.BankDalEf bankDal = new DalEF.Concrete.BankDalEf(_mapper);
            var bank = bankDal.GetBankById(id);
            Console.WriteLine("Enter bank name:");
            var name = Console.ReadLine();
            bank.Name = (name != "") ? name : bank.Name;
            Console.WriteLine("Enter swift name:");
            var swift = Console.ReadLine();
            bank.Swift = (swift != "") ? swift : bank.Swift;
            bankDal.UpdateBank(bank);

        }
    }
}
