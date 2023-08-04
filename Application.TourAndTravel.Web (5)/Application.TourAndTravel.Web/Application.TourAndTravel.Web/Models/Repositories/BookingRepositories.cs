using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.TourAndTravel.Web.Models
{
    public class BookingRepositories
    {
        private readonly DBAccessVM _dBAccessVM;
        public BookingRepositories()
        {
            _dBAccessVM = new DBAccessVM();
        }

        public int SaveLeadInfo(BookingInfo bookingInfo)
        {
            int i = 0;
            bookingInfo.CreatedDate = DateTime.Now;
            _dBAccessVM.bookingInfo.Add(bookingInfo);
            if(_dBAccessVM.SaveChanges()>0)
            {
                i = 1;
                return i;
            }
            else
            {
                return i;
            }

        }

        public int SaveItineraryInfo(GetItinerary GetItineraryInfo)
        {
            int i = 0;            
            _dBAccessVM.getItineraryInfo.Add(GetItineraryInfo);
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

    }
}