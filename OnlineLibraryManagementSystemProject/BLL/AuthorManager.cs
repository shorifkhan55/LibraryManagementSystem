using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineLibraryManagementSystemProject.DAL;
using OnlineLibraryManagementSystemProject.Model;

namespace OnlineLibraryManagementSystemProject.BLL
{
    public class AuthorManager
    {
        AuthorGateway authorGateway=new AuthorGateway();

        public string SaveAuthor(Author author)
        {
            bool isMemberId = authorGateway.CheckAuthorName(author);
            if (isMemberId == false)
            {
                int rowAffected = authorGateway.SaveAuthor(author);
                if (rowAffected > 0)
                {
                    return "Author submit Successfully.";
                }
                else
                {
                    return "Author submit Failed, Try Again.";
                }
            }
            else
            {
                return "This Name Already Used, please try Another Author Name";
            }
        }

        public bool CheckAuthorId(int id)
        {
            return authorGateway.CheckAuthorId(id);
        }

        public List<Author> GetAllAuthors()
        {
            return authorGateway.GetallAuthors();
        }

        public Author GetAuthorName(int id)
        {
            return authorGateway.GetAuthorName(id);
        }
        public string DeleteAuthor(int id)
        {
            int rowAffected = authorGateway.DeleteAuthor(id);
            if (rowAffected > 0)
            {
                return "Author Delete Successfully.";
            }
            else
            {
                return "Author Delete Failed, Try Again.";
            }
        }

        public string UpdateAuthor(Author author)
        {
            int rowAffected = authorGateway.UpdateAuthor(author);
            if (rowAffected > 0)
            {
                return "Author Update Successfully.";
            }
            else
            {
                return "Author Update Failed, Try Again.";
            }
        }
    }
}