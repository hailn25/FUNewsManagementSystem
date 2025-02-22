using FUNewsManagementSystem.Models;
using FUNewsManagementSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FUNewsManagementSystem.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService) // Inject Service vào Controller
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }
        // GET: Category
        public ActionResult Index()
        {
            var categories = _categoryService.GetAllCategories();
            return View(categories);
        }

        // GET: Category/Details/5
        public ActionResult Details(short id)
        {
            var category = _categoryService.GetCategoryById(id);
            if(category == null) return NotFound();
            return View(category);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (!ModelState.IsValid) return View(category);

            _categoryService.AddCategory(category);
            return RedirectToAction(nameof(Index));
        }

        // GET: Category/Edit/5
        public ActionResult Edit(short id)
        {
            var category = _categoryService.GetCategoryById(id);
            if(category == null) return NotFound();
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (!ModelState.IsValid) return View(category);

            _categoryService.UpdateCategory(category);
            return RedirectToAction(nameof(Index));
        }

        // GET: Category/Delete/5
        public ActionResult Delete(short id)
        {
            var category = _categoryService.GetCategoryById(id);
            if(category == null) return NotFound();
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
