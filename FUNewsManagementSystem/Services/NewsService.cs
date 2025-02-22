using FUNewsManagementSystem.Models;
using FUNewsManagementSystem.Repositories;

namespace FUNewsManagementSystem.Services
{
    public class NewsService
    {
        private readonly INewsRepository _newsRepository;

        public NewsService (INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public IEnumerable<NewsArticle> GetAllNewsArticle()
        {
            return _newsRepository.GetAllNewsArticles();
        }

        public IEnumerable<NewsArticle> GetActiveNews()
        {
            return _newsRepository.GetActiveNewsArticles();
        }

        public NewsArticle GetNewsArticleByID(string id)
        {
            return _newsRepository.GetNewsArticleByID(id);
        }

        public void AddNewsArticle(NewsArticle article)
        {
             _newsRepository.AddNewsArticle(article);
        }

        public void UpdateNewsArticle(NewsArticle article)
        {
            _newsRepository.UpdateNewsArticle(article);
        }

        public void DeleteNewsArticle(string id)
        {
            _newsRepository.DeleteNewsArticle(id);
        }

    }
}
