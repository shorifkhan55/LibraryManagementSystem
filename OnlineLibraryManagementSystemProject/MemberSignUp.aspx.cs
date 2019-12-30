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
    public partial class MemberSignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void signUpButton_Click(object sender, EventArgs e)
        {
            Member member=new Member();
            MemberManager memberManager=new MemberManager();
            if (emailTextBox.Text!="" && fullNameTextBox.Text!="" && FullAddressTextBox.Text!="" && passwordTextBox2.Text!="" && emailTextBox.Text!="" && contactNumberTextBox.Text!="" && thanaTextBox.Text!="" && DistrictDropDownList.SelectedValue!="select" && postalCodeTextBox.Text!="")
            {
                member.FullName = fullNameTextBox.Text;
                member.DOB = dateofBirthTextBox.Text;
                member.ContactNo = contactNumberTextBox.Text;
                member.Email = emailTextBox.Text;
                member.State = DistrictDropDownList.SelectedValue.ToString();
                member.City = thanaTextBox.Text;
                member.PinCode = postalCodeTextBox.Text;
                member.FullAddress = FullAddressTextBox.Text;
                member.Password = passwordTextBox2.Text;
                member.AccountStatus = "Pending";

                string message = memberManager.SaveMember(member);
                Response.Write("<script>alert('" + message + "');</script>");
            }
            else
            {
                Response.Write("<script>alert('Please fill up all information');</script>");
            }

        }
    }
}