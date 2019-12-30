using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineLibraryManagementSystemProject.DAL
{
    public class AdminGateway
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["OnlineLibrary"].ToString();

        public bool LoginAdmin(string email, string password)
        {
            string sql = "select username, password from admin_login_tbl where username='" + email + "' AND password='" +
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
    }
}