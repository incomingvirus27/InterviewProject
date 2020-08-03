using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewProject.Models;
using Microsoft.AspNetCore.Identity;

namespace InterviewProject.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
       
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
       
        public int CoursesID { get; set; }
        public virtual Courses Courses { get; set; }
      
        public int BatchesID { get; set; }
        public virtual Batches Batches { get; set; }
       
    }
}
