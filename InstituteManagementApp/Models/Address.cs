using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InstituteManagementApp.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public string AddressforContact { get; set; }
    }
}