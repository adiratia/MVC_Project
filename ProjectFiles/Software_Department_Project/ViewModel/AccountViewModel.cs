using Software_Department_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Software_Department_Project.ViewModel
{
    public class AccountViewModel
    {

        public Account account { get; set; }
        public List<Account> accounts { get; set; }
    }
}