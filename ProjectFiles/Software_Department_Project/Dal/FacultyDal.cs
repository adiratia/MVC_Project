using Software_Department_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Software_Department_Project.Dal
{
    public class FacultyDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Faculty>().ToTable("Faculty");
        }

        public DbSet<Faculty> Faculty { get; set; }
    }
}