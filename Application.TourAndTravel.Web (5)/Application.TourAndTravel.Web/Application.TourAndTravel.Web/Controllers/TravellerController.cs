using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.TourAndTravel.Web.Models;

namespace Application.TourAndTravel.Web.Controllers
{
    
    public class TravellerController : Controller
    {
        private readonly DBAccessVM dBAccess;
        private readonly  TravellerRepositoris _travellerRepositoris;
        public TravellerController()
        {
            _travellerRepositoris = new TravellerRepositoris();
            dBAccess = new DBAccessVM();
        }
        // GET: Traveller
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(TravellerRegistration travellerRegistration)
        {
            int i = _travellerRepositoris.TravellerSignUp(travellerRegistration);
            if (i > 0)
            {
                TempData["msg"] = "Your Registration is successfully";
                return RedirectToAction("SignUp");
            }
            else
            {

                TempData["msg"] = "Failed ! Try again";
                return RedirectToAction("SignUp");
            }
        }

        [HttpGet]
        public ActionResult TravellerLogin()
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        public ActionResult Leads()
        {
                List<BookingInfo> bookings = null;
                bookings = _travellerRepositoris.GetAllLeads();
                if (bookings.Count > 0)
                    return View(bookings);
                else
                    return View();
          
        }
        [Authorize]
        [HttpPost]
        public ActionResult SellLead(string leadID)
        {
            try
            {
                if (!string.IsNullOrEmpty(leadID))
                {
                    bool x;
                    bool xy;
                    long leadId = Convert.ToInt32(leadID);
                    string userName = string.Empty;
                    if (User.Identity.IsAuthenticated) { userName = User.Identity.Name; }
                    x = _travellerRepositoris.SellLead(leadId, userName);
                    if (x != true)
                    {
                        _travellerRepositoris.UpdateWallet(userName, 75);
                        TempData["msg"] = "You have successfully purchased your leads and now you can see all the information.";
                        return RedirectToAction("Leads");
                    }
                    else
                    {
                        ViewBag.SoldLeadByUser = "true";
                        TempData["msg"] = "You have already buy this lead, please buy other one.";
                        return RedirectToAction("Leads");
                    }
                }
                else
                {
                    return RedirectToAction("Leads");
                }
            }
            catch(Exception ex)
            {
                TempData["msg"]= ex.Message.ToString();
                return RedirectToAction("Leads");
            }
            
            
        }

        [Authorize]
        [HttpGet]
        public ActionResult MyLeads()
        {
            string userName = string.Empty;
            if (User.Identity.IsAuthenticated) { userName = User.Identity.Name; }
            List<BookingInfo> myleads = null;
            myleads = _travellerRepositoris.GetMyLeads(userName);
            if (myleads != null)
                return View(myleads);
            else
                return View();
        }

