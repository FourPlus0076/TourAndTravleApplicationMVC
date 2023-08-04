using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Application.TourAndTravel.Web.Models;
using Application.TourAndTravel.Web.Models.Repositories;

namespace Application.TourAndTravel.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly LoginRepositories _loginRepositories;
        public AccountController()
        {
            _loginRepositories = new LoginRepositories();
        }
        // GET: Account
        [HttpGet]
        public ActionResult TravellerLogin()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username,string password)
        {
            if(!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                bool x = _loginRepositories.GetAdminLoginDetails(username, password);
                if(x==true)
                {
                    return RedirectToAction("Dashboard", "admin");
                }
                else
                {
                    TempData["msg"] = "Invalid Username or Password";
                    return RedirectToAction("Login", "Account");
                }
            }
            else
            {
                TempData["msg"] = "Invalid Username or Password";
                return RedirectToAction("Login", "Account");
            }
        }
        [HttpPost]
        public ActionResult TravellerLogin(LoginVM loginVM)
        {
            bool isVerify = false;
            isVerify = _loginRepositories.GetLoginDetails(loginVM);
            if(isVerify==true)
            {
                return RedirectToAction("Leads", "Traveller");
            }
            else
            {
                TempData["msg"] = "Username or Password Invalid or Admin did not give the permission yet.";
                return RedirectToAction("TravellerLogin", "Account");
            }

        }
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}