using System.Collections.Generic;
using System.Linq;
using Code.Models;

namespace Code.Data
{
    public interface IGradeRepository
    {
        IEnumerable<Grade> GetGrades();
        Grade GetGrade(int id);
    }

    public class GradeRepository : IGradeRepository
    {
        private readonly IJsonFileHelper _helper;

        public GradeRepository(IJsonFileHelper helper)
        {
            _helper = helper;
        }

        private IEnumerable<Grade> GetGradesFromFile()
        {
            return _helper.Get<IEnumerable<Grade>>("Code/Data/Json/Grades.json");
        }  

        public IEnumerable<Grade> GetGrades()
        {
            var grades = GetGradesFromFile();
            return grades;
        }

        public Grade GetGrade(int id)
        {
            var grades = GetGradesFromFile();
            var grade = grades.FirstOrDefault(grade => grade.Id == id);
            return grade;
        }
    }
}