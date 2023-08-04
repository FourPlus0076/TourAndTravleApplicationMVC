using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TourAndTravel
{
    public class BookingTermsConditions
    {
        [Key]
        public long BookingTermsConditionsID { get; set; }

        public bool ConditionFirstBookingAmountRequired { get; set; }

        public bool ConditionSecondRefundCancelledOne { get; set; }

        public bool ConditionSecondRefundCancelledTwo { get; set; }

        public bool ConditionSecondRefundCancelledThree { get; set; }

        public bool IsDelete { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

    }

}
