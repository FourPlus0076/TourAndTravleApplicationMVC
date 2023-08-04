using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TourAndTravel
{
    public class Packages
    {
        [Key]
        public long PackageID { get; set; }

        public string TourType { get; set; }

        public string Duration { get; set; }

        public string MealPlan { get; set; }

        public string PackageTitle { get; set; }

        public decimal TotalPrice { get; set; }

        public string TourPic { get; set; }

        public string DayOneArrivalCityName { get; set; }

        public string DayOneHotelName { get; set; }

        public string DayOneHotelStar { get; set; }

        public bool DayOnePickupIncluded { get; set; }

        public bool DayOneWelcomeDrink { get; set; }

        public string DayOnePackageTitle { get; set; }

        public string DayOneAddMore { get; set; }

        public string DayTwoArrivalCityName { get; set; }

        public string DayTwoHotelName { get; set; }

        public string DayTwoHotelStar { get; set; }

        public string DayTwoPackageTitle { get; set; }

        public string DayTwoAddMore { get; set; }

        public string DayThreeArrivalCityName { get; set; }

        public string DayThreeHotelName { get; set; }

        public string DayThreeHotelStar { get; set; }

        public string DayThreePackageTitle { get; set; }

        public string DayThreeAddMore { get; set; }

        public string DayFourArrivalCityName { get; set; }

        public string DayFourHotelName { get; set; }

        public string DayFourHotelStar { get; set; }

        public string DayFourPackageTitle { get; set; }

        public string DayFourAddMore { get; set; }

        public string DayFiveArrivalCityName { get; set; }

        public string DayFiveHotelName { get; set; }

        public string DayFiveHotelStar { get; set; }

        public string DayFivePackageTitle { get; set; }

        public string DayFiveAddMore { get; set; }

        public string DaySixArrivalCityName { get; set; }

        public string DaySixHotelName { get; set; }

        public string DaySixHotelStar { get; set; }

        public string DaySixPackageTitle { get; set; }

        public string DaySixAddMore { get; set; }

        public string DaySevenArrivalCityName { get; set; }

        public string DaySevenHotelName { get; set; }

        public string DaySevenHotelStar { get; set; }

        public string DaySevenPackageTitle { get; set; }

        public string DaySevenAddMore { get; set; }

        public string DayEightArrivalCityName { get; set; }

        public string DayEightHotelName { get; set; }

        public string DayEightHotelStar { get; set; }

        public string DayEightPackageTitle { get; set; }

        public string DayEightAddMore { get; set; }

        public string DayNineArrivalCityName { get; set; }

        public string DayNineHotelName { get; set; }

        public string DayNineHotelStar { get; set; }

        public string DayNinePackageTitle { get; set; }

        public string DayNineAddMore { get; set; }

        public string DayTenArrivalCityName { get; set; }

        public string DayTenHotelName { get; set; }

        public string DayTenHotelStar { get; set; }

        public string DayTenPackageTitle { get; set; }

        public string DayTenAddMore { get; set; }

        public bool IsDelete { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public bool ConditionFirstBookingAmountRequired { get; set; }

        public bool ConditionSecondRefundCancelledOne { get; set; }

        public bool ConditionSecondRefundCancelledTwo { get; set; }

        public bool ConditionSecondRefundCancelledThree { get; set; }
        public string NoOfDayNight { get; set; }
        public decimal PercentAmount { get; set; }
        public string NoOfDayNight1 { get; set; }
        public decimal PercentAmount1 { get; set; }
        public string NoOfDayNight2 { get; set; }
        public decimal PercentAmount2 { get; set; }
        public decimal PercentAmount3 { get; set; }
       
    }
}
