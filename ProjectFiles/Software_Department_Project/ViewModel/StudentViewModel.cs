using Software_Department_Project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Software_Department_Project.ViewModel
{
    public class StudentViewModel
    {
        public Student student { get; set; }
        public List<Courses> courses { get; set; }
        public List<StudentCourse> studentCourses { get; set; }

    }

}
