using Microsoft.OData.Edm;
using Software_Department_Project.Dal;
using Software_Department_Project.Models;
using Software_Department_Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Software_Department_Project.Controllers
{
    public class FacultyController : Controller
    {

        public static string faculy_id;
        public static string CourseN = "";

        public ActionResult Faculty(Account account)
        {
            string id = account.ID;
            faculy_id = id;
            var LecturerDal = new LecturerDal();
            var LecturerObj = (from x in LecturerDal.Lecturer select x).ToList<Lecturer>();
            var FacultyDal = new FacultyDal();
            var FacultyObj = (from x in FacultyDal.Faculty where x.ID.Equals(id) select x).ToList<Faculty>();
            var CourseDal = new CoursesDal();
            var CourseObj = (from x in CourseDal.Courses select x).ToList<Courses>();
            var StudentsDal = new StudentsDal();
            var StudentsObj = (from x in StudentsDal.Students select x).ToList<Student>();

            Faculty faculty = new Faculty()

            {
                ID = account.ID,
                FirstName = FacultyObj[0].FirstName,
                LastName = FacultyObj[0].LastName
            };
            FacultyViewModel facultyViewModel = new FacultyViewModel()
            {
                faculty = faculty,
                Coursesdata = CourseObj,
                Studentsdata = StudentsObj,
                LecturersData=LecturerObj

            };
            return View(facultyViewModel);
        }
        public ActionResult Logout()
        {
                FormsAuthentication.SignOut();
                Session.Abandon(); // it will clear the session at the end of request
                return RedirectToAction("Login", "Account");
        }
        public ActionResult ChangeLecturer(string CourseName, string LectID)
        {
            var LecturerDal = new LecturerDal();
            var LecturerObj = (from x in LecturerDal.Lecturer select x).ToList<Lecturer>();
            var FacultyDal = new FacultyDal();
            var FacultyObj = (from x in FacultyDal.Faculty where x.ID.Equals(faculy_id) select x).ToList<Faculty>();
            var CourseDal = new CoursesDal();
            var CourseObj = (from x in CourseDal.Courses select x).ToList<Courses>();
            var StudentsDal = new StudentsDal();
            var StudentsObj = (from x in StudentsDal.Students select x).ToList<Student>();

            Faculty faculty = new Faculty()

            {
                ID = faculy_id,
                FirstName = FacultyObj[0].FirstName,
                LastName = FacultyObj[0].LastName
            };
            FacultyViewModel facultyViewModel = new FacultyViewModel()
            {
                faculty = faculty,
                Coursesdata = CourseObj,
                Studentsdata = StudentsObj,
                LecturersData = LecturerObj
            };
            var CourseObj3 = (from x in CourseDal.Courses where x.LectID.Equals(LectID) select x).ToList<Courses>();
            var CourseObj2 = (from x in CourseDal.Courses where x.CourseName.Equals(CourseName) select x).First<Courses>();
            if (CourseObj2.LectID!= LectID && CourseObj2!=null )
            {
                Courses c = new Courses()
                {
                    CourseName = CourseObj2.CourseName,
                    Classroom = CourseObj2.Classroom,
                    Day = CourseObj2.Day,
                    Hour = CourseObj2.Hour,
                    MoedA = CourseObj2.MoedA,
                    MoedB = CourseObj2.MoedB,
                    LectID = LectID
                };
                int cnt = 0;
                foreach( Courses c_2 in CourseObj3)
                {
                    if (c_2.Day == c.Day && c_2.Hour==c.Hour)
                    {
                        cnt++;
                    }
                        
                }
                if (cnt == 0) 
                {
                  CourseDal.Courses.Remove(CourseObj2);
                    CourseDal.Courses.Add(c);
                    CourseDal.SaveChanges();

                }
                else
                {
                    ViewBag.ErrorMessage3 = "The course lecturer is already registered at this time";
                    return View("Faculty", facultyViewModel);

                }

            }
            return View("Faculty", facultyViewModel);
        }



        public ActionResult StudentToCourse(string StudentID, string CourseName)
        {
            var LecturerDal = new LecturerDal();
            var LecturerObj = (from x in LecturerDal.Lecturer select x).ToList<Lecturer>();
            var StudentCourseDal = new StudentCourseDal();
            var FacultyDal = new FacultyDal();
            var FacultyObj = (from x in FacultyDal.Faculty where x.ID.Equals(faculy_id) select x).ToList<Faculty>();
            var CourseDal = new CoursesDal();
            var CourseObj = (from x in CourseDal.Courses select x).ToList<Courses>();
            var StudentsDal = new StudentsDal();
            var StudentsObj = (from x in StudentsDal.Students select x).ToList<Student>();

            Faculty faculty = new Faculty()

            {
                ID = faculy_id,
                FirstName = FacultyObj[0].FirstName,
                LastName = FacultyObj[0].LastName
            };
            FacultyViewModel facultyViewModel = new FacultyViewModel()
            {
                faculty = faculty,
                Coursesdata = CourseObj,
                Studentsdata = StudentsObj,
                LecturersData = LecturerObj

            };

            StudentCourse sc = new StudentCourse()
            {
                CourseName = CourseName,
                StudentID = StudentID,
            };
            if (StudentCourseDal.StudentCourses.Find(sc.StudentID, sc.CourseName) == null)
            {
                StudentCourseDal.StudentCourses.Add(sc);
                StudentCourseDal.SaveChanges();
            }
            else
            {
                ViewBag.ErrorMessage2 = "This student is already assigned to this course!";
                return View("Faculty", facultyViewModel);

            }
            return View("Faculty", facultyViewModel);


        }

        public ActionResult EditCourse(string CourseName, string MoedA, string MoedB, string Day, string Hour, string Classroom)
        {
            var LecturerDal = new LecturerDal();
            var LecturerObj = (from x in LecturerDal.Lecturer select x).ToList<Lecturer>();
            var CourseDal = new CoursesDal();
             var CourseObj2 = (from x in CourseDal.Courses where x.CourseName.Equals(CourseName) select x).First<Courses>();
            var FacultyDal = new FacultyDal();
            var FacultyObj = (from x in FacultyDal.Faculty where x.ID.Equals(faculy_id) select x).ToList<Faculty>();
            var CoursesObj = (from x in CourseDal.Courses select x).ToList<Courses>();
            var StudentsDal = new StudentsDal();
            var StudentsObj = (from x in StudentsDal.Students select x).ToList<Student>();

            Faculty faculty = new Faculty()

            {
                ID = faculy_id,
                FirstName = FacultyObj[0].FirstName,
                LastName = FacultyObj[0].LastName
            };
            FacultyViewModel facultyViewModel = new FacultyViewModel()
            {
                faculty = faculty,
                Coursesdata = CoursesObj,
                Studentsdata = StudentsObj,
                LecturersData = LecturerObj

            };
            Courses CourseObj = new Courses()
            {
                CourseName = CourseName,
                Day = Day,
                Hour = Hour,
                Classroom = Classroom,
                MoedA = MoedA,
                MoedB = MoedB,
                LectID = CourseObj2.LectID


            };
            
                int cnt = 0;
                foreach (Courses c in CourseDal.Courses)
                {
                    if (c.Day == CourseObj.Day && c.Hour == CourseObj.Hour && c.Classroom == CourseObj.Classroom)
                    {
                        cnt++;
                    }
                }
                if (cnt == 1)
                {
                     ViewBag.ErrorMessage = "The course lecturer is already registered at this time";
                     return View("Faculty", facultyViewModel);

                }
                else
                {
                    CourseDal.Courses.Remove(CourseObj2);
                    CourseDal.SaveChanges();
                    CourseDal.Courses.Add(CourseObj);
                    CourseDal.SaveChanges();

                }

                    return View("Faculty", facultyViewModel);

        }


    }
}