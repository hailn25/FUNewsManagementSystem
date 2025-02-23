using FUNewsManagementSystem.Models;

namespace FUNewsManagementSystem.DAO
{
    public interface INewsDAO
    {
        IEnumerable<NewsArticle> GetAllNewsArticles();
        IEnumerable<NewsArticle> GetActiveNewsArticles();
        NewsArticle GetNewsArticleByID(string id);
        void AddNewsArticle(NewsArticle newsArticle);
        void UpdatingNewsArticle(NewsArticle newsArticle);
        void DeleteNewsArticle(string id);

    }
}
