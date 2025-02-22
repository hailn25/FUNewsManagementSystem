using FUNewsManagementSystem.Models;

namespace FUNewsManagementSystem.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(short categoryID);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(short categoryID);
    }
}
