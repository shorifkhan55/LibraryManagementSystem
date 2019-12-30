using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineLibraryManagementSystemProject.DAL;
using OnlineLibraryManagementSystemProject.Model;

namespace OnlineLibraryManagementSystemProject.BLL
{
    public class MemberManager
    {
        MemberGateway memberGateway=new MemberGateway();

        public string SaveMember(Member member)
        {
            bool isMemberId = memberGateway.CheckMemberId(member);
            if (isMemberId==false)
            { 
                int rowAffected = memberGateway.SaveMember(member);
            if (rowAffected > 0)
            {
                return "Registration Successful, go to user login for login.";
            }
            else
            {
                return "Registration Failed, Try Again.";
            }
            }
            else
            {
                return "This Email Already Used, please try Another Email";
            }
        }

        public bool LoginMember(string email, string password)
        {
            bool isLogin = memberGateway.LoginMember(email, password);
            return isLogin;
            //if (isLogin == true)
            //{
            //    return email;
            //}
            //else
            //{
            //    return "Please check your Email & Password";
            //}
        }

        public List<Member> GetAllMembers()
        {
            return memberGateway.GetallMembers();
        }

        public Member GetMemberForAdmin(int id)
        {
            return memberGateway.GetMemberForAdmin(id);

        }
        public bool GetMemberForIssuedBook(int id)
        {
            return memberGateway.GetMemberForIssuedBook(id);
        }

        public string UpdateAccountStatus(Member member)
        {
            int rowAffected = memberGateway.UpdateAccountStatus(member);
            if (rowAffected > 0)
            {
                return "Status Update Successfully.";
            }
            else
            {
                return "Status Update Failed, Try Again.";
            }
        }
        public string DeleteMember(int id)
        {
            int rowAffected = memberGateway.DeleteMember(id);
            if (rowAffected > 0)
            {
                return "Member Delete Successfully.";
            }
            else
            {
                return "Member Delete Failed, Try Again.";
            }
        }


    }
}