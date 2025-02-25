﻿using FUNewsManagementSystem.Models;

namespace FUNewsManagementSystem.Repositories
{
    public interface INewsRepository
    {
        IEnumerable<NewsArticle> GetAllNewsArticles();
        IEnumerable<NewsArticle> GetActiveNewsArticles();
       
        NewsArticle GetNewsArticleByID(string id);
        void AddNewsArticle(NewsArticle article);
        void UpdateNewsArticle(NewsArticle article);
        void DeleteNewsArticle(string id);
        NewsArticle GetLastNewsArticle();
    }
}
