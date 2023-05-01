using BasicCrud.Data;
using BasicCrud.Models;

namespace BasicCrud.DataLayer
{
    public class CategoryRepository
    {

        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db )
        {
            _db = db;
        }

        public List<Category> GetAll()
        {
            return _db.Categories.ToList();
        }

        public Category? GetById( int? id )
        {
            return _db.Categories.SingleOrDefault(category => category.Id.Equals(id));
        }

        public void Save( Category category )
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
        }

        public void Update( Category category )
        {
            _db.Categories.Update(category);
            _db.SaveChanges();
        }

        public void DeleteById( int? categoryId )
        {
            var category = GetById(categoryId);
            if (category == null)
                return;
            _db.Categories.Remove(category);
            _db.SaveChanges();
        }

    }
}
