using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineLibraryManagementSystemProject.BLL;
using OnlineLibraryManagementSystemProject.Model;

namespace OnlineLibraryManagementSystemProject
{
    public partial class AuthorManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AuthorGridView.DataBind();
        }
        AuthorManager authorManager=new AuthorManager();
        private Author author;
        protected void AddButton_Click(object sender, EventArgs e)
        {
            if (authorNameTextBox.Text=="")
            {
                Response.Write("<script>alert('Please Insert Author Name');</script>");
            }
            else
            {
                author = new Author();
                author.AuthorName = authorNameTextBox.Text;
                string message = authorManager.SaveAuthor(author);
                Response.Write("<script>alert('" + message + "');</script>");
                AuthorGridView.DataBind();
            }
           
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            if (authorIdTextBox.Text == "")
            {
                Response.Write("<script>alert('Please Insert Author Id');</script>");
            }
            else
            {
                author = new Author();
                author.AuthorId = Convert.ToInt32(authorIdTextBox.Text);
                author.AuthorName = authorNameTextBox.Text;
                string message = authorManager.UpdateAuthor(author);
                Response.Write("<script>alert('" + message + "');</script>");

                AuthorGridView.DataBind();
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            if (authorIdTextBox.Text=="")
            {
                Response.Write("<script>alert('Please Insert Author Id');</script>");

            }
            else
            {
                author = new Author();
                author.AuthorId = Convert.ToInt32(authorIdTextBox.Text);
                string message = authorManager.DeleteAuthor(author.AuthorId);
                Response.Write("<script>alert('" + message + "');</script>");
                AuthorGridView.DataBind();
            }
        }

        protected void goButton_OnClick(object sender, EventArgs e)
        {
            if (authorIdTextBox.Text!="")
            {
                int id = Convert.ToInt32(authorIdTextBox.Text);
                bool isAuthor = authorManager.CheckAuthorId(id);
                if (!isAuthor)
                {
                    Response.Write("<script>alert('Please Insert Right ID');</script>");

                }
                else
                {
                    author = authorManager.GetAuthorName(id);
                    authorIdTextBox.Text = author.AuthorId.ToString();
                    authorNameTextBox.Text = author.AuthorName;
                }
                
            }
            else
            {
                Response.Write("<script>alert('Please Insert Author Id');</script>");

            }
        }
    }
}