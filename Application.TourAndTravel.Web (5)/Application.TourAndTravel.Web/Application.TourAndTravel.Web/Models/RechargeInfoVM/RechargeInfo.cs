using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TourAndTravel
{
    public class RechargeInfo
    {
        [Key]
        public long RechargeID { get; set; }

        public long TravellerID { get; set; }

        public string TravelAgentName { get; set; }

        public string TravelAgentEmail { get; set; }

        public decimal? WalletBalance { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public bool IsDelete { get; set; }

    }

}
