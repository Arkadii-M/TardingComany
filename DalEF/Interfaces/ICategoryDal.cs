using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DalEF.Interfaces
{
    public interface ICategoryDal
    {
        CategoryDTO GetCategoryByID(int id);
        List<CategoryDTO> GetAllCategories();
        CategoryDTO CreateCategory(CategoryDTO category);
        CategoryDTO UpdateCategory(CategoryDTO category);
        bool DeleteCategory(int id);
    }
}
