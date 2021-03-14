using Code.Models;
using Code.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Code.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IArticleService _service;

        public IndexModel(IArticleService service)
        {
            _service = service;
        }
        
        public Article LatestArticle { get; set; }

        public void OnGet()
        {
            LatestArticle = _service.GetLatestArticle();
        }
    }
}