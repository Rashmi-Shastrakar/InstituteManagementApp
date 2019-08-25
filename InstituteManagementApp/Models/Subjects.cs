using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InstituteManagementApp.Models
{
    public class Subjects
    {
        [Key]
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public bool IsSelected { get; set; }
    }
}