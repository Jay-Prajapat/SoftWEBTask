using StudentInformationSystem.DAL;
using StudentInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace StudentInformationSystem.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly StudentDBEntity _dbContext;
        public CourseRepository()
        {
            _dbContext = StudentDataAccess.GetInstance();
        }
        public IEnumerable<Course> GetAllCourse()
        {
            return _dbContext.Courses.ToList();
        }

        public IEnumerable<Course> GetSelectedCourse(List<int> selectedCourseIds)
        {
            return _dbContext.Courses.Where(c => selectedCourseIds.Contains(c.CourseId)).ToList();
        }
    }
}