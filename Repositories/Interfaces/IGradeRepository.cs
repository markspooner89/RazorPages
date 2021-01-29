using System.Collections.Generic;
using RazorPageApp.Models;

namespace RazorPageApp.Repositories.Interfaces
{
    public interface IGradeRepository
    {
        IEnumerable<Grade> GetGrades();
    }
}