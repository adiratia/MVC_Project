using Software_Department_Project.Models;
using Software_Department_Project.Dal;

using Software_Department_Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Documents;
using System.Web.Security;

namespace Software_Department_Project.Controllers
{
    public class StudentController : Controller
    {

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Login", "Account");
        }
        public ActionResult Student(Account account)
        {
            var StudentsDal = new StudentsDal();
            var username = account.ID;
            var StudentsUser = (from x in StudentsDal.Students where x.ID.Equals(username) select x).ToList<Student>();
            var StudentCourseDal = new StudentCourseDal();
            var studentCourseObj = (from x in StudentCourseDal.StudentCourses where x.StudentID.Equals(username) select x).ToList<StudentCourse>();

            var CoursesDal = new CoursesDal();
            List<Courses> CourseDetail= new List<Courses>();
            Courses t= new Courses();
            foreach (StudentCourse y in studentCourseObj)
            {
                t =( from x in CoursesDal.Courses where x.CourseName.Equals(y.CourseName) select x).FirstOrDefault<Courses>();
                CourseDetail.Add(t);
            }
            Student student = new Student()
            {
                ID = account.ID,
                FirstName = StudentsUser[0].FirstName,
                LastName = StudentsUser[0].LastName,
            };
            StudentViewModel studentViewModel = new StudentViewModel()
            {
                student = student,
                courses = CourseDetail,
                studentCourses = studentCourseObj
            };
            return View(studentViewModel);

     

        }
    }
}