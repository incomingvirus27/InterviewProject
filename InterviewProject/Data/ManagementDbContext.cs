using InterviewProject.Areas.Identity.Data;
using InterviewProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewProject.Data
{
    public class ManagementDbContext : IdentityDbContext<ApplicationUser>
    {
        public ManagementDbContext(DbContextOptions<ManagementDbContext> options) : base(options)
        {

        }
        public DbSet<Batches> BatchTable { get; set; }
        public DbSet<Courses> CourseTable { get; set; }
        public DbSet<Registration> RegistrationTable { get; set; }
        public DbSet<User> UserTable { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
