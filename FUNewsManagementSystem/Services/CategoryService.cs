using FUNewsManagementSystem.Models;
using FUNewsManagementSystem.Repositories;

namespace FUNewsManagementSystem.Services
{
    public class CategoryService 
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }

        public Category GetCategoryById(short categoryId)
        {
            return _categoryRepository.GetCategoryById(categoryId);
        }

        public void AddCategory(Category category)
        {
            _categoryRepository.AddCategory(category);
        }

        public void UpdateCategory(Category category)
        {
            _categoryRepository.UpdateCategory(category);
        }

        public void DeleteCategory(short categoryId)
        {
            _categoryRepository.DeleteCategory(categoryId);
        }
    }
}
