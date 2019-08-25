using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InstituteManagementApp.Models
{
    public class Classes
    {
        [Key]
        public int ClassId { get; set; }
        public string Class { get; set; }
    }
}