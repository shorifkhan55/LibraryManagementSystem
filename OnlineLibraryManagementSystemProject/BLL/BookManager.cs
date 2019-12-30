using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineLibraryManagementSystemProject.DAL;
using OnlineLibraryManagementSystemProject.Model;

namespace OnlineLibraryManagementSystemProject.BLL
{
    public class BookManager
    {
        BookGateway bookGateway=new BookGateway();

        public string SaveBook(Book book)
        {
            bool isMemberId = bookGateway.CheckBookName(book);
            if (isMemberId == false)
            {
                int rowAffected = bookGateway.SaveBook(book);
                if (rowAffected > 0)
                {
                    return "Book submit Successfully.";
                }
                else
                {
                    return "Book submit Failed, Try Again.";
                }
            }
            else
            {
                return "This Name Already Used, please try Another Author Name";
            }
        }

        public Book GetBookInfoById(int id)
        {
            return bookGateway.GetBookInfoById(id);
        }

        public bool CheckBookCurrentStock(int id)
        {
            return bookGateway.CheckBookCurrentStock(id);
        }

        public string UpdateBookForCurrentStock(Book book)
        {
            int rowAffected= bookGateway.UpdateBookForCurrentStock(book);
            if (rowAffected > 0)
            {
                return " Current Stock Update Successfully.";
            }
            else
            {
                return " Current Stock Update Failed, Try Again.";
            }
        }

        public string UpdateBook(Book book)
        {
            
                int rowAffected = bookGateway.UpdateBook(book);
                if (rowAffected > 0)
                {
                    return "Book Update Successfully.";
                }
                else
                {
                    return "Book Update Failed, Try Again.";
                }
           
        }

        public string DeleteBook(int id)
        {

            int rowAffected = bookGateway.DeleteBook(id);
            if (rowAffected > 0)
            {
                return "Book Delete Successfully.";
            }
            else
            {
                return "Book Delete Failed, Try Again.";
            }
        }

        public string UpdateCurrentStockForReturn(int id)
        {
            int rowAffected = bookGateway.UpdateCurrentStockForReturn(id);
            if (rowAffected > 0)
            {
                return "Book Update Successfully.";
            }
            else
            {
                return "Book Update Failed, Try Again.";
            }
        }
    }
}