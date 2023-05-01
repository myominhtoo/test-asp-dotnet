using BasicCrud.DataLayer;
using BasicCrud.Models;

namespace BasicCrud.service
{
    public class CategoryService
    {

        private readonly CategoryRepository _categoryRepo;

        public CategoryService( CategoryRepository categoryRepo )
        {
            _categoryRepo = categoryRepo;
        }

        public List<Category> GetAll()
        {
            return _categoryRepo.GetAll();
        }

        public Category? GetCategoryById( int? categoryId )
        {
            return _categoryRepo.GetById(categoryId);
        }


        public bool SaveCategory( Category category )
        {
            try
            {
                _categoryRepo.Save(category);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateCategory( Category category )
        {
            try
            {
                _categoryRepo.Update(category);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCategory( int? categoryId )
        {
            try
            {
                _categoryRepo.DeleteById(categoryId);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
