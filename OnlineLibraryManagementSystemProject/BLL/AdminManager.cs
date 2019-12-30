using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineLibraryManagementSystemProject.DAL;

namespace OnlineLibraryManagementSystemProject.BLL
{
    public class AdminManager
    {

        AdminGateway adminGateway=new AdminGateway();
        public bool LoginAdmin(string email, string password)
        {
            return adminGateway.LoginAdmin(email, password);
        }
    }
}