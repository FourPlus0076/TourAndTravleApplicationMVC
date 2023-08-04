using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TourAndTravel
{
    public class GetItinerary
    {
        [Key]
        public long Id { get; set; }
        //[Required(ErrorMessage ="Name is required.")]
        public string Name { get; set; }
        //[Required(ErrorMessage ="Mobile No is required.")]
        public string Phone { get; set; }
        //[Required(ErrorMessage ="Email is required.")]
        public string Email { get; set; }

        public bool IsDelete { get; set; }

    }
}
