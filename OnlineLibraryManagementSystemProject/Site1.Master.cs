using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineLibraryManagementSystemProject
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ( Session["role"]==null)
            {
                loginLinkButton.Visible = true; //user login button
                bookViewLinkButton.Visible = true;  // View All book button
                signupLinkButton.Visible = true;
                logoutLinkButton.Visible = false; //user logout button
                helloLinkButton.Visible = false; // hello user name button

                adminLoginLinkButton.Visible = true;   //admin login button
                authorManagemntLinkButton.Visible = false;
                bookInventoryLinkButton.Visible = false;
                memberManagementLinkButton.Visible = false;
                bookIssuingLinkButton.Visible = false;
                publisherManagmentLinkButton.Visible = false;
            }
            else if (Session["role"].Equals("user"))
            {
                loginLinkButton.Visible = false; //user login button
                bookViewLinkButton.Visible = true;  // View All book button

                signupLinkButton.Visible = false;
                logoutLinkButton.Visible = true; //user logout button
                helloLinkButton.Visible = true; // hello user name button
                helloLinkButton.Text = "Hello " + Session["UserName"];

                adminLoginLinkButton.Visible = true;   //admin login button
                authorManagemntLinkButton.Visible = false;
                bookInventoryLinkButton.Visible = false;
                memberManagementLinkButton.Visible = false;
                bookIssuingLinkButton.Visible = false;
                publisherManagmentLinkButton.Visible = false;
            }
            else if (Session["role"].Equals("admin"))
            {
                loginLinkButton.Visible = false; //user login button
                bookViewLinkButton.Visible = true;  // View All book button

                signupLinkButton.Visible = false;
                logoutLinkButton.Visible = true; //user logout button
                helloLinkButton.Visible = true; // hello user name button
                helloLinkButton.Text = "Hello " + Session["UserName"];

                adminLoginLinkButton.Visible = false;   //admin login button
                authorManagemntLinkButton.Visible = true;
                bookInventoryLinkButton.Visible = true;
                memberManagementLinkButton.Visible = true;
                bookIssuingLinkButton.Visible = true;
                publisherManagmentLinkButton.Visible = true;
            }
        }
      
        protected void bookViewLinkButton_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/ViewBook.aspx");
        }

       

        protected void signupLinkButton_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/MemberSignUp.aspx");
        }

        protected void logoutLinkButton_OnClick(object sender, EventArgs e)
        {
            Session["UserName"] = null;
            Session["role"] = null;

            loginLinkButton.Visible = true; //user login button
            bookViewLinkButton.Visible = true;  // View All book button
            signupLinkButton.Visible = true;   //new member sign up button
            logoutLinkButton.Visible = false; //user logout button
            helloLinkButton.Visible = false; // hello user name button

            adminLoginLinkButton.Visible = true;   //admin login button
            authorManagemntLinkButton.Visible = false;
            bookInventoryLinkButton.Visible = false;
            memberManagementLinkButton.Visible = false;
            bookIssuingLinkButton.Visible = false;
            publisherManagmentLinkButton.Visible = false;
            
            Response.Redirect("Home.aspx");
        }

        protected void adminLoginLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");
        }

        protected void authorManagementLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AuthorManagement.aspx");
        }

        protected void publisherManagementLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("PublisherManagement.aspx");
        }

        protected void bookInventoryLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookInventory.aspx");
        }

        protected void bookIssuingLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminBookIssuing.aspx");
        }

        protected void memberManagementLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MemberManagement.aspx");
        }

        protected void loginLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserLogin.aspx");
        }

       
    }
}