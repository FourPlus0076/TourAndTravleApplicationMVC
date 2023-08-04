using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Application.TourAndTravel.Web.Models.Repositories
{
    public class LoginRepositories
    {
        private readonly DBAccessVM _dBAccessVM;
        public LoginRepositories()
        {
            _dBAccessVM = new DBAccessVM();
        }

        public bool GetLoginDetails(LoginVM loginVM)
        {
            var data = _dBAccessVM.travellerRegistration.Where(a => a.TravellerEmail == loginVM.Email && a.TravellerPassword == loginVM.Password).FirstOrDefault();
            if (data != null && data.IsVerify==true)
            {
                FormsAuthentication.SetAuthCookie(data.TravellerEmail, false);
                return data.IsVerify;
            }
            else
            {
                return data.IsVerify;
            }
        }
        public bool GetAdminLoginDetails(string username,string password)
        {
            bool x;
            var data = _dBAccessVM.adminLogin.Where(a => a.UserName == username && a.UserPassword == password).FirstOrDefault();
            if (data != null)
            {
                x = true;
                FormsAuthentication.SetAuthCookie(username, false);
                return x;
            }
            else
            {
                x = false;
                return x;
            }
        }
    }
}