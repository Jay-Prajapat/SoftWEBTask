using PagedList;
using StudentInformationSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PagedList;
using StudentInformationSystem.Models;

namespace StudentInformationSystem.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        public StudentController()
        {
            _studentRepository = new StudentRepository();
            _courseRepository = new CourseRepository();
        }
        // GET: Student
        public async Task<ActionResult> Index(int? page)
        {
            var students = await _studentRepository.GetAllStudents();
            return View(students.ToList().ToPagedList(page ?? 1,5));
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Courses = _courseRepository.GetAllCourse();
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Student student,List<int> selectedCourseIds)
        {
            var selectedCourses = _courseRepository.GetSelectedCourse(selectedCourseIds);
            student.Courses = (ICollection<Course>)selectedCourses;
            if (ModelState.IsValid)
            { 
                await _studentRepository.AddStudentDetails(student);
                return RedirectToAction("Index");
            }
            ViewBag.Courses = _courseRepository.GetAllCourse();
            ModelState.AddModelError("", "Model State is not valid!!!");
            return View(student);
        }
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var student = await _studentRepository.GetStudentById(id);
            return View(student);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Student student)
        {
            await _studentRepository.DeleteStudent(student.StudentId);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var student = await _studentRepository.GetStudentById(id);
            ViewBag.Courses = _courseRepository.GetAllCourse();
            List<int> selectedCourseIds = student.Courses.Select(c => c.CourseId).ToList();
            ViewBag.SelectedCourseIds = selectedCourseIds;
            return View(student);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Student student, List<int> selectedCourseIds)
        {
            if (ModelState.IsValid)
            {
                var selectedCourses = _courseRepository.GetSelectedCourse(selectedCourseIds);
                student.Courses = (ICollection<Course>)selectedCourses;
                await _studentRepository.UpdateStudentDatails(student);
                return RedirectToAction("Index");
            }
            ViewBag.Courses = _courseRepository.GetAllCourse();
            ViewBag.SelectedCourseIds = selectedCourseIds;
            ModelState.AddModelError("", "Model State is not valid!!!");
            return View(student);
        }
        
        public ActionResult GetStudentsBySearchValue(string searchValue,int? page)
        {
            var result = _studentRepository.GetStudentDetailsBySearchValue(searchValue).ToPagedList(page ?? 1, 5);
            return PartialView("_GetStudentData", result);
        }



    }
}