using Software_Department_Project.Dal;
using Software_Department_Project.Models;
using Software_Department_Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Software_Department_Project.Controllers
{

    public class LecturerController : Controller
    {
        public static string CourseN = "";

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); 
            return RedirectToAction("Login", "Account");
        }
        public ActionResult Lecturer(Account account)
        {
            string id = account.ID;
            var CoursesDal = new CoursesDal();
            var CourseDetails = (from x in CoursesDal.Courses where x.LectID.Equals(id) select x).ToList<Courses>();
            var LecturerDal = new LecturerDal();
            var LecturerUser = (from x in LecturerDal.Lecturer where x.ID.Equals(id) select x).ToList<Lecturer>();
            Lecturer lecturer = new Lecturer()
            {
                ID = account.ID,
                FirstName = LecturerUser[0].FirstName,
                LastName = LecturerUser[0].LastName
            };


            LecturerViewModel lecturerViewModel = new LecturerViewModel()
            {
                lecturer = lecturer,
                courses=CourseDetails
            };
            return View(lecturerViewModel);
        }
        [HttpPost]

        public ActionResult ShowStudents(string CourseName)
        {
            string courseName = CourseName;
            CourseN = courseName;
            var StudentCourseDal = new StudentCourseDal();
            var StudentCourseObj = (from x in StudentCourseDal.StudentCourses where x.CourseName.Equals(courseName) select x).ToList<StudentCourse>();
            return View("ShowStudents", StudentCourseObj);
        }
        [HttpPost]
        public ActionResult UpdateGrade(string StudentID,string Grade)
        {
            string studentID = StudentID;
            string newGrade = Grade;
            var StudentCourseDal = new StudentCourseDal();
            var StudentCourseObj = (from x in StudentCourseDal.StudentCourses where x.CourseName.Equals(CourseN)select x).ToList<StudentCourse>();
            foreach (StudentCourse sc in StudentCourseDal.StudentCourses)
            {
                if (sc.CourseName==CourseN && sc.StudentID == studentID)
                {
                    sc.Grade= int.Parse(newGrade);
                }
            }
            StudentCourseDal.SaveChanges();
            return View("ShowStudents", StudentCourseObj);
        }




    }
}