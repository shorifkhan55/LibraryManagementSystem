using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineLibraryManagementSystemProject.Model;

namespace OnlineLibraryManagementSystemProject.DAL
{
    public class MemberGateway
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["OnlineLibrary"].ToString();

        public int SaveMember(Member member)
        {
            string sql = "INSERT INTO member_master_tbl values('" + member.FullName + "','" + member.DOB + "','" + member.ContactNo + "'," +
                         "'" + member.Email + "','" + member.State + "','" + member.City + "','" + member.PinCode + "'," +
                         "'" + member.FullAddress + "','" + member.Password + "','" + member.AccountStatus + "')";
            SqlConnection connection=new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command=new SqlCommand(sql,connection);
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
        public bool CheckMemberId(Member member)
        {
            string sql = "select email from member_master_tbl where email='" + member.Email + "'";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
                return false;
            }
        }

        public bool LoginMember(string email, string password)
        {
            string sql = "select email, password from member_master_tbl where email='" + email + "' AND password='" +
                         password + "'";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
                return false;
            }
        }
        public List<Member> GetallMembers()
        {
            string sql = "SELECT * FROM member_master_tbl";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<Member> members = new List<Member>();
            Member member;
            while (reader.Read())
            {
                member = new Member();
                member.Id = Convert.ToInt32(reader["member_id"].ToString());
                member.FullName = reader["full_name"].ToString();
                member.ContactNo = reader["contact_no"].ToString();
                member.Email = reader["email"].ToString();
                member.State = reader["state"].ToString();
                member.City = reader["city"].ToString();
                member.AccountStatus = reader["account_status"].ToString();
                members.Add(member);
            }
            reader.Close();
            sqlConnection.Close();
            return members;
        }
        public int UpdateAccountStatus(Member member)
        {
            string sql = "UPDATE member_master_tbl SET account_status='" + member.AccountStatus + "' WHERE member_id='" + member.Id + "'";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
        public Member GetMemberForAdmin( int id)
        {
            string sql = "SELECT * FROM member_master_tbl where member_id='"+id+"'";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            Member member = new Member();
            while (reader.Read())
            {
               
                member.Id = Convert.ToInt32(reader["member_id"].ToString());
                member.FullName = reader["full_name"].ToString();
                member.DOB = reader["dob"].ToString();
                member.ContactNo = reader["contact_no"].ToString();
                member.Email = reader["email"].ToString();
                member.State = reader["state"].ToString();
                member.City = reader["city"].ToString();
                member.PinCode = reader["pincode"].ToString();
                member.FullAddress = reader["full_address"].ToString();
                member.Password = reader["password"].ToString();
                member.AccountStatus = reader["account_status"].ToString();
               
            }
            reader.Close();
            sqlConnection.Close();
            return member;
        }
        public int DeleteMember(int id)
        {
            string sql = "Delete From member_master_tbl where member_id='" + id + "'";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public bool GetMemberForIssuedBook(int id)
        {
            string sql = "SELECT * FROM member_master_tbl where member_id='" + id + "'";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                return true;
            }

            else
            {
                return false;
            }
            reader.Close();
            sqlConnection.Close();
           
        }
    }
}