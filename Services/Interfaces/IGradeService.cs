using System.Collections.Generic;
using RazorPageApp.Models;

namespace RazorPageApp.Services.Interfaces
{
    public interface IGradeService
    {
        IEnumerable<Grade> GetGrades();
    }
}