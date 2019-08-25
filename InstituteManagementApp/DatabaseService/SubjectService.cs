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
    public class SubjectService
    {
        private SqlConnection con;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            con = new SqlConnection(constr);

        }

        public void AddSubject(Subjects obj)
        {

            connection();
            SqlCommand com = new SqlCommand("SUBJECTSAVE", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter("@NAME", SqlDbType.VarChar, 20));
            com.Parameters["@NAME"].Value = obj.SubjectName;
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

        public List<Subjects> GetAllSubjects()
        {
            connection();
            List<Designation> ClassList = new List<Designation>();
            SqlCommand com = new SqlCommand("GETSUBJECTS", con);
            com.CommandType = CommandType.StoredProcedure;
            List<Subjects> SubjectList = new List<Subjects>();
            try
            {
                con.Open();
                SqlDataReader dataReader = com.ExecuteReader();
                while (dataReader.Read())
                {
                    SubjectList.Add(new Subjects() { SubjectId = dataReader.GetInt32(0), SubjectName = dataReader.GetString(1) });
                }
                return SubjectList;
            }
            finally
            {
                con.Close();
            }
        }


        public void DeleteSubject(int Id)
        {

            connection();
            SqlCommand com = new SqlCommand("SUBJECTDELETE", con);
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