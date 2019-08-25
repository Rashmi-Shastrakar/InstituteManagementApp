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
    public class UserService
    {
        private SqlConnection con;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            con = new SqlConnection(constr);

        }

        public void AddUser(UserMaster user)
        {

            connection();
            SqlCommand com = new SqlCommand("AddUser", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter("@firstName", SqlDbType.VarChar, 10));
            com.Parameters.Add(new SqlParameter("@middleName", SqlDbType.VarChar, 10));
            com.Parameters.Add(new SqlParameter("@lastName", SqlDbType.VarChar, 10));
            com.Parameters.Add(new SqlParameter("@designationid", SqlDbType.Int));
            com.Parameters.Add(new SqlParameter("@mobileno", SqlDbType.VarChar, 10));
            com.Parameters.Add(new SqlParameter("@qualification", SqlDbType.VarChar, 10));
            com.Parameters.Add(new SqlParameter("@payment", SqlDbType.Int));
            com.Parameters.Add(new SqlParameter("@paymentdate", SqlDbType.Date));
            com.Parameters.Add(new SqlParameter("@joiningdate", SqlDbType.Date));
            com.Parameters.Add(new SqlParameter("@worktype", SqlDbType.VarChar, 10));
            com.Parameters.Add(new SqlParameter("@batch", SqlDbType.VarChar, 10));

            com.Parameters["@firstName"].Value = user.FirstName;
            com.Parameters["@middleName"].Value = user.MiddleName;
            com.Parameters["@lastName"].Value = user.LastName;
            com.Parameters["@designationid"].Value = Convert.ToInt32(user.Designation);
            com.Parameters["@mobileno"].Value = user.MobileNumber;
            com.Parameters["@qualification"].Value = user.Qualification;
            com.Parameters["@payment"].Value = user.TotalPayment;
            com.Parameters["@paymentdate"].Value = user.PaymentDate;
            com.Parameters["@joiningdate"].Value = user.JoiningDate;
            com.Parameters["@worktype"].Value = user.WorkType;
            com.Parameters["@batch"].Value = user.Batch;
            try
            {
                con.Open();
                com.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }
            finally
            {
                con.Close();
            }
        }

        public List<UserMaster> GetAllUser()
        {
            connection();
            List<UserMaster> UserList = new List<UserMaster>();
            SqlCommand com = new SqlCommand("GetAllUser", con);
            com.CommandType = CommandType.StoredProcedure;
            try
            {
                con.Open();
                SqlDataReader dataReader = com.ExecuteReader();
                while (dataReader.Read())
                {
                    UserList.Add(new UserMaster()
                    {
                        UserId = dataReader.GetInt32(0),
                        FirstName=dataReader.GetString(1),
                        LastName=dataReader.GetString(2),
                        MobileNumber=dataReader.GetString(3),
                        Qualification=dataReader.GetString(4),
                        TotalPayment=dataReader.GetInt32(5),
                        JoiningDate=dataReader.GetDateTime(6),
                        WorkType=dataReader.GetString(7),
                        Batch=dataReader.GetString(8),
                        IsActive=dataReader.GetBoolean(9)
                        
                    });
                }
            }
            finally
            {
                con.Close();
            }
            return UserList;
        }


        public void DeleteUser(int id)
        {

            connection();
            SqlCommand com = new SqlCommand("DeleteUser", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
            com.Parameters["@ID"].Value = id;
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
        public void UpdateUser(UserMaster user)
        {
            connection();
            SqlCommand com = new SqlCommand("AddStudent", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter("@firstName", SqlDbType.VarChar, 20));
            com.Parameters.Add(new SqlParameter("@middleName", SqlDbType.VarChar, 20));
            com.Parameters.Add(new SqlParameter("@lastName", SqlDbType.VarChar, 20));
            com.Parameters.Add(new SqlParameter("@designationid", SqlDbType.Int));
            com.Parameters.Add(new SqlParameter("@mobileno", SqlDbType.VarChar, 20));
            com.Parameters.Add(new SqlParameter("@qualification", SqlDbType.VarChar, 20));
            com.Parameters.Add(new SqlParameter("@payment", SqlDbType.Int));
            com.Parameters.Add(new SqlParameter("@paymentdate", SqlDbType.Date, 20));
            com.Parameters.Add(new SqlParameter("@joiningdate", SqlDbType.Int));
            com.Parameters.Add(new SqlParameter("@worktype", SqlDbType.VarChar, 20));
            com.Parameters.Add(new SqlParameter("@batch", SqlDbType.VarChar, 20));

            com.Parameters["@firstName"].Value = user.FirstName;
            com.Parameters["@middleName"].Value = user.MiddleName;
            com.Parameters["@lastName"].Value = user.LastName;
            com.Parameters["@designation"].Value = user.Designation;
            com.Parameters["@mobileno"].Value = user.MobileNumber;
            com.Parameters["@qualification"].Value = user.Qualification;
            com.Parameters["@payment"].Value = user.TotalPayment;
            com.Parameters["@paymentdate"].Value = user.PaymentDate;
            com.Parameters["@joiningdate"].Value = user.JoiningDate;
            com.Parameters["@worktype"].Value = user.WorkType;


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
        public void GetUserById(int id)
        {
            connection();
            SqlCommand com = new SqlCommand("SELECTUSERBYID", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
            com.Parameters["@ID"].Value = id;
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