using Application.TourAndTravel.Web.Models;
using Application.TourAndTravel.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.TourAndTravel.Web.Controllers
{
    //[Authorize]
    public class adminController : Controller
    {
        private readonly DBAccessVM dBAccessVM;
        private readonly PackageRepositories _packageRepositories;
        private readonly RechargeRepositories _rechargeRepositories;
        private string _fileName = string.Empty;
        public adminController()
        {
            _packageRepositories = new PackageRepositories();
            _rechargeRepositories = new RechargeRepositories();
            dBAccessVM = new DBAccessVM();
        }
        private string GetLoggedInUser()
        {
            string userName = string.Empty;
            if (User.Identity.IsAuthenticated) { userName = User.Identity.Name; }
            return userName;
        }
        // GET: admin
        public ActionResult Dashboard()
        {
            string userName = GetLoggedInUser();
            if (!string.IsNullOrEmpty(userName))
                return View();
            else
                return RedirectToAction("Login", "Account");
        }
        [HttpGet]
        public ActionResult PackageTypeByAdmin(int? packageTypeID)
        {
            string userName = GetLoggedInUser();
            if (!string.IsNullOrEmpty(userName))
            {
                PackageTypeByAdmin coll = null;
                if (packageTypeID != null)
                {
                    coll = _packageRepositories.getPackageTypeDataById(packageTypeID);
                    if (coll != null)
                        return View(coll);
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult PackageTypeByAdmin(PackageTypeByAdmin packageTypeByAdmin, HttpPostedFileBase Image)
        {
            string userName = GetLoggedInUser();
            if (!string.IsNullOrEmpty(userName))
            {
                string ImageName = string.Empty;
                if (packageTypeByAdmin.PackageTypeID == 0)
                {
                    ImageName = GetImage(Image);
                    if (ImageName != null)
                    {
                        packageTypeByAdmin.Image = ImageName;
                        packageTypeByAdmin.CreatedBy = userName;
                        packageTypeByAdmin.ModifiedBy = "";
                        int i = _packageRepositories.PackageTypeByAdminsave(packageTypeByAdmin);
                        TempData["msg"] = "Save Successfully";
                    }
                    else
                    {
                        TempData["msg"] = "Image size must be less than or equal to 300KB";
                    }

                }
                else
                {
                    ImageName = GetImage(Image);
                    packageTypeByAdmin.Image = ImageName;
                    packageTypeByAdmin.ModifiedBy = userName;
                    int i = _packageRepositories.UpdatePackageTypeDataById(packageTypeByAdmin, out _fileName);
                    var filePath = Server.MapPath("~/img/" + _fileName);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                    TempData["msg"] = "Information updated Successfully";
                }
                return RedirectToAction("PackageTypeByAdmin");
            }
            else
            {
                return RedirectToAction("Login","Account");
            }
               
        }

        private string GetImage(HttpPostedFileBase Image)
        {
            string ImageName = string.Empty;
            Random rnd = new Random();
            var extensions = "";
            var allowExtensions = new[]
            {
                ".jpg",".Jpg",".png",".jpeg"
            };
            if (Image != null)
            {
                extensions = Path.GetExtension(Image.FileName);
            }
            if (allowExtensions.Contains(extensions))
            {
                int filelength = 0;
                filelength = Image.ContentLength;
                if (filelength > 307200)
                {
                    return ImageName = null;
                }
                else
                {
                    string filename = "";
                    filename = Image.FileName;
                    var dt = DateTime.Now.ToString("ddmmyyyy");
                    if (extensions == ".jpg")
                    {
                        var pp7 = rnd.Next(4, 9999).ToString();
                        Image.SaveAs(HttpContext.Server.MapPath("~/img/") + pp7 + dt + ".jpg");
                        ImageName = pp7 + dt + ".jpg";
                        return ImageName;
                    }
                    else if (extensions == ".jpeg")
                    {
                        var pp7 = rnd.Next(4, 9999).ToString();
                        Image.SaveAs(HttpContext.Server.MapPath("~/img/") + pp7 + dt + ".jpeg");
                        ImageName = pp7 + dt + ".jpeg";
                        return ImageName;
                    }
                    else if (extensions == ".Jpg")
                    {
                        var pp7 = rnd.Next(4, 9999).ToString();
                        Image.SaveAs(HttpContext.Server.MapPath("~/img/") + pp7 + dt + ".Jpg");
                        ImageName = pp7 + dt + ".Jpg";
                        return ImageName;
                    }
                    else if (extensions == ".png")
                    {
                        var pp7 = rnd.Next(4, 9999).ToString();
                        Image.SaveAs(HttpContext.Server.MapPath("~/img/") + pp7 + dt + ".png");
                        ImageName = pp7 + dt + ".png";
                        return ImageName;
                    }
                    else
                    {
                        return ImageName = null;
                    }
                }
            }
            else
            {
                return ImageName = null;
            }
        }

        [HttpGet]
        public ActionResult List_PackageTypeByAdmin()
        {
            return View();
        }
        [HttpGet]
        public ActionResult deletePackageTypeByAdmin(int? packageTypeID)
        {
            int i = 0;
            if (packageTypeID != null)
            {
                i = _packageRepositories.DeletePackageTypeByAdminsave(packageTypeID);
                if (i > 0)
                {
                    TempData["msg"] = "Data Delete Succeccfully....";
                }
                else
                {
                    TempData["msg"] = "! there is problem no data delete";
                }
            }
            return RedirectToAction("List_PackageTypeByAdmin");
        }

        [HttpGet]
        public ActionResult RechargeByAdmin(int? rechargeID)
        {
            RechargeInfo coll = null;
            var list = dBAccessVM.travellerRegistration.ToList();
            if (rechargeID != null)
            {
                coll = _rechargeRepositories.getRechargeTypeDataById(rechargeID);
                if (coll != null)
                {
                    ViewBag.Companies = list;
                    return View(coll);
                }
                else
                {
                    ViewBag.Companies = list;
                    return View();
                }
            }
            else
            {
                ViewBag.Companies = list;
                return View();
            }
        }

        [HttpPost]
        public ActionResult RechargeByAdmin(RechargeInfo rechargeInfo)
        {
            
            WalletCRDRHistory walletCRDR = new WalletCRDRHistory();
            string userName = GetLoggedInUser();
            if(!string.IsNullOrEmpty(userName))
            {
                if (rechargeInfo.RechargeID == 0)
                {
                    rechargeInfo.CreatedBy = userName;
                    rechargeInfo.IsDelete = true;
                    int i = _rechargeRepositories.RechargeInfiSave(rechargeInfo);
                    walletCRDR.Credit = Convert.ToDecimal(rechargeInfo.WalletBalance);
                    walletCRDR.Debit = 0;
                    walletCRDR.TravellerEmail = rechargeInfo.TravelAgentEmail;
                    walletCRDR.CreditDebitDate = System.DateTime.Now;
                    dBAccessVM.walletCRDRHistories.Add(walletCRDR);
                    dBAccessVM.SaveChanges();
                    TempData["msg"] = "Save Successfully....";
                    return RedirectToAction("RechargeByAdmin");
                }
                else
                {
                    rechargeInfo.ModifiedBy = userName;
                    int i = _rechargeRepositories.UpdateRechargeInfo(rechargeInfo);
                    walletCRDR.Credit = Convert.ToDecimal(rechargeInfo.WalletBalance);
                    walletCRDR.Debit = 0;
                    walletCRDR.TravellerEmail = rechargeInfo.TravelAgentEmail;
                    walletCRDR.CreditDebitDate = System.DateTime.Now;
                    dBAccessVM.walletCRDRHistories.Add(walletCRDR);
                    dBAccessVM.SaveChanges();
                    TempData["msg"] = "Update Successfully....";
                    return RedirectToAction("RechargeByAdmin");
                }
            }
            else
            {
                return RedirectToAction("Login","Account");
            }
        }
        [HttpGet]
        public ActionResult ListRechargeByAdmin()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DeleteRechargeInfo(int? rechargeID)
        {
            int i = 0;
            if (rechargeID != null)
            {
                i = _rechargeRepositories.DeleteRechargeInfo(rechargeID);
                if (i > 0)
                {
                    TempData["msg"] = "Data Delete Successfully....";
                }
                else
                {
                    TempData["msg"] = "! Error Some Problem.";
                }
            }
            return RedirectToAction("ListRechargeByAdmin");
        }
        [HttpGet]
        public ActionResult ListTravlerRegistration()
        {
            return View();
        }
        [HttpGet]
        public ActionResult PackageUserList()
        {
            return View();
        }
        [HttpGet]
        public ActionResult LeadBookingInfo()
        {
            return View();
        }
        [HttpGet]
        public ActionResult LeadGetItineraryInfo()
        {
            
            return View();
        }


    }
}