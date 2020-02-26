using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Software_Department_Project.Models;
using Software_Department_Project.Dal;

using System.Data.SqlClient;
using System.Data;
using System.Xml;
using Software_Department_Project.ViewModel;
using System.Configuration;
using System.Web.UI;
using System.Web.Security;

namespace Software_Department_Project.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Verify(Account account)
        {

            var AccountDal = new AccountDal();
            var username = account.ID;
            var password = account.Password;
            var objUser = (from x in AccountDal.Accounts where x.ID.Equals(username) && x.Password.Equals(password) select x).ToList<Account>();
            try
            {
                switch (objUser[0].Type)
                {
                    case "1":
                        return RedirectToAction("Student", "Student", account);
                    case "2":
                        return RedirectToAction("Lecturer", "Lecturer", account);
                    case "3":
                        return RedirectToAction("Faculty", "Faculty", account);
                }
            }
            catch(Exception)
            {

            }
            ViewBag.ErrorMessage4 = "Worng ID or Password, try again!";
            return View("Login");

           

        }
    }
}
