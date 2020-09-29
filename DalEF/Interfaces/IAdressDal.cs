using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DalEF.Interfaces
{
    public interface IAdressDal
    {
        AdressDTO GetAdressByID(int id);
        List<AdressDTO> GetAllAdresses();
        AdressDTO CreateAdress(AdressDTO adress);

        AdressDTO UpdateAdress(AdressDTO adress);
        bool DeleteAdress(int id);
    }
}
