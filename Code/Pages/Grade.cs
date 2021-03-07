using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Code.Models;
using Code.Services;
using System;

namespace Code.Pages
{
    public class GradeModel : PageModel
    {
        private readonly IGradeService _service;

        public GradeModel(IGradeService service)
        {
            _service = service;
        }
        
        [BindProperty]
        public Grade Grade { get; set; }

        public IActionResult OnGet()
        {
            try 
            {
                var hasParam = int.TryParse(Request.Query["id"], out var id);

                if (hasParam)
                {
                    var result = _service.GetGrade(id);
                    if (result != null)
                    {
                        Grade = result;
                        return Page();
                    }
                    else
                    {
                        return RedirectToPage("NotFound");
                    }
                }
                else
                {
                    return RedirectToPage("NotFound");
                }
            }
            catch
            {
                return RedirectToPage("Error");
            }
        }
    }
}