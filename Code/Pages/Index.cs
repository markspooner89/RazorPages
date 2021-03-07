using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Code.Models;
using Code.Services;

namespace Code.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IGradeService _service;

        public IndexModel(IGradeService service)
        {
            _service = service;
        }
        
        [BindProperty]
        public IEnumerable<Grade> Grades { get; set; }

        public void OnGet()
        {
            Grades = _service.GetGrades();
        }
    }
}