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
    public class StudentService
    {
        private SqlConnection con;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            con = new SqlConnection(constr);

        }

        public void AddStudent(Student student)
        {

            connection();
            SqlCommand com = new SqlCommand("AddStudent", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter("@firstName", SqlDbType.VarChar, 20));
            com.Parameters.Add(new SqlParameter("@middleName", SqlDbType.VarChar, 20));
            com.Parameters.Add(new SqlParameter("@lastName", SqlDbType.VarChar, 20));
            com.Parameters.Add(new SqlParameter("@dateOfBirth", SqlDbType.Date));
            com.Parameters.Add(new SqlParameter("@studentClassId", SqlDbType.Int));
            com.Parameters.Add(new SqlParameter("@stream", SqlDbType.VarChar));
            com.Parameters.Add(new SqlParameter("@school", SqlDbType.VarChar, 20));
            com.Parameters.Add(new SqlParameter("@gender", SqlDbType.VarChar, 20));
            com.Parameters.Add(new SqlParameter("@address", SqlDbType.VarChar, 20));
            com.Parameters.Add(new SqlParameter("@contact1", SqlDbType.VarChar, 20));
            com.Parameters.Add(new SqlParameter("@contact2", SqlDbType.VarChar, 20));
            com.Parameters.Add(new SqlParameter("@totalFees", SqlDbType.Int));
            com.Parameters.Add(new SqlParameter("@numberOfInstallments", SqlDbType.Int));
            com.Parameters.Add(new SqlParameter("@dateOfAdmission", SqlDbType.Date));

            com.Parameters["@firstName"].Value = student.FirstName;
            com.Parameters["@middleName"].Value = student.MiddleName;
            com.Parameters["@lastName"].Value = student.LastName;
            com.Parameters["@dateOfBirth"].Value = student.DateofBirth;
            com.Parameters["@studentClassId"].Value = Convert.ToInt32(student.Class);
            com.Parameters["@stream"].Value = student.Stream;
            com.Parameters["@school"].Value = student.School;
            com.Parameters["@gender"].Value = student.StudentGender;
            com.Parameters["@address"].Value = student.Address.AddressforContact;
            com.Parameters["@contact1"].Value = student.Contact.Contact1;
            com.Parameters["@contact2"].Value = student.Contact.Contact2;
            com.Parameters["@totalFees"].Value = student.TotalFess;
            com.Parameters["@numberOfInstallments"].Value = student.NoofInstallments;
            com.Parameters["@dateOfAdmission"].Value = student.DateofAdmission;

            try
            {
                con.Open();
                com.ExecuteNonQuery();
            }
            catch(Exception e)
            {

            }
            finally
            {
                con.Close();
            }
        }

        public List<Student> GetAllStudents()
        {
            connection();
            List<Student> StudentList = new List<Student>();
            SqlCommand com = new SqlCommand("GETSTUDENT", con);
            com.CommandType = CommandType.StoredProcedure;
            try
            {
                con.Open();
                SqlDataReader dataReader = com.ExecuteReader();
                while (dataReader.Read())
                {
                    StudentList.Add(new Student() { StudentId=dataReader.GetInt32(0),FirstName=dataReader.GetString(1),
                        MiddleName =dataReader.GetString(2),LastName=dataReader.GetString(3),
                        TotalFess=dataReader.GetInt32(4)
                    });
                }
            }
            finally
            {
                con.Close();
            }
            return StudentList;
        }


        public void DeleteStudent(int id)
        {

            connection();
            SqlCommand com = new SqlCommand("DELETESTUDENT", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
            com.Parameters["@ID"].Value = id;
            try
            {
                con.Open();
                com.ExecuteNonQuery();
            }
            catch(Exception e)
            {

            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateStudent(Student student)
        {
            connection();
            SqlCommand com = new SqlCommand("UPDATESTUDENT", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter("@firstName", SqlDbType.VarChar, 20));
            com.Parameters.Add(new SqlParameter("@middleName", SqlDbType.VarChar, 20));
            com.Parameters.Add(new SqlParameter("@lastName", SqlDbType.VarChar, 20));
            com.Parameters.Add(new SqlParameter("@dateOfBirth", SqlDbType.Date));
            com.Parameters.Add(new SqlParameter("@school", SqlDbType.VarChar, 20));
            com.Parameters.Add(new SqlParameter("@gender", SqlDbType.VarChar, 20));
            com.Parameters.Add(new SqlParameter("@address", SqlDbType.VarChar, 20));
            com.Parameters.Add(new SqlParameter("@contact1", SqlDbType.VarChar, 20));
            com.Parameters.Add(new SqlParameter("@contact2", SqlDbType.VarChar, 20));
            com.Parameters.Add(new SqlParameter("@totalFees", SqlDbType.Int));
            com.Parameters.Add(new SqlParameter("@numberOfInstallments", SqlDbType.Int));
            com.Parameters.Add(new SqlParameter("@dateOfAdmission", SqlDbType.Date));

            com.Parameters["@firstName"].Value = student.FirstName;
            com.Parameters["@middleName"].Value = student.MiddleName;
            com.Parameters["@lastName"].Value = student.LastName;
            com.Parameters["@dateOfBirth"].Value = student.DateofBirth;
            com.Parameters["@school"].Value = student.School;
            com.Parameters["@gender"].Value = student.StudentGender;
            com.Parameters["@address"].Value = student.Address;
            com.Parameters["@contact1"].Value = student.Contact.Contact1;
            com.Parameters["@contact2"].Value = student.Contact.Contact2;
            com.Parameters["@totalFees"].Value = student.TotalFess;
            com.Parameters["@numberOfInstallments"].Value = student.NoofInstallments;
            com.Parameters["@dateOfAdmission"].Value = student.DateofAdmission;

            try
            {
                con.Open();
                com.ExecuteNonQuery();
            }
            catch(Exception e)
            {

            }
            finally
            {
                con.Close();
            }

        }
        public void GetStudentById(int id)
        {
            connection();
            SqlCommand com = new SqlCommand("SELECTSTUDENTBYID", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
            com.Parameters["@ID"].Value = id;
            try
            {
                con.Open();
                com.ExecuteNonQuery();
            }
            catch(Exception e)
            {

            }
            finally
            {
                con.Close();
            }
        }
    }
}