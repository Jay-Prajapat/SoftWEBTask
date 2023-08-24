using StudentInformationSystem.DAL;
using StudentInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace StudentInformationSystem.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDBEntity _dbContext;
        public StudentRepository()
        {
            _dbContext = StudentDataAccess.GetInstance();
        }
        public async Task AddStudentDetails(Student student)
        {
            _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteStudent(int id)
        {
            var student = await _dbContext.Students.Include(s => s.Courses).FirstOrDefaultAsync(s => s.StudentId == id && s.IsDeleted == false);
            student.IsDeleted = true;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _dbContext.Students.Include(s => s.Courses).Where(s => s.IsDeleted == false).ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _dbContext.Students.Include(s => s.Courses).SingleOrDefaultAsync(s => s.StudentId == id && s.IsDeleted == false);
        }

        public IEnumerable<Student> GetStudentDetailsBySearchValue(string searchValue)
        {
            return _dbContext.Students.Where(s => (s.Name.Contains(searchValue) && s.IsDeleted == false)).ToList();
        }

        public async Task UpdateStudentDatails(Student student)
        {
            if(student != null)
            {
                //_dbContext.Students.AddOrUpdate(student);
                Student updateStudent = await  _dbContext.Students.Include(s => s.Courses).SingleOrDefaultAsync(s => s.StudentId == student.StudentId && s.IsDeleted == false);
                updateStudent.Email = student.Email;
                updateStudent.BirthDate = student.BirthDate;
                updateStudent.Country = student.Country;
                updateStudent.City = student.City;
                updateStudent.Gender = student.Gender;
                updateStudent.Address = student.Address;
                updateStudent.Name = student.Name;
                updateStudent.IsDeleted = updateStudent.IsDeleted;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}