using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentInformationSystem.Models
{
    public class Student
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z ]+$", ErrorMessage = "Student name contains alphabets only.")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [Display(Name ="Birth Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        public bool IsDeleted { get; set; }
        
        public ICollection<Course> Courses { get; set; }


    }
}