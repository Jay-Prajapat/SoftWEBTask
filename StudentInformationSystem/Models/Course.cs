using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentInformationSystem.Models
{
    public class Course
    {
        [Required]
        public int CourseId { get; set; }
        [Required]
        public string CourseName { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}