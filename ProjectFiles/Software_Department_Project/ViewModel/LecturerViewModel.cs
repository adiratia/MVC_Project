using Software_Department_Project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Software_Department_Project.ViewModel
{
    public class LecturerViewModel
    {
        public DataTable data { get; set; }

        public Lecturer lecturer { get; set; }
        public List<Courses> courses { get; set; }


    }
}