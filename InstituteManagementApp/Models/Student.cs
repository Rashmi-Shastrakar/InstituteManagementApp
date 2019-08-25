using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InstituteManagementApp.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Class { get; set; }
        public string Stream { get; set; }
        public string School { get; set; }
        public string StudentGender { get; set; }
        public Address Address { get; set; }
        public Contacts Contact { get; set; }
        public int TotalFess { get; set; }
        public int NoofInstallments { get; set; }
        public DateTime DateofAdmission { get; set; }

        
    }
    
}