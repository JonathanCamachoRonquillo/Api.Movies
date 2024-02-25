using Webapi.Nc7.Movies.Data;
using Webapi.Nc7.Movies.Models;
using Webapi.Nc7.Movies.Repository.IRepository;

namespace Webapi.Nc7.Movies.Repository
{
    public class RepositoryCategory : IRepositoryCategory
    {
        private readonly ApplicationDbContex _db;

        public RepositoryCategory(ApplicationDbContex dbContex)
        {
            _db = dbContex; 
        }

        public ICollection<Category> GetCategories()
        {
            return _db.Category.OrderBy(x => x.Name).ToList();    
        }

        public bool CreateCategory(Category categoryC)
        {
            categoryC.DateCreation = DateTime.Now;
            _db.Category.Add(categoryC);
            return Save();
        }

        public bool DeleteCategory(Category categorD)
        {
            _db.Category.Remove(categorD);
            return Save();
        }

        public bool ExistCategory(string categoryName)
        {
            bool exist = _db.Category.Any(x => x.Name.ToLower().Trim() == categoryName.ToLower().Trim());
            return exist;
        }

        public bool ExistCategory(int categoryId)
        {
            return _db.Category.Any(x => x.Id == categoryId);
        }

        public Category GetCategoryById(int categoryId)
        {
            return _db.Category.FirstOrDefault(x => x.Id == categoryId);
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0 ? true : false;
        }

        public bool UpdateCategory(Category categorU)
        {
            categorU.DateCreation = DateTime.Now;
            _db.Category.Update(categorU);
            return Save();
        }
    }
}
