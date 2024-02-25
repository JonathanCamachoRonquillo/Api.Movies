using Webapi.Nc7.Movies.Models;

namespace Webapi.Nc7.Movies.Repository.IRepository
{
    public interface IRepositoryCategory
    {
        ICollection<Category> GetCategories();
        Category GetCategoryById(int categoryId);
        bool CreateCategory(Category categoryC);
        bool UpdateCategory(Category categorU);
        bool DeleteCategory(Category categorD);
        bool ExistCategory(string categoryName);
        bool ExistCategory(int categoryId);
        bool Save();
    }
}
