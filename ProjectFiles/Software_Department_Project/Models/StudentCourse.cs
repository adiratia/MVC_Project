using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Software_Department_Project.Models
{
    public class StudentCourse
    {
        [Key , Column(Order=0)]
        [Required]

        public string StudentID { get; set; }
        [Key, Column(Order = 1)]
        [Required]
        public string CourseName { get; set; }
        public int Grade { get; set; }



    }
}