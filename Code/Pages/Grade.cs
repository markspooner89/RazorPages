using Code.Models;
using Code.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Code.Pages
{
    public class GradeModel : PageModel
    {
        private IGradeService _gradeService;

        public GradeModel(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }
        
        public Grade Grade { get; set; }
        
        public void OnGet()
        {
            var success = int.TryParse(Request.Query["id"], out var id);

            if (success)
            {
                Grade = _gradeService.GetGrade(id);
            }
        }
    }
}