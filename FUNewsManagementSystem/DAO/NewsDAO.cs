using FUNewsManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace FUNewsManagementSystem.DAO
{
    public class NewsDAO : INewsDAO
    {
        private readonly FunewsManagementContext _context;

        public NewsDAO(FunewsManagementContext context)
        {
            _context = context;
        }

        public IEnumerable<NewsArticle> GetAllNewsArticles()
        {
            return _context.NewsArticles
                .Include(n => n.Category)
                .Include(n => n.CreatedBy)
                .ToList();
        }

        public IEnumerable<NewsArticle> GetActiveNewsArticles()
        {
            return _context.NewsArticles
                .Where(n => n.NewsStatus == true)
                .Include(n => n.Category)
                .Include(n => n.CreatedBy)
                .ToList();
        }


        public NewsArticle GetNewsArticleByID(string id)
        {
            return _context.NewsArticles.Find(id);
        }

        public void AddNewsArticle(NewsArticle newsArticle)
        {
            _context.NewsArticles.Add(newsArticle);
            _context.SaveChanges();
        }

        public void UpdatingNewsArticle(NewsArticle newsArticle)
        {
            _context.NewsArticles.Update(newsArticle);
            _context.SaveChanges();
        }



        public void DeleteNewsArticle(string id)
        {
            //var news = _context.NewsArticles.Find(id);
            //if (news != null)
            //{
            //    _context.NewsArticles.Remove(news);
            //    _context.SaveChanges();
            //}
        }


       
    }
}
