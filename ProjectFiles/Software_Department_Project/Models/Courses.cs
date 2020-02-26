using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Software_Department_Project.Models
{
    public class Courses
    {
        [Required]

        public string CourseName { get; set; }
        [Required]

        public string LectID { get; set; }
        [Required]

        [Key, Column(Order = 2)]
        public string Day { get; set; }
        [Required]

        [Key, Column(Order = 3)]
        public string Hour { get; set; }
        [Required]

        [Key, Column(Order = 4)]
        public string Classroom { get; set; }
        [Required]

        public string MoedA { get; set; }
        [Required]

        public string MoedB { get; set; }

    }
}