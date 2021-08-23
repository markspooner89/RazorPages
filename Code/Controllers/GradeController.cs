using Code.Services;
using Microsoft.AspNetCore.Mvc;

namespace Code.Controllers
{
    [Route("api/Grade")]
    public class GradeController : Controller
    {
        private readonly IGradeService _gradeService;

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var grades = _gradeService.GetGrades();
            return Ok(grades);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var grade = _gradeService.GetGrade(id);
            return Ok(grade);
        }
    }
}