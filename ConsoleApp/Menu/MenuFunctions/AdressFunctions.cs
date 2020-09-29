using AutoMapper;
using DalEF.Concrete;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplicationTC.Menu.MenuFunctions
{
    static class AdressFunctions
    {
        private static IMapper SetupMapper()
        {
            MapperConfiguration conf = new MapperConfiguration(
                    cfg => cfg.AddMaps(typeof(AdressDalEf).Assembly)
                );
            return conf.CreateMapper();
        }
        public static void Create()
        {
            var _mapper = SetupMapper();
            DalEF.Concrete.AdressDalEf Dal = new DalEF.Concrete.AdressDalEf(_mapper);
            Console.WriteLine("City:");
            var city = Console.ReadLine();
            Console.WriteLine("Street:");
            var street = Console.ReadLine();
            Console.WriteLine("Country Id:");
            var cId = Convert.ToInt32(Console.ReadLine());
            var add = new AdressDTO() { City = city, Street = street, CountryID = cId };

        }
        public static void Delete()
        {
            Console.WriteLine("Id:");
            var id = Convert.ToInt32(Console.ReadLine());
            var _mapper = SetupMapper();
            DalEF.Concrete.AdressDalEf Dal = new DalEF.Concrete.AdressDalEf(_mapper);
            Dal.DeleteAdress(id);

        }
        public static void GetById()
        {
            Console.WriteLine("Id:");
            var id = Convert.ToInt32(Console.ReadLine());
            var _mapper = SetupMapper();
            DalEF.Concrete.AdressDalEf Dal = new DalEF.Concrete.AdressDalEf(_mapper);
            var addr = Dal.GetAdressByID(id);
            
            Console.WriteLine("AdressID \t"+ "CountryID \t"+ "City \t"+ "Street \t");
            Console.WriteLine("{0} \t{1} \t{2} \t{3} \t",addr.AdressID,addr.CountryID,addr.City,addr.Street);

        }
        public static void GetAll()
        {
            var _mapper = SetupMapper();
            DalEF.Concrete.AdressDalEf Dal = new DalEF.Concrete.AdressDalEf(_mapper);
            var adresses = Dal.GetAllAdresses();
            Console.WriteLine("AdressID \t" + "CountryID \t" + "City \t" + "Street \t");
            foreach (var addr in adresses)
            {
                Console.WriteLine("{0} \t{1} \t{2} \t{3} \t", addr.AdressID, addr.CountryID, addr.City, addr.Street);
            }
        }
        public static void Update()
        {
            Console.WriteLine("Id:");
            var id = Convert.ToInt32(Console.ReadLine());
            var _mapper = SetupMapper();
            DalEF.Concrete.AdressDalEf Dal = new DalEF.Concrete.AdressDalEf(_mapper);
            var addr = Dal.GetAdressByID(id);
            Console.WriteLine("County id:");
            var c_id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("City:");
            var city = Console.ReadLine();
            Console.WriteLine("Street:");
            var street = Console.ReadLine();
            addr.City = city;
            addr.Street = street;
            addr.CountryID = c_id;

            Dal.UpdateAdress(addr);
        }
    }
}
