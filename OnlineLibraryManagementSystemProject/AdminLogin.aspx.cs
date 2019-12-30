using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineLibraryManagementSystemProject.BLL;
using OnlineLibraryManagementSystemProject.Model;

namespace OnlineLibraryManagementSystemProject
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            AdminManager adminManager=new AdminManager();
            Admin admin=new Admin();
            admin.Email = emailTextBox.Text;
            admin.Password = PasswordTextBox.Text;
            bool isLogin = adminManager.LoginAdmin(admin.Email, admin.Password);
            if (isLogin == true)
            {
                
                Session["UserName"] = admin.Email;
                Session["role"] = "admin";
                Response.Redirect("Home.aspx");
            }
            else
            {
                Response.Write("<script>alert('Please check your Email and Password');</script>");
            }
        }
    } 
}