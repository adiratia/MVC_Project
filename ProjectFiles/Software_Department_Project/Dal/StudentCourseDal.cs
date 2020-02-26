using Software_Department_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Software_Department_Project.Dal
{
    public class StudentCourseDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StudentCourse>().ToTable("StudentCourse");
        }

        public DbSet<StudentCourse> StudentCourses { get; set; }
    }
}