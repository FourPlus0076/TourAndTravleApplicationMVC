using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TourAndTravel
{
    public class PackageTypeByAdmin
    {
        [Key]
        public long PackageTypeID { get; set; }

        public string PackageName  { get; set; }

        public string PlaceName { get; set; }

        public decimal PackagePrice { get; set; }

        public string PackageDescription { get; set; }

        public string Duretion { get; set; }

        public string PackageInclusions { get; set; }
        public string PackageInclusions1 { get; set; }
        public string Day1 { get; set; }
        public string Day2 { get; set; }
        public string Day3 { get; set; }
        public string Day4 { get; set; }
        public string Day5 { get; set; }
        public string Day6 { get; set; }
        public string Day7 { get; set; }
        public string Day8 { get; set; }
        public string Day9 { get; set; }
        public string Day10 { get; set; }

        public string TermAndCondition { get; set; }

        public string Image { get; set; }
        

        public bool IsDelete { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

    }

}
