using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TourAndTravel
{
    public class BookingInfo
    {
        [Key]
        public long BookingInfoID { get; set; }
        //[Required(ErrorMessage ="Name is required.")]
        public string ClientName { get; set; }
        //[Required(ErrorMessage ="Mobile No is required.")]
        public string MobileNo { get; set; }
        //[Required(ErrorMessage ="Email is required.")]
        public string Email { get; set; }
        //[Required(ErrorMessage ="No of Adults is required.")]
        public string NoOfPax { get; set; }
        //[Required(ErrorMessage ="No of Kids is required.")]
        
        public string message { get; set; }      
        
        public DateTime CreatedDate { get; set; }
        //[Required(ErrorMessage ="Duration is required.")]
        public string Duration { get; set; }

    }
}
