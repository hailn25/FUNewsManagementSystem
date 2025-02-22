using FUNewsManagementSystem.DAO;
using FUNewsManagementSystem.Models;

namespace FUNewsManagementSystem.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ICategoryDAO _categoryDAO;

        public CategoryRepository(ICategoryDAO categoryDAO)
        {
            _categoryDAO = categoryDAO;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryDAO.GetAllCategories();
        }

        public Category GetCategoryById(short categoryID)
        {
            return _categoryDAO.GetCategoryById(categoryID);
        }

        public void AddCategory(Category category)
        {
            _categoryDAO.AddCategory(category);
        }

        public void UpdateCategory(Category category)
        {
            _categoryDAO.UpdateCategory(category);
        }

        public void DeleteCategory(short categoryID)
        {
            _categoryDAO.DeleteCategory(categoryID);
        }
    }
}
