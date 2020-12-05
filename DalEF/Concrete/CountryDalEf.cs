using DalEF.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Data.Entity.Migrations;

namespace DalEF.Concrete
{

    public class CountryDalEf: ICountryDal
    {
        private readonly IMapper _mapper;
        public CountryDalEf(IMapper mapper)
        {
            _mapper = mapper;
        }

        public CountryDTO CreateCountry(CountryDTO country)
        {
            using (var e = new EntityTC())
            {
                Country c = _mapper.Map<Country>(country);
                e.Country.Add(c);
                e.SaveChanges();
                return _mapper.Map<CountryDTO>(c);
            }
        }

        public bool DeleteCountry(int id)
        {
            using (var e = new EntityTC())
            {
                var c = e.Country.SingleOrDefault(a => a.CountryID == id);
                if (c == null)
                {
                    return false;
                }
                e.Country.Remove(c);
                e.SaveChanges();
                return true;
            }
        }

        public List<CountryDTO> GetAllCountries()
        {
            using (var e = new EntityTC())
            {
                return _mapper.Map<List<CountryDTO>>(e.Country.ToList());
            }
        }

        public CountryDTO GetCountryByID(int id)
        {
            using (var e = new EntityTC())
            {
                var c = e.Country.SingleOrDefault(a => a.CountryID == id);
                if (c == null)
                {
                    return null;
                }
                return _mapper.Map<CountryDTO>(c);
            }
        }

        public CountryDTO UpdateCountry(CountryDTO country)
        {
            using (var e = new EntityTC())
            {
                e.Country.AddOrUpdate(_mapper.Map<Country>(country));
                e.SaveChanges();
                var c = e.Country.Single(p => p.CountryID == country.CountryID);
                return _mapper.Map<CountryDTO>(c);
            }
        }
    }
}
