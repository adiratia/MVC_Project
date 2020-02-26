using Software_Department_Project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Software_Department_Project.ViewModel
{
    public class FacultyViewModel
    {

        public List<Student> Studentsdata { get; set; }
        public List<Courses> Coursesdata { get; set; }
        public List<Lecturer> LecturersData { get; set; }



        public Faculty faculty { get; set; }

    }
}