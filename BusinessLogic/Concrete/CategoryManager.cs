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
    public class CategoryManager: ICategoryManager
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<CategoryDTO> GetAllCategories()
        {
            return _categoryDal.GetAllCategories();
        }
    }
}
