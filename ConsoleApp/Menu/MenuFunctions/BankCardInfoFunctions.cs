using AutoMapper;
using DalEF;
using DalEF.Concrete;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConsoleApplicationTC.Menu.MenuFunctions
{
    static class BankCardInfoFunctions
    {
        private static IMapper SetupMapper()
        {
            MapperConfiguration conf = new MapperConfiguration(
                    cfg => cfg.AddMaps(typeof(BankCardInfoDalEf).Assembly)
                );
            return conf.CreateMapper();
        }
        public static void Create()
        {
            
            Console.WriteLine("Bank Id:");
            var bankid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Card number:");
            var CardNum = Console.ReadLine();
            Console.WriteLine("Cvv:");
            var Cvv = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Extend Date:");
            var Date = Console.ReadLine();

           
            var cardInfo = new BankCardInfoDTO() { BankID = bankid, CardNumber = CardNum, CVV = Cvv,ExtendDate =Convert.ToDateTime(Date)};
            var _mapper = SetupMapper();
            DalEF.Concrete.BankCardInfoDalEf dal = new BankCardInfoDalEf(_mapper);
            dal.CreateBankCardInfo(cardInfo);
            
        }
        public static void Delete()
        {
            Console.WriteLine("Id:");
            var id = Convert.ToInt32(Console.ReadLine());
         
            var _mapper = SetupMapper();
            DalEF.Concrete.BankCardInfoDalEf dal = new BankCardInfoDalEf(_mapper);
            dal.DeleteBankCardInfoById(id);
        }
        public static void GetById()
        {
            
            Console.WriteLine("Id:");
            var id = Convert.ToInt32(Console.ReadLine());

            var _mapper = SetupMapper();
            DalEF.Concrete.BankCardInfoDalEf dal = new BankCardInfoDalEf(_mapper);
            var res = dal.GetBankCardInfoById(id);
            Console.WriteLine("BankCardInfoID \t" + "BankID \t" + "CardNumber \t" + " CVV \t" + "ExtendDate \t");
            Console.WriteLine("{0} \t {1} \t{2} \t{3} \t{4} \t", res.BankCardInfoID,res.BankID,res.CardNumber,res.CVV, res.ExtendDate);
            
        }
        public static void GetAll()
        {
            
            var _mapper = SetupMapper();
            DalEF.Concrete.BankCardInfoDalEf dal = new BankCardInfoDalEf(_mapper);
            var all_res = dal.GetAllBankCardInfo();
            Console.WriteLine("BankCardInfoID \t" + "BankID \t" + "CardNumber \t" + " CVV \t" + "ExtendDate \t");
            foreach (var res in all_res)
            {
                Console.WriteLine("{0} \t {1} \t{2} \t{3} \t{4} \t", res.BankCardInfoID, res.BankID, res.CardNumber, res.CVV, res.ExtendDate.ToString());
            }
            
        }
        public static void Update()
        {
            
            Console.WriteLine("Id:");

            var id = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Bank Id:");
            var bankid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Card number:");
            var CardNum = Console.ReadLine();
            Console.WriteLine("Cvv:");
            var Cvv = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Extend Date(month/year):");
            var Date = Console.ReadLine();
            var _mapper = SetupMapper();
            DalEF.Concrete.BankCardInfoDalEf dal = new BankCardInfoDalEf(_mapper);
            var Card = dal.GetBankCardInfoById(id);
            Card.BankID = bankid;
            Card.CVV = Cvv;
            Card.CardNumber = CardNum;
            Card.ExtendDate = Convert.ToDateTime(Date);
            dal.UpdateBankCardInfo(Card);
            

        }

      
    }
}
