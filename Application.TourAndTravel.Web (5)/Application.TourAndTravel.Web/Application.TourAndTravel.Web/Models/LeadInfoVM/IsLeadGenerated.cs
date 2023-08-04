using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TourAndTravel
{
    public class IsLeadGenerated
    {
        [Key]
        public long IsLeadGeneratedID { get; set; }
        public long LeadID { get; set; }

        public string TravellerUserName { get; set; }

        public int SoldLeadCount { get; set; }

        public DateTime SellDate { get; set; }

    }

}
