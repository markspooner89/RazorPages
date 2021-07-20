using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Code.Pages
{
    public class GradeModel : PageModel
    {
        public int Id { get; set; }
        public void OnGet()
        {
            var success = int.TryParse(Request.Query["id"], out var id);

            if (success)
            {
                Id = id;
            }
            else
            {
                Id = -1;
            }
        }
    }
}