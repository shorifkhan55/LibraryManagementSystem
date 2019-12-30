using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineLibraryManagementSystemProject.Model;

namespace OnlineLibraryManagementSystemProject.DAL
{
    public class AuthorGateway
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["OnlineLibrary"].ToString();

        public int SaveAuthor(Author author )
        {
            string sql = "INSERT INTO author_master_tbl Values ('"+author.AuthorName+"')";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
        public bool CheckAuthorName(Author author)
        {
            string sql = "select authorName from author_master_tbl where authorName='" + author.AuthorName + "'";
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
        public bool CheckAuthorId(int id)
        {
            string sql = "select author_id from author_master_tbl where author_id='" +id + "'";
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
        public Author GetAuthorName( int id)
        {
            string sql = "select * from author_master_tbl where author_id='" + id + "'";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            Author author1 = new Author();
            while (reader.Read())
            {
                author1.AuthorId = Convert.ToInt32(reader["author_id"].ToString());
                author1.AuthorName = reader["authorName"].ToString();
            }

            connection.Close();
            return author1;
        }
        public int DeleteAuthor( int id)
        {
            string sql = "Delete From author_master_tbl where author_id='" + id + "'";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public int UpdateAuthor(Author author)
        {
            string sql = "UPDATE author_master_tbl SET authorName='"+author.AuthorName+"' WHERE author_id='" + author.AuthorId + "'";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
        public List<Author> GetallAuthors()
        {
            string sql = "SELECT * FROM author_master_tbl";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<Author> authors = new List<Author>();
            Author author;
            while (reader.Read())
            {
                author = new Author();
                author.AuthorId = Convert.ToInt32(reader["author_id"].ToString());
                author.AuthorName = reader["authorName"].ToString();
               
                authors.Add(author);
            }
            reader.Close();
            sqlConnection.Close();
            return authors;
        }
    }
}