using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Application.TourAndTravel.Web.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage="UserName is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password is required.")]
        public string Password { get; set; }
    }
}