using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageApp.Models;
using RazorPageApp.Services.Interfaces;

namespace RazorPageApp.Pages
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