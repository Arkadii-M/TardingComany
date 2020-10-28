using BusinessLogic.Interfaces;
using DalEF.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class AdressManager:IAdressManager
    {
        private readonly IAdressDal _adressDal;
        public AdressManager(IAdressDal adressDal)
        {
            _adressDal = adressDal;
        }

        public AdressDTO AddAdress(int CountryId, string city, string street)
        {
            return _adressDal.CreateAdress(new AdressDTO { CountryID = CountryId, City = city, Street = street });
        }

        public List<AdressDTO> GetAllAdresses()
        {
            return _adressDal.GetAllAdresses();
        }
    }
}
