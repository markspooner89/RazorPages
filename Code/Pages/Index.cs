using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Code.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Message { get; set; }

        [BindProperty]
        public bool IsMessageValid { get; set; }

        [TempData]
        public bool ShowMessageSubmitted { get; set; }

        public void OnGet()
        {
            Message = String.Empty;
            IsMessageValid = true;
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(Message))
            {
                IsMessageValid = false;
                return Page();
            }

            ShowMessageSubmitted = true;
            return RedirectToPage();
        }
    }
}