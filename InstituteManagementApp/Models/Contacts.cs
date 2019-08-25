using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InstituteManagementApp.Models
{
    public class Contacts
    {
        [Key]
        public int ContactId { get; set; }
        public string Contact1 { get; set; }
        public string Contact2 { get; set; }
    }
}