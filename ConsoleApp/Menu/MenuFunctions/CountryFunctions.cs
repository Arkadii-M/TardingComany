using AutoMapper;
using DalEF.Concrete;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplicationTC.Menu.MenuFunctions
{
    static class CountryFunctions
    {
        private static IMapper SetupMapper()
        {
            MapperConfiguration conf = new MapperConfiguration(
                    cfg => cfg.AddMaps(typeof(CountryDalEf).Assembly)
                );
            return conf.CreateMapper();
        }
        public static void Create()
        {
            Console.WriteLine("Enter country Name:");
            var name = Console.ReadLine();

            var country = new CountryDTO() { Name = name };

            var _mapper = SetupMapper();
            DalEF.Concrete.CountryDalEf Dal = new DalEF.Concrete.CountryDalEf(_mapper);
            var res = Dal.CreateCountry(country);
        }
        public static void Delete()
        {
            Console.WriteLine("Enter country id:");
            var id = Convert.ToInt32(Console.ReadLine());


            var _mapper = SetupMapper();
            DalEF.Concrete.CountryDalEf Dal = new DalEF.Concrete.CountryDalEf(_mapper);
            var res = Dal.GetCountryByID(id);
        }
        public static void GetById()
        {
            Console.WriteLine("Enter country id:");
            var id = Convert.ToInt32(Console.ReadLine());


            var _mapper = SetupMapper();
            DalEF.Concrete.CountryDalEf Dal = new DalEF.Concrete.CountryDalEf(_mapper);
            var res = Dal.GetCountryByID(id);
            Console.WriteLine("CountryID \t"+"Country Name");
            Console.WriteLine("{0} \t {1}",res.CountryID,res.Name);
        }
        public static void GetAll()
        {
            var _mapper = SetupMapper();
            DalEF.Concrete.CountryDalEf Dal = new DalEF.Concrete.CountryDalEf(_mapper);
            var res = Dal.GetAllCountries();
            Console.WriteLine("CountryID \t" + "Country Name");
            foreach (var c in res)
            {
                Console.WriteLine("{0} \t {1}", c.CountryID, c.Name);
            }

        }
        public static void Update()
        {
            Console.WriteLine("Enter country id:");
            var id = Convert.ToInt32(Console.ReadLine());


            var _mapper = SetupMapper();
            DalEF.Concrete.CountryDalEf Dal = new DalEF.Concrete.CountryDalEf(_mapper);
            var res = Dal.GetCountryByID(id);
            Console.WriteLine("CountryID \t" + "Country Name");
            Console.WriteLine("{0} \t {1}", res.CountryID, res.Name);

            Console.WriteLine("New Name: ");
            var name = Console.ReadLine();
            res.Name = name;
            Dal.UpdateCountry(res);
        }
    }
}
