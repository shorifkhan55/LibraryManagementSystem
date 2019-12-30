using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using OnlineLibraryManagementSystemProject.Model;
using System.Data.SqlClient;

namespace OnlineLibraryManagementSystemProject.DAL
{
    public class IssuedBookGateway
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["OnlineLibrary"].ToString();

        public int IssuedBook(IssueBook issueBook)
        {
            string sql = "INSERT INTO IssuedBookTBL Values ('" + issueBook.Member.Id + "','" + issueBook.Book.BookId + "',"+
                         "'" + issueBook.StartDate + "','" + issueBook.ReturnDate + "')";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
        public bool CheckIssuedBookExisting(int member, int book)
        {
            string sql = "SELECT * FROM IssuedBookTBL where MemberId='" + member + "' And BookId='" + book + "'";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                sqlConnection.Close();
                return true;
            }

            else
            {
                sqlConnection.Close();
                return false;
            }
            
           

        }

        public int ReturnBook(int memberId, int bookBookId)
        {
            string sql = "Delete From IssuedBookTBL where MemberId='" + memberId + "' AND BookId='" + bookBookId + "'";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            int rowAffected = command.ExecuteNonQuery();
            sqlConnection.Close();
            return rowAffected;
        }
    }
}