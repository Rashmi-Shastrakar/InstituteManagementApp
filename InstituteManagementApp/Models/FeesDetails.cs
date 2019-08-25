using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InstituteManagementApp.Models
{
    public class FeesDetails
    {
        [Key]
        public int FeesDetailsiD { get; set; }
        public int StudentId { get; set; }
        public int TotalFees { get; set; }
        public int FeesPaid { get; set; }
        public int FeesBalance { get; set; }
        public DateTime PaidDate { get; set; }
        public string ReceivedBy { get; set; }

    }
}