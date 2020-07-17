using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewProject.Models
{
    public class Registration
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your first name"), Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name"), Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your course id"), Display(Name = "Course Id")]
        public int CoursesID { get; set; }
        public virtual Courses Courses { get; set; }
        [Required(ErrorMessage = "Please enter your batche id")]
        public int BatchesID { get; set; }
        public virtual Batches Batches { get; set; }
        [Required(ErrorMessage = "Please enter a valid phone number"), Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
