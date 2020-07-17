using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewProject.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your first name"), Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name"), Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your user name"), Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter your password"), DataType(DataType.Password)]
        public string Password { get; set; }


    }
}
