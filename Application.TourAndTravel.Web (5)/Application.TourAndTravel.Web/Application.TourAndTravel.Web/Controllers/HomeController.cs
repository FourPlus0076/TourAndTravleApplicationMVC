using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.TourAndTravel.Web.Models;

namespace Application.TourAndTravel.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookingRepositories _bookingRepositories;
        public HomeController()
        {
            _bookingRepositories = new BookingRepositories();
        }
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(BookingInfo bookingInfo)
        {
            int i = 0;
            i = _bookingRepositories.SaveLeadInfo(bookingInfo);
            if(i>0)
            {
                TempData["msg"] = "Submit your Request Successfully HR Will Contact Soon...";
            }
            else
            {
                TempData["msg"] = "Failed ! Try Again.";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AllPackage()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AboutUs()
        {
            return View();
        }

        [HttpGet] 
        public ActionResult ContactUs()
        {
            return View();
        }
        [HttpGet]

        
        public ActionResult PackageDetails(int? PackageTypeID)
        {
            TempData["PID"] = PackageTypeID;
            return View();
        }

        [HttpGet]
        public ActionResult SendEnquiry()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SendEnquiry(BookingInfo bookingInfo)
        {
            int i = 0;
            var packageId = TempData.Peek("PID").ToString();
            i = _bookingRepositories.SaveLeadInfo(bookingInfo);
            if (i > 0)
            {
                TempData["msg"] = "Submit your Request Successfully HR Will Contact Soon...";
            }
            else
            {
                TempData["msg"] = "Failed ! Try Again.";
            }
            //return RedirectToAction("Index");
            return View();
        }

        [HttpPost]
        public ActionResult GetItineraryInfo(GetItinerary GetItineraryInfo)
        {
            int i = 0;           
            i = _bookingRepositories.SaveItineraryInfo(GetItineraryInfo);
            if (i > 0)
            {
                TempData["msg"] = "Submit your Request Successfully HR Will Contact Soon...";
            }            
            {
                TempData["msg"] = "Failed ! Try Again.";
            }            
            return View();
        }

    }
}