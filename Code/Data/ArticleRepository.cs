using System.Collections.Generic;
using System.Linq;
using Code.Models;

namespace Code.Data
{
    public interface IArticleRepository
    {
        Article GetLatestArticle();
    }

    public class ArticleRepository : IArticleRepository
    {
        private readonly IJsonFileHelper _helper;

        public ArticleRepository(IJsonFileHelper helper)
        {
            _helper = helper;
        }

        public Article GetLatestArticle()
        {
            var articles = _helper.Get<IEnumerable<Article>>("Code/Data/Json/Articles.json");
            var article = articles.FirstOrDefault();
            return article;
        }
    }
}