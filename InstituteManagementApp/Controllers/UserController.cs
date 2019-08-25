using InstituteManagementApp.DatabaseService;
using InstituteManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstituteManagementApp.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserRegistration()
        {
            List<SelectListItem> selectListItemsDesignation = new List<SelectListItem>();
            DesignationService designationservice = new DesignationService();
            List<Designation> designations = designationservice.GetAllDesignation();
            foreach (Designation designation in designations)
            {
                selectListItemsDesignation.Add(new SelectListItem() { Text = designation.DesignationName, Value = (designation.DesignationId).ToString() });
            }
            ViewBag.Designation = selectListItemsDesignation;

            return View();
        }
        [HttpPost]
        public ActionResult UserRegistration(UserMaster user)
        {
            UserService userService = new UserService();
            userService.AddUser(user);
            return RedirectToAction("Index", "Admin", new { area = "" });
        }
        public ActionResult AllUsers()
        {
            UserService userService = new UserService();
            List<UserMaster> allusers=userService.GetAllUser();
            return View(allusers);
        }
    }
}