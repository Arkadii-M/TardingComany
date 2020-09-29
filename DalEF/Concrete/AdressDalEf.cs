using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalEF.Profiles;
using AutoMapper;
using System.Data.Entity.Migrations;
using DalEF.Interfaces;

namespace DalEF.Concrete
{
    public class AdressDalEf : IAdressDal
    {
        private readonly IMapper _mapper;
        public AdressDalEf(IMapper mapper)
        {
            _mapper = mapper;
        }
        public AdressDTO CreateAdress(AdressDTO adress)
        {
            using (var e = new Traiding_CompanyEntities2())
            {
                Adress add = _mapper.Map<Adress>(adress);
                e.Adress.Add(add);
                e.SaveChanges();
                return _mapper.Map<AdressDTO>(add);
            }
        }

        public bool DeleteAdress(int id)
        {
            using (var e = new Traiding_CompanyEntities2())
            {
                var add = e.Adress.SingleOrDefault(a => a.AdressID == id);
                if (add == null)
                {
                    return false;
                }
                e.Adress.Remove(add);
                e.SaveChanges();
                return true;
            }
        }

        public AdressDTO GetAdressByID(int id)
        {
            using (var e = new Traiding_CompanyEntities2())
            {
                var add = e.Adress.SingleOrDefault(a => a.AdressID == id);
                if (add == null)
                {
                    return null;
                }
                return _mapper.Map<AdressDTO>(add);
            }
        }

        public List<AdressDTO> GetAllAdresses()
        {
            using (var e = new Traiding_CompanyEntities2())
            {
                return _mapper.Map<List<AdressDTO>>(e.Adress.ToList());
            }
        }

        public AdressDTO UpdateAdress(AdressDTO adress)
        {
            using (var e = new Traiding_CompanyEntities2())
            {
                e.Adress.AddOrUpdate(_mapper.Map<Adress>(adress));
                e.SaveChanges();
                var add = e.Adress.Single(p => p.AdressID == adress.AdressID);
                return _mapper.Map<AdressDTO>(add);
            }
        }
    }
}
