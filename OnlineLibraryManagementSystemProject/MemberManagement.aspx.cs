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
    public partial class MemberManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            GridView1.DataBind();
        }
        MemberManager memberManager=new MemberManager();

        private Member member;
        protected void searchLinkButton_OnClick(object sender, EventArgs e)
        {

            LoadMemberData();

        }

        public void LoadMemberData()
        {
            if (memberIdTextBox.Text!="")
            {
                member = new Member();
                int id = Convert.ToInt32(memberIdTextBox.Text);
                member = memberManager.GetMemberForAdmin(id);
                fullNameTextBox.Text = member.FullName;
                DOBTextBox.Text = member.DOB;
                contactNoTextBox.Text = member.ContactNo;
                accountStatusTextBox.Text = member.AccountStatus;
                emailTextBox.Text = member.Email;
                stateTextBox.Text = member.State;
                cityTextBox.Text = member.City;
                pinCodeTextBox.Text = member.PinCode;
                fullAddressTextBox.Text = member.FullAddress;
            }
            else
            {
                Response.Write("<script>alert('Please Enter Member ID');</script>");
            }
        }
        protected void ActiveLinkButton_OnClick(object sender, EventArgs e)
        {
            if (memberIdTextBox.Text!="")
            {
                member =new Member();
                member.Id = Convert.ToInt32(memberIdTextBox.Text);
                member.AccountStatus = "active";
                string message = memberManager.UpdateAccountStatus(member);
                Response.Write("<script>alert('"+message+"');</script>");

                Clean();
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script>alert('Please Enter Member ID');</script>");
            }
        }

        protected void PandingLinkButton_OnClick(object sender, EventArgs e)
        {
            if (memberIdTextBox.Text != "")
            {
                member = new Member();
                member.Id = Convert.ToInt32(memberIdTextBox.Text);
                member.AccountStatus = "Pending";
                string message = memberManager.UpdateAccountStatus(member);
                Response.Write("<script>alert('" + message + "');</script>");
                GridView1.DataBind();
                Clean();
            }
            else
            {
                Response.Write("<script>alert('Please Enter Member ID');</script>");
            }
        }

        protected void DeactiveLinkButton_OnClick(object sender, EventArgs e)
        {
            if (memberIdTextBox.Text != "")
            {
                member = new Member();
                member.Id = Convert.ToInt32(memberIdTextBox.Text);
                member.AccountStatus = "Deactive";
                string message = memberManager.UpdateAccountStatus(member);
                Response.Write("<script>alert('" + message + "');</script>");
                Clean();
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script>alert('Please Enter Member ID');</script>");
            }
        }

        public void Clean()
        {
            memberIdTextBox.Text = "";
            fullNameTextBox.Text = "";
            DOBTextBox.Text = "";
            contactNoTextBox.Text = "";
            accountStatusTextBox.Text = "";
            emailTextBox.Text = "";
            stateTextBox.Text = "";
            cityTextBox.Text = "";
            pinCodeTextBox.Text = "";
            fullAddressTextBox.Text = "";
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {

            if (memberIdTextBox.Text!="")
            {
                int id = Convert.ToInt32(memberIdTextBox.Text);
                string message = memberManager.DeleteMember(id);
                Response.Write("<script>alert('" + message + "');</script>");
                Clean();
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script>alert('Please Insert Member Id!');</script>");
            }
        }
    }
}