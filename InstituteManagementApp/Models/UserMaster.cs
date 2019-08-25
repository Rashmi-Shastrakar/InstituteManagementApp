using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InstituteManagementApp.Models
{
    public class UserMaster
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public string MobileNumber { get; set; }
        public string Qualification { get; set; }
        public int TotalPayment { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime JoiningDate { get; set; }
        public string WorkType { get; set; }
        public string Batch { get; set; }
        public bool IsActive { get; set; }
       

    }
}