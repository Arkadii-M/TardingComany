using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IAdressManager
    {
        List<AdressDTO> GetAllAdresses();
        AdressDTO AddAdress(int CountryId,string city,string street);
    }
}
