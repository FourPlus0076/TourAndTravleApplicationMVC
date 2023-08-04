using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Application.TourAndTravel.Web.Models
{
    public class AdminLogin
    {
        [Key]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}