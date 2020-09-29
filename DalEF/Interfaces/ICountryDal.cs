using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DalEF.Interfaces
{
    public interface ICountryDal
    {
        CountryDTO GetCountryByID(int id);
        List<CountryDTO> GetAllCountries();
        CountryDTO CreateCountry(CountryDTO country);

        CountryDTO UpdateCountry(CountryDTO country);
        bool DeleteCountry(int id);
    }
}
