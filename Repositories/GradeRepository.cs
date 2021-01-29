using System.Collections.Generic;
using RazorPageApp.Models;
using RazorPageApp.Repositories.Interfaces;

namespace RazorPageApp.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly IJsonFileHelper _helper;

        public GradeRepository(IJsonFileHelper helper)
        {
            _helper = helper;
        }

        public IEnumerable<Grade> GetGrades()
        {
            return _helper.Get<IEnumerable<Grade>>("Data/Grades.json");
        }
    }
}