        [HttpGet]
        public ActionResult GetTravellerInfo(int? travellerID)
        {
            GetCompaniesVM getCompanies = new GetCompaniesVM();
            if (travellerID!=0 && travellerID!=null)
            {
                var data = dBAccess.travellerRegistration.Where(a => a.TravellerID == travellerID).FirstOrDefault();
                getCompanies.TravellerName = data.TravellerName;
                getCompanies.TravellerEmail = data.TravellerEmail;
                return (ActionResult)this.Json((object)getCompanies, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return (ActionResult)this.Json((object)getCompanies, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult AddPackage(int? packageID)
        {
            Packages coll = null;
            if (packageID != null)
            {
                coll = _travellerRepositoris.getAddPackageID(packageID);
                if (coll != null)
                    return View(coll);
                else
                    return View();
            }
            return View();
        }

        [HttpPost]
        public ActionResult SaveAddPackage(Packages packages, HttpPostedFileBase TourPic)
        {
            Random rnd = new Random();
            var extensions = "";
            var allowExtensions = new[]
            {
                ".jpg",".Jpg",".png",".jpeg"
            };
            if (TourPic != null)
            {
                extensions = Path.GetExtension(TourPic.FileName);
            }
         
            if (allowExtensions.Contains(extensions))
            {
                int filelength = 0;
                filelength = TourPic.ContentLength;
                if (filelength > 307200)
                {
                    TempData["msg"] = "Image size must be less than or equal to 300KB";
                    return RedirectToAction("AddPackage");
                }
                else
                {
                    if (packages.PackageID == 0)
                    {
                        string filename = "";
                        filename = TourPic.FileName;
                        var dt = DateTime.Now.ToString("ddmmyyyy");
                        if (extensions == ".jpg")
                        {
                            var pp7 = rnd.Next(4, 9999).ToString();
                            TourPic.SaveAs(HttpContext.Server.MapPath("~/img/") + pp7 + dt + ".jpg");
                            packages.TourPic = pp7 + dt + ".jpg";
                        }
                        else if (extensions == ".jpeg")
                        {
                            var pp7 = rnd.Next(4, 9999).ToString();
                            TourPic.SaveAs(HttpContext.Server.MapPath("~/img/") + pp7 + dt + ".jpeg");
                            packages.TourPic = pp7 + dt + ".jpeg";
                        }
                        else if (extensions == ".Jpg")
                        {
                            var pp7 = rnd.Next(4, 9999).ToString();
                            TourPic.SaveAs(HttpContext.Server.MapPath("~/img/") + pp7 + dt + ".Jpg");
                            packages.TourPic = pp7 + dt + ".Jpg";
                        }
                        else if (extensions == ".png")
                        {
                            var pp7 = rnd.Next(4, 9999).ToString();
                            TourPic.SaveAs(HttpContext.Server.MapPath("~/img/") + pp7 + dt + ".png");
                            packages.TourPic = pp7 + dt + ".png";
                        }

                        int i = _travellerRepositoris.UserSaveAddPackage(packages);
                        TempData["msg"] = "Save Successfully";
                    }
                    else
                    {
                        string filename = "";
                        filename = TourPic.FileName;
                        var dt = DateTime.Now.ToString("ddmmyyyy");
                        if (extensions == ".jpg")
                        {
                            var pp7 = rnd.Next(4, 9999).ToString();
                            TourPic.SaveAs(HttpContext.Server.MapPath("~/img/") + pp7 + dt + ".jpg");
                            packages.TourPic = pp7 + dt + ".jpg";
                        }
                        else if (extensions == ".jpeg")
                        {
                            var pp7 = rnd.Next(4, 9999).ToString();
                            TourPic.SaveAs(HttpContext.Server.MapPath("~/img/") + pp7 + dt + ".jpeg");
                            packages.TourPic = pp7 + dt + ".jpeg";
                        }
                        else if (extensions == ".Jpg")
                        {
                            var pp7 = rnd.Next(4, 9999).ToString();
                            TourPic.SaveAs(HttpContext.Server.MapPath("~/img/") + pp7 + dt + ".Jpg");
                            packages.TourPic = pp7 + dt + ".Jpg";
                        }
                        else if (extensions == ".png")
                        {
                            var pp7 = rnd.Next(4, 9999).ToString();
                            TourPic.SaveAs(HttpContext.Server.MapPath("~/img/") + pp7 + dt + ".png");
                            packages.TourPic = pp7 + dt + ".png";
                        }
                        int i = _travellerRepositoris.UpdateAddPackage(packages);
                        TempData["msg"] = "Save Successfully";
                    }
                }
            }
            return RedirectToAction("AddPackage");
        }

        public ActionResult ManageAddPackage()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DeleteManageAddPackage(int? packageID)
        {
            int i = 0;
            if (packageID != null)
            {
                i = _travellerRepositoris.DeleteAddPackage(packageID);
                if (i > 0)
                {
                    TempData["msg"] = "Data Delete Succeccfully....";
                }
                else
                {
                    TempData["msg"] = "! there is problem no data delete";
                }
            }
            return RedirectToAction("ManageAddPackage");
        }
    }
}