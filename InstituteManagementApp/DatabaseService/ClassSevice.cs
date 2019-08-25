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
    public class ClassSevice
    {
        private SqlConnection con;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            con = new SqlConnection(constr);

        }

        public void AddClass(Classes obj)
        {

            connection();
            SqlCommand com = new SqlCommand("CLASSESSAVE", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter("@NAME", SqlDbType.VarChar, 20));
            com.Parameters["@NAME"].Value = obj.Class;
            try
            {
                con.Open();
                com.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
        }

        public List<Classes> GetAllClasses()
        {
            connection();
            List<Classes> ClassList = new List<Classes>();           
            SqlCommand com = new SqlCommand("GETCLASSES", con);
            com.CommandType = CommandType.StoredProcedure;
            try
            {
                con.Open();
                SqlDataReader dataReader = com.ExecuteReader();
                while (dataReader.Read())
                {
                    ClassList.Add(new Classes() { ClassId = dataReader.GetInt32(0), Class = dataReader.GetString(1) });
                }
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
            return ClassList;
        }


        public void DeleteClass(int Id)
        {

            connection();
            SqlCommand com = new SqlCommand("CLASSDELETE", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
            com.Parameters["@ID"].Value = Id;           
             try
             {
                con.Open();
                com.ExecuteNonQuery();
             }
             catch
             {
                
             }
            finally
            {
                con.Close();
            }
        }
    }
}