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
        bool ExistsCategory(string categoryName);
        bool ExistsCategory(int categoryId);
        bool Save();
    }
}
