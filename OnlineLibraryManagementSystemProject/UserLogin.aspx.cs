using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineLibraryManagementSystemProject.BLL;

namespace OnlineLibraryManagementSystemProject
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string email = emailTextBox.Text;
            string password = PasswordTextBox.Text;

            MemberManager memberManager=new MemberManager();

            bool isLogin = memberManager.LoginMember(email, password);
            if (isLogin == true)
            {
               
                Session["UserName"] = email;
                Session["role"] = "user";
                Response.Redirect("Home.aspx");
            }
            else
            {
                Response.Write("<script>alert('Please check your Email and Password');</script>");
            }
        }
    }
}