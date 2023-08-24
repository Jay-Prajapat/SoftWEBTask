using StudentInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student> GetStudentById(int id);
        Task UpdateStudentDatails(Student student);
        Task AddStudentDetails(Student student);
        Task DeleteStudent(int id);

        IEnumerable<Student> GetStudentDetailsBySearchValue(string searchValue); 
    }


}
