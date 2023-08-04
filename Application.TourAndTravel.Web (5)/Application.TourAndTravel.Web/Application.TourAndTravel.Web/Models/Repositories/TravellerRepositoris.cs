using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.TourAndTravel.Web.Models
{
    public class TravellerRepositoris
    {
        private readonly DBAccessVM _dBAccessVM;
        public TravellerRepositoris()
        {
            _dBAccessVM = new DBAccessVM();
        }
        public int TravellerSignUp(TravellerRegistration travellerRegistration)
        {
            int i = 0;
            travellerRegistration.CreatedDate = DateTime.Now;
            travellerRegistration.ModifiedDate = DateTime.Now;
            _dBAccessVM.travellerRegistration.Add(travellerRegistration);
            if (_dBAccessVM.SaveChanges() > 0)
            {
                i = 1;
                return i;
            }
            else
            {
                return i;
            }
        }

        public List<BookingInfo> GetAllLeads()
        {
            List<BookingInfo> bookings = null;
            bookings = _dBAccessVM.bookingInfo.ToList();
            return bookings;
        }

        public bool SellLead(long leadID, string userName)
        {
            _ = new IsLeadGenerated();
            long ExistsLeadToUser = CheckExistsLeadStatusByUser(userName, leadID);
            int SoldLeadCount = GetSoldLeadCount(leadID);
            bool x;
            if (ExistsLeadToUser != 0)
            {
                x = true;
                return x;
            }
            else
            {
                x = false;
                IsLeadGenerated _isLeadGenerated = new IsLeadGenerated
                {
                    LeadID = leadID,
                    SellDate = System.DateTime.Now,
                    SoldLeadCount = 1,
                    TravellerUserName = userName
                };
                _dBAccessVM.isLeadGenerated.Add(_isLeadGenerated);
                _dBAccessVM.SaveChanges();
                return x;
            }
        }

        private long CheckExistsLeadStatusByUser(string userName, long leadID)
        {
            long _leadID = 0;
            _leadID = _dBAccessVM.isLeadGenerated.Where(a => a.TravellerUserName == userName && a.LeadID == leadID).Select(a => a.LeadID).FirstOrDefault();
            return _leadID;
        }
        private int GetSoldLeadCount(long leadID)
        {
            int _leadCount = 0;
            if (leadID != 0)
            {
                _leadCount = _dBAccessVM.isLeadGenerated.Where(a => a.LeadID == leadID).Select(a => a.SoldLeadCount).Count();
                return _leadCount;
            }
            else
            {
                return _leadCount;
            }

        }

        public List<BookingInfo> GetMyLeads(string userName)
        {
            string sqlQuery = "SELECT BookingInfoID,ClientName,MobileNo,Email,NoOfAdults,NoOfKids,Destination,DepartureDate,FromCity,Requirements,CreatedDate,Duration FROM BookingInfo LEFT JOIN IsLeadGenerated ON BookingInfo.BookingInfoID = IsLeadGenerated.LeadID WHERE IsLeadGenerated.TravellerUserName = '" + userName + "'";
            List<BookingInfo> getMyLeads = null;
            getMyLeads = _dBAccessVM.Database.SqlQuery<BookingInfo>(sqlQuery).ToList<BookingInfo>();
            if (getMyLeads != null)
                return getMyLeads;
            else
                return getMyLeads;
        }
        public bool CheckWalletAmount(string userName)
        {

            bool x;
            if (!string.IsNullOrEmpty(userName))
            {
                decimal? walletAmount = _dBAccessVM.Recharge.Where(a => a.TravelAgentEmail == userName).Select(a => a.WalletBalance).Sum();
                if (walletAmount >= 75 && walletAmount != null)
                {
                    x = true;
                    return x;
                }
                else
                {
                    x = false;
                    return x;
                }
            }
            else
            {
                x = false;
                return x;
            }

        }

        public void UpdateWallet(string userName, decimal amount)
        {
            WalletCRDRHistory walletCRDR = new WalletCRDRHistory();
            bool x;
            if (!string.IsNullOrEmpty(userName) && amount != 0)
            {
                var data = _dBAccessVM.Recharge.Where(a => a.TravelAgentEmail == userName).FirstOrDefault();
                data.WalletBalance = data.WalletBalance - amount;
                if(_dBAccessVM.SaveChanges()>0)
                {
                    walletCRDR.Debit = amount;
                    walletCRDR.CreditDebitDate = DateTime.Now;
                    walletCRDR.Credit = 0;
                    walletCRDR.TravellerEmail = userName;
                    _dBAccessVM.walletCRDRHistories.Add(walletCRDR);
                    _dBAccessVM.SaveChanges();
                }


            }
        }

        public Packages getAddPackageID(int? packageID)
        {
            Packages data = new TourAndTravel.Packages();
            if (packageID != null)
            {
                data = _dBAccessVM.Package.Where(a => a.PackageID == packageID).FirstOrDefault();

                return data;
            }
            else
            { return data; }
        }


        public int UserSaveAddPackage(Packages packages)
        {
            int i = 0;
            packages.CreatedDate = DateTime.Now;
            packages.ModifiedDate = DateTime.Now;
            packages.IsDelete = false;
            packages.CreatedBy = "";
            packages.ModifiedBy = "";
            _dBAccessVM.Package.Add(packages);
            if (_dBAccessVM.SaveChanges() > 0)
            {
                i = 0;
                return i;
            }
            else
            {
                return i;
            }
        }

        public int UpdateAddPackage(Packages model)
        {
            int i = 0;
            Packages data = null;
            if (model != null)
            {
                data = _dBAccessVM.Package.Where(a => a.PackageID == model.PackageID).FirstOrDefault();
                data.TourType = model.TourType;
                data.Duration = model.Duration;
                data.MealPlan = model.MealPlan;
                data.PackageTitle = model.PackageTitle;
                data.TotalPrice = model.TotalPrice;
                data.TourPic = model.TourPic;
                data.DayOneArrivalCityName = model.DayOneArrivalCityName;
                data.DayOneHotelName = model.DayOneHotelName;
                data.DayOneHotelStar = model.DayOneHotelStar;
                data.DayOnePickupIncluded = model.DayOnePickupIncluded;
                data.DayOneWelcomeDrink = model.DayOneWelcomeDrink;
                data.DayOnePackageTitle = model.DayOnePackageTitle;
                data.DayOneAddMore = model.DayOneAddMore;
                data.DayTwoArrivalCityName = model.DayTwoArrivalCityName;
                data.DayTwoHotelName = model.DayTwoHotelName;
                data.DayTwoHotelStar = model.DayTwoHotelStar;
                data.DayTwoPackageTitle = model.DayTwoPackageTitle;
                data.DayTwoAddMore = model.DayTwoAddMore;
                data.DayThreeArrivalCityName = model.DayThreeArrivalCityName;
                data.DayThreeHotelName = model.DayThreeHotelName;
                data.DayThreeHotelStar = model.DayThreeHotelStar;
                data.DayThreePackageTitle = model.DayThreePackageTitle;
                data.DayThreeAddMore = model.DayThreeAddMore;
                data.DayFourArrivalCityName = model.DayFourArrivalCityName;
                data.DayFourHotelName = model.DayFourHotelName;
                data.DayFourHotelStar = model.DayFourHotelStar;
                data.DayFourPackageTitle = model.DayFourPackageTitle;
                data.DayFourAddMore = model.DayFourAddMore;
                data.DayFiveArrivalCityName = model.DayFiveArrivalCityName;
                data.DayFiveHotelName = model.DayFiveHotelName;
                data.DayFiveHotelStar = model.DayFiveHotelStar;
                data.DayFivePackageTitle = model.DayFivePackageTitle;
                data.DayFiveAddMore = model.DayFiveAddMore;
                data.DaySixArrivalCityName = model.DaySixArrivalCityName;
                data.DaySixHotelName = model.DaySixHotelName;
                data.DaySixHotelStar = model.DaySixHotelStar;
                data.DaySixPackageTitle = model.DaySixPackageTitle;
                data.DaySixAddMore = model.DaySixAddMore;
                data.DaySevenArrivalCityName = model.DaySevenArrivalCityName;
                data.DaySevenHotelName = model.DaySevenHotelName;
                data.DaySevenHotelStar = model.DaySevenHotelStar;
                data.DaySevenPackageTitle = model.DaySevenPackageTitle;
                data.DaySevenAddMore = model.DaySevenAddMore;
                data.DayEightArrivalCityName = model.DayEightArrivalCityName;
                data.DayEightHotelName = model.DayEightHotelName;
                data.DayEightHotelStar = model.DayEightHotelStar;
                data.DayEightPackageTitle = model.DayEightPackageTitle;
                data.DayEightAddMore = model.DayEightAddMore;
                data.DayNineArrivalCityName = model.DayNineArrivalCityName;
                data.DayNineHotelName = model.DayNineHotelName;
                data.DayNineHotelStar = model.DayNineHotelStar;
                data.DayNinePackageTitle = model.DayNinePackageTitle;
                data.DayNineAddMore = model.DayNineAddMore;
                data.DayTenArrivalCityName = model.DayTenArrivalCityName;
                data.DayTenHotelName = model.DayTenHotelName;
                data.DayTenHotelStar = model.DayTenHotelStar;
                data.DayTenPackageTitle = model.DayTenPackageTitle;
                data.DayTenAddMore = model.DayTenAddMore;
                data.IsDelete = false;
                data.CreatedDate = DateTime.Now;
                data.ModifiedDate = DateTime.Now;
                data.CreatedBy = "";
                data.ModifiedBy = "";
                data.ConditionFirstBookingAmountRequired = model.ConditionFirstBookingAmountRequired;
                data.ConditionSecondRefundCancelledOne = model.ConditionSecondRefundCancelledOne;
                data.ConditionSecondRefundCancelledTwo = model.ConditionSecondRefundCancelledTwo;
                data.ConditionSecondRefundCancelledThree = model.ConditionSecondRefundCancelledThree;
                data.PercentAmount = model.PercentAmount;
                data.NoOfDayNight = model.NoOfDayNight;
                data.NoOfDayNight1 = model.NoOfDayNight1;
                data.NoOfDayNight2 = model.NoOfDayNight2;
                data.PercentAmount1 = model.PercentAmount1;
                data.PercentAmount2 = model.PercentAmount2;
                data.PercentAmount3 = model.PercentAmount3;
                if (_dBAccessVM.SaveChanges() > 0)
                {
                    i = 1;
                    return i;
                }
                return i;
            }
            else
            { return i; }
        }
        public int DeleteAddPackage(int? packageID)
        {
            int i = 0;
            var coll = _dBAccessVM.Package.Where(a => a.PackageID == packageID).FirstOrDefault();
            if (coll != null)
            {
                coll.IsDelete = true;
                _dBAccessVM.SaveChanges();
                i = 1;
                return i;
            }
            else
            {
                return i;
            }
        }
    }
}