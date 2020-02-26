using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Software_Department_Project.Models
{
    public class Account
    {
        [Key]
        [Required]
        public string ID { get; set; }
        [Required]
        public string Password { get; set; }
        public string Type { get; set; }

    }
}