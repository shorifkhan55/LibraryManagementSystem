using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineLibraryManagementSystemProject.Model;

namespace OnlineLibraryManagementSystemProject.DAL
{
    public class PublisherGateway
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["OnlineLibrary"].ToString();

            public int SavePublisher(Publisher publisher)
            {
                string sql = "INSERT INTO publisher_master_tbl Values ('" + publisher.PublisherName + "')";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                int rowAffected = command.ExecuteNonQuery();
                connection.Close();
                return rowAffected;
            }
            public bool CheckPublisherName(Publisher publisher)
            {
                string sql = "select publisher_name from publisher_master_tbl where publisher_name='" + publisher.PublisherName + "'";
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
            public bool CheckPublisherId(int id)
            {
                string sql = "select publisher_id from publisher_master_tbl where publisher_id='" + id + "'";
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
            public int DeletePublisher(int id)
            {
                string sql = "Delete From publisher_master_tbl where publisher_id='" + id + "'";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                int rowAffected = command.ExecuteNonQuery();
                connection.Close();
                return rowAffected;
            }

            public int UpdatePublisher(Publisher publisher)
            {
                string sql = "UPDATE publisher_master_tbl SET publisher_name='" + publisher.PublisherName + "' " +
                             "where publisher_id='" + publisher.PublisherId + "'";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                int rowAffected = command.ExecuteNonQuery();
                connection.Close();
                return rowAffected;
            }
            public List<Publisher> GetAllPublishers()
            {
                string sql = "SELECT * FROM publisher_master_tbl";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(sql, sqlConnection);
                SqlDataReader reader = command.ExecuteReader();
                List<Publisher> publishers = new List<Publisher>();
                Publisher publisher;
                while (reader.Read())
                {
                    publisher = new Publisher();
                    publisher.PublisherId = Convert.ToInt32(reader["publisher_id"].ToString());
                    publisher.PublisherName = reader["publisher_name"].ToString();

                    publishers.Add(publisher);
                }
                reader.Close();
                sqlConnection.Close();
                return publishers;
            }
            public  Publisher GetPublisherName(int id)
            {
                string sql = "SELECT * FROM publisher_master_tbl where publisher_id= '"+id+"'";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(sql, sqlConnection);
                SqlDataReader reader = command.ExecuteReader();
                Publisher publisher = new Publisher();
                while (reader.Read())
                {
                    publisher.PublisherId = Convert.ToInt32(reader["publisher_id"].ToString());
                    publisher.PublisherName = reader["publisher_name"].ToString();
                }
                reader.Close();
                sqlConnection.Close();
                return publisher;
            }
        }
    }
