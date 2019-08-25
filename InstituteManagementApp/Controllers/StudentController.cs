using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using InstituteManagementApp.Models;
using InstituteManagementApp.DatabaseService;

namespace InstituteManagementApp.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult StudentPage()
        {
            StudentService studentService = new StudentService();
            List<Student> allStudents=studentService.GetAllStudents();
            return View(allStudents);
        }

        public ActionResult StudentRegistration()
        {
            List<SelectListItem> selectListItemsClasses = new List<SelectListItem>();
            ClassSevice classService = new ClassSevice();
            List<Classes> allClasses = classService.GetAllClasses();
            foreach (Classes classes in allClasses)
            {
                selectListItemsClasses.Add(new SelectListItem() { Text = classes.Class, Value = classes.ClassId.ToString() });
            }
            ViewBag.Classes = selectListItemsClasses;
            return View();
        }
        [HttpPost]
        public ActionResult StudentRegistration(Student student)
        {
            StudentService studentService = new StudentService();
            studentService.AddStudent(student);
            return RedirectToAction("Index","Admin",new { area = ""});
        }
    }
}