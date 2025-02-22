using FUNewsManagementSystem.Models;
using FUNewsManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FUNewsManagementSystem.Controllers
{
    public class NewsController : Controller
    {
        private readonly NewsService _newsService;
        // GET: NewsController
        public NewsController(NewsService newsService) // Inject Service vào Controller
        {
            _newsService = newsService ?? throw new ArgumentNullException(nameof(newsService));
        }


        public ActionResult Index()
        {
            // Lấy role từ cookies (Claim trong Authentication)
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            IEnumerable<NewsArticle> news;

            if (userRole == "Lecturer") // Role = 2
            {
                news = _newsService.GetActiveNews(); // Lấy bài viết active
            }
            else
            {
                news = _newsService.GetAllNewsArticle(); // Lấy tất cả bài viết
            }

            return View(news);
        }




        // GET: NewsController/Details/5
        [AllowAnonymous]
        public ActionResult Details(string id)
        {
            var news = _newsService.GetNewsArticleByID(id);
            if(news == null) return NotFound();
            return View(news);
        }

        // GET: NewsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewsArticle news)
        {
            if(!ModelState.IsValid)
                return View(news);

            _newsService.AddNewsArticle(news);
            return RedirectToAction(nameof(Index));

            
        }

        // GET: NewsController/Edit/5
        public ActionResult Edit(NewsArticle news)
        {
             _newsService.UpdateNewsArticle(news);
            return View();
        }

        // POST: NewsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: NewsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NewsController/Delete/5
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
