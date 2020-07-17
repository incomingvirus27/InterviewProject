using InterviewProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewProject.Data
{
    public class ManagementDbContext : DbContext
    {
        public ManagementDbContext(DbContextOptions<ManagementDbContext> options) : base(options)
        {

        }
        public DbSet<Batches> BatchTable { get; set; }
        public DbSet<Courses> CourseTable { get; set; }
        public DbSet<Registration> RegistrationTable { get; set; }
        public DbSet<User> UserTable { get; set; }
    }
}
