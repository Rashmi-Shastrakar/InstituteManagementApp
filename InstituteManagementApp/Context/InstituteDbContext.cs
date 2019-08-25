using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using InstituteManagementApp.Models;

namespace InstituteManagementApp.Context
{
    public class InstituteDbContext : DbContext
    {
        public InstituteDbContext() :base("InstituteDetails")
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Classes> Class { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Contacts> ContactNumber { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Subjects> Subject { get; set; }
        public static InstituteDbContext Create()
        {
            return new InstituteDbContext();
        }

        public System.Data.Entity.DbSet<InstituteManagementApp.Models.UserMaster> UserMasters { get; set; }
    }
}