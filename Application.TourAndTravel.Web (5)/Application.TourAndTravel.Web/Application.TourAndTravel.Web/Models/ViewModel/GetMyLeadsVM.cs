using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.TourAndTravel.Web.Models
{
    public class GetMyLeadsVM
    {
        public string ClientName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string NoOfAdults { get; set; }
        public string NoOfKids { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureDate { get; set; }
        public string FromCity { get; set; }
        public string Requirements { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Duration { get; set; }
    }
}