using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineLibraryManagementSystemProject.Model;

namespace OnlineLibraryManagementSystemProject.DAL
{
    public class BookGateway
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["OnlineLibrary"].ToString();

        public int SaveBook(Book book)
        {
            string sql = "INSERT INTO book_master_tbl Values ('" + book.Name + "','" + book.Genre + "'," +
                         "'" + book.Author.AuthorId + "','" + book.Publisher.PublisherId + "','" + book.Date + "'," +
                         "'" + book.Language + "','" + book.Edition + "','" + book.BookCost + "'," +
                         "'" + book.NoOfPage + "','" + book.Description + "','" + book.ActualStock + "'," +
                         "'" + book.CurrentStock + "','" + book.BookImgLink + "')";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
        public bool CheckBookName(Book book)
        {
            string sql = "select book_name from book_master_tbl where book_name='" + book.Name + "'";
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
        public bool CheckBookCurrentStock(int id)
        {
            string sql = "select book_name from book_master_tbl where book_id='" + id + "' AND current_stock>0";
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
        public Book GetBookInfoById(int id)
        {
            string sql = "SELECT * FROM book_master_tbl where book_id='" + id + "'";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            Book book = new Book();
            while (reader.Read())
            {
                book.BookId = Convert.ToInt32(reader["book_id"]);
                book.Name = reader["book_name"].ToString();
                book.Genre = reader["genre"].ToString();
                Author author=new Author();
                author.AuthorId = Convert.ToInt32(reader["authorId"]);
                book.Author = author;
                Publisher publisher=new Publisher();
                publisher.PublisherId = Convert.ToInt32(reader["publisherId"]);
                book.Publisher = publisher;
                book.Date = reader["publish_date"].ToString();
                book.Language = reader["Language"].ToString();
                book.Edition = reader["Edition"].ToString();
                book.BookCost = reader["book_cost"].ToString();
                book.NoOfPage = reader["no_of_pages"].ToString();
                book.Description = reader["book_dscription"].ToString();
                book.ActualStock = reader["Actual_stock"].ToString();
                book.CurrentStock = reader["current_stock"].ToString();
                book.BookImgLink = reader["book_img_link"].ToString();

            }
            reader.Close();
            connection.Close();
            return book;
        }

        public int UpdateBook(Book book)
        {
            string sql = "Update book_master_tbl Set book_name='" + book.Name + "',genre='" + book.Genre + "'," +
                         "authorId='" + book.Author.AuthorId + "',publisherId='" + book.Publisher.PublisherId + "',publish_date='" + book.Date + "'," +
                         "Language='" + book.Language + "',Edition='" + book.Edition + "',book_cost='" + book.BookCost + "'," +
                         "no_of_pages='" + book.NoOfPage + "',book_dscription='" + book.Description + "',Actual_stock='" + book.ActualStock + "'," +
                         "current_stock='" + book.CurrentStock + "' where book_id='" + book.BookId + "'";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
        public int UpdateBookForCurrentStock(Book book)
        {
            string sql = "Update book_master_tbl Set current_stock=current_stock-1  where book_id='" + book.BookId + "'";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
        public int DeleteBook(int id)
        {
            string sql = "Delete From book_master_tbl where book_id='" + id + "'";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public int UpdateCurrentStockForReturn(int id)
        {
            string sql = "Update book_master_tbl Set current_stock=current_stock+1  where book_id='" + id + "'";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

     
    }
}