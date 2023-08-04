using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TourAndTravel
{
    //[Editable(Name = "TravellerRegistration")]
    public class TravellerRegistration
    {
        [Key]
        public long TravellerID { get; set; }
        [Required(ErrorMessage ="Traveller name is required.")]
        public string TravellerName { get; set; }
        [Required(ErrorMessage ="Traveller Comapny name is required.")]
        public string TravellerCompanyName { get; set; }
        [Required(ErrorMessage ="Address is required.")]
        public string TravellerAddress { get; set; }
        [Required(ErrorMessage ="Email is required.")]
        public string TravellerEmail { get; set; }
        [Required(ErrorMessage ="Mobile No is required.")]
        public string TravellerMobileNo { get; set; }
        [Required(ErrorMessage ="Password is required.")]
        public string TravellerPassword { get; set; }

        public string TravellerGSTIN_No { get; set; }

        public string TravellerPAN_No { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
        public bool IsVerify { get; set; }

    }

}
