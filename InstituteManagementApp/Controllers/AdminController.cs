using InstituteManagementApp.DatabaseService;
using InstituteManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstituteManagementApp.Controllers
{
    public class AdminController : Controller
    {
        SqlConnection con;
        SqlCommand comm;
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoginPage()
        {
            return View();
        }
       [HttpPost]
       public ActionResult LoginCredential()//Temporary Method for Admin Login
        {
            string username = Request["txtUserName"];
            string password = Request["txtPassword"];
            if(username.Equals("Admin",StringComparison.OrdinalIgnoreCase) && password.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("LoginPage");
        }
        
        public ActionResult ClassesPage()
        {
            ClassSevice classService = new ClassSevice();
            List<Classes> allClasses = classService.GetAllClasses();

            return View(allClasses);
            
        }
        
        public ActionResult AddClass()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddClass(Classes classes)
        {
            try
            {
                
                ClassSevice classService = new ClassSevice();
                classService.AddClass(classes);

                return RedirectToAction("ClassesPage");
            }
            catch
            {
                return View();
            }
        }
       
        public ActionResult DeleteClass(int classId)
        {

                ClassSevice classService = new ClassSevice();
                classService.DeleteClass(classId);

                return RedirectToAction("ClassesPage");
        }
        public ActionResult AddDesignation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDesignation(Designation designation)
        {
            try
            {
                // TODO: Add delete logic here
                DesignationService designationService = new DesignationService();
                designationService.AddDesignation(designation);

                return RedirectToAction("DesignationPage");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult DesignationPage()
        {
            DesignationService designationService = new DesignationService();
            List<Designation> alldesignation= designationService.GetAllDesignation();

            return View(alldesignation);
            
        }
        public ActionResult DeleteDesignation(int designationId)
        {

            DesignationService designationService = new DesignationService();
            designationService.DeleteDesignation(designationId);

            return RedirectToAction("DesignationPage");
        }



        public ActionResult AddSubject()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSubject(Subjects subjects)
        {
            try
            {
                // TODO: Add delete logic here
                SubjectService subjectService = new SubjectService();
                subjectService.AddSubject(subjects);

                return RedirectToAction("SubjectPage");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult SubjectPage()
        {
            SubjectService subjectService = new SubjectService();
            List<Subjects> allsubjects = subjectService.GetAllSubjects();

            return View(allsubjects);

        }
        public ActionResult DeleteSubject(int subjectId)
        {

            SubjectService subjectService = new SubjectService();
            subjectService.DeleteSubject(subjectId);

            return RedirectToAction("SubjectPage");
        }
    }
}
