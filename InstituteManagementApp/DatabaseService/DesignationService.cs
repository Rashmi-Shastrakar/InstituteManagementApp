using InstituteManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InstituteManagementApp.DatabaseService
{
    public class DesignationService
    {
        private SqlConnection con;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            con = new SqlConnection(constr);

        }

        public void AddDesignation(Designation obj)
        {

            connection();
            SqlCommand com = new SqlCommand("DESIGNATIONSAVE", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter("@NAME", SqlDbType.VarChar, 20));
            com.Parameters["@NAME"].Value = obj.DesignationName;
            try
            {
                con.Open();
                com.ExecuteNonQuery();
            }
            
            finally
            {
                con.Close();
            }
            
            
        }

        public List<Designation> GetAllDesignation()
        {
            connection();
            List<Designation> ClassList = new List<Designation>();
            SqlCommand com = new SqlCommand("GETDESIGNATION", con);
            com.CommandType = CommandType.StoredProcedure;
            List<Designation> DesignationList = new List<Designation>();
            try
            {
                con.Open();
                SqlDataReader dataReader = com.ExecuteReader();
                while (dataReader.Read())
                {
                    DesignationList.Add(new Designation() { DesignationId = dataReader.GetInt32(0), DesignationName = dataReader.GetString(1) });
                }
                return DesignationList;
            }
            finally
            {
                con.Close();
            }
        }


        public void DeleteDesignation(int Id)
        {

            connection();
            SqlCommand com = new SqlCommand("DESIGNATIONDELETE", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
            com.Parameters["@ID"].Value = Id;
            
            try
            {
                con.Open();
                com.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }
    }
}