using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Code.Models;
using Code.Services;

namespace Code.Pages
{
    public class GradesModel : PageModel
    {
        private readonly IGradeService _service;

        public GradesModel(IGradeService service)
        {
            _service = service;
        }
        
        public IEnumerable<Grade> Grades { get; set; }

        public void OnGet()
        {
            Grades = _service.GetGrades();
        }
    }
}