using StudentInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Repository
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAllCourse();
        IEnumerable<Course> GetSelectedCourse(List<int> selectedCourseIds);
    }
}
