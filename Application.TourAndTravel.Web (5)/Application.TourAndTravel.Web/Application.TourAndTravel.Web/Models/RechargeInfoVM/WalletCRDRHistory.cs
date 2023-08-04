using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Application.TourAndTravel.Web.Models
{
    public class WalletCRDRHistory
    {
        [Key]
        public long CreditDebitID { get; set; }
        public string TravellerEmail { get; set; }
        public decimal Credit { get; set; }
        public decimal Debit { get; set; }
        public DateTime CreditDebitDate { get; set; }
    }
}