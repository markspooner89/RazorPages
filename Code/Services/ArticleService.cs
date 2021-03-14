using System;
using System.Collections.Generic;
using Code.Models;
using Code.Data;

namespace Code.Services
{
    public interface IArticleService
    {
        Article GetLatestArticle();
    }

    public class ArtliceService : IArticleService
    {
        private readonly ICacheHelper _helper;
        private readonly IArticleRepository _repository;

        public ArtliceService(ICacheHelper helper, IArticleRepository repository)
        {
            _helper = helper;
            _repository = repository;
        }

        public Article GetLatestArticle()
        {
            return _helper.GetAndCache<Article>(
                cacheKey: "latestArticle",
                func: () => _repository.GetLatestArticle(),
                slidingExpiration: TimeSpan.FromMinutes(1),
                absoluteExpiration: TimeSpan.FromMinutes(60)
            );
        }
    } 
}