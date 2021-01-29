using System;
using System.Collections.Generic;
using RazorPageApp.Models;
using RazorPageApp.Repositories.Interfaces;
using RazorPageApp.Services.Interfaces;

namespace RazorPageApp.Services
{
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
    } 
}