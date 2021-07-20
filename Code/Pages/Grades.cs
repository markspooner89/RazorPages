using System;
using System.Collections.Generic;
using Code.Models;
using Code.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Code.Pages
{
    public class GradesModel : PageModel
    {
        private readonly IGradeService _gradeService;

        public GradesModel(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [BindProperty]
        public bool ShowKorean { get; set; }

        [BindProperty]
        public IEnumerable<Grade> Grades { get; set; }
        
        public void OnGet()
        {
            ShowKorean = true;
            Grades = _gradeService.GetGrades();
        }

        public void OnPost()
        {
            var postedShowKorean = Convert.ToBoolean(Request.Form["ShowKorean"]);
            this.ShowKorean = !postedShowKorean;
        }
    }
}