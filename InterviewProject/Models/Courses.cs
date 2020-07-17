using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewProject.Models
{
    public class Courses
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your course name")]        
        public string Name { get; set; }        
        public int Duration { get; set; }
    }
}
