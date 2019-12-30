using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineLibraryManagementSystemProject.DAL;
using OnlineLibraryManagementSystemProject.Model;

namespace OnlineLibraryManagementSystemProject.BLL
{
    public class IssuedBookManager
    {
        IssuedBookGateway issuedBookGateway=new IssuedBookGateway();
        public string IssuedBook(IssueBook issueBook)
        {

            int rowAffected = issuedBookGateway.IssuedBook(issueBook);
                if (rowAffected > 0)
                {
                    return "Book Issued Successfully.";
                }
                else
                {
                    return "Author Issued Failed, Try Again.";
                }
            
        }

        public bool CheckIssuedBookExisting(int member, int book)
        {
            return issuedBookGateway.CheckIssuedBookExisting(member, book);
        }

        public string ReturnBook(int memberId, int bookBookId)
        {
            int rowAffected = issuedBookGateway.ReturnBook(memberId, bookBookId);
            if (rowAffected>0)
            {
                return "Book Return Successfully";
            }
            else
            {
                return "Book Return Failed";
            }
        }
    }
}