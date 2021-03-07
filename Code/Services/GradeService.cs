using System;
using System.Collections.Generic;
using Code.Models;
using Code.Data;

namespace Code.Services
{
    public interface IGradeService
    {
        IEnumerable<Grade> GetGrades();
        Grade GetGrade(int id);
    }

    public class GradeService : IGradeService
    {
        private readonly ICacheHelper _helper;
        private readonly IGradeRepository _repository;

        public GradeService(ICacheHelper helper, IGradeRepository repository)
        {
            _helper = helper;
            _repository = repository;
        }

        public IEnumerable<Grade> GetGrades()
        {
            return _helper.GetAndCache<IEnumerable<Grade>>(
                cacheKey: "grades", 
                func: () => _repository.GetGrades(), 
                slidingExpiration: TimeSpan.FromMinutes(1), 
                absoluteExpiration: TimeSpan.FromMinutes(60));
        }

        public Grade GetGrade(int id)
        {
            return _repository.GetGrade(id);
        }
    } 
}