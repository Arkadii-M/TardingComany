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
    public class CategoryDalEf : ICategoryDal
    {
        private readonly IMapper _mapper;
        public CategoryDalEf(IMapper mapper)
        {
            _mapper = mapper;
        }
        public CategoryDTO CreateCategory(CategoryDTO category)
        {
            using (var e = new EntityTC())
            {
                Category c = _mapper.Map<Category>(category);
                e.Category.Add(c);
                e.SaveChanges();
                return _mapper.Map<CategoryDTO>(c);
            }
        }

        public bool DeleteCategory(int id)
        {
            using (var e = new EntityTC())
            {
                var c = e.Category.SingleOrDefault(a => a.CategoryID == id);
                if (c == null)
                {
                    return false;
                }
                e.Category.Remove(c);
                e.SaveChanges();
                return true;
            }
        }

        public List<CategoryDTO> GetAllCategories()
        {
            using (var e = new EntityTC())
            {
                return _mapper.Map<List<CategoryDTO>>(e.Category.ToList());
            }
        }

        public CategoryDTO GetCategoryByID(int id)
        {
            using (var e = new EntityTC())
            {
                var c = e.Category.SingleOrDefault(a => a.CategoryID == id);
                if (c == null)
                {
                    return null;
                }
                return _mapper.Map<CategoryDTO>(c);
            }
        }

        public CategoryDTO UpdateCategory(CategoryDTO category)
        {
            using (var e = new EntityTC())
            {
                e.Category.AddOrUpdate(_mapper.Map<Category>(category));
                e.SaveChanges();
                var c = e.Category.Single(p => p.CategoryID == category.CategoryID);
                return _mapper.Map<CategoryDTO>(c);
            }
        }
    }
}
