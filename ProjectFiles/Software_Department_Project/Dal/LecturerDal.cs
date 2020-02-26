using Software_Department_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Software_Department_Project.Dal
{
    public class LecturerDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Lecturer>().ToTable("Lecturer");
        }

        public DbSet<Lecturer> Lecturer { get; set; }
    }
}