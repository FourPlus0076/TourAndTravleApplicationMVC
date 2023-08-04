using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Net;
using Application.TourAndTravel.Web.Models;

namespace Application.TourAndTravel.Models
{
    public class PackageRepositories
    {

        private readonly DBAccessVM _dbAccessVM;
        public PackageRepositories()
        {
            _dbAccessVM = new DBAccessVM();
        }
        public int PackageTypeByAdminsave(PackageTypeByAdmin packageTypeByAdmin)
        {
            int i = 0;
            packageTypeByAdmin.CreatedDate = DateTime.Now;
            packageTypeByAdmin.ModifiedDate = DateTime.Now;
            packageTypeByAdmin.IsDelete = true;
            _dbAccessVM.PackagesByAdmin.Add(packageTypeByAdmin);          
            if (_dbAccessVM.SaveChanges() > 0)
            {
                i = 1;
                return i;
            }
            else
            {
                return i;
            }
        }
        public int DeletePackageTypeByAdminsave(int? packageTypeID)
        {
            int i = 0;
            var coll = _dbAccessVM.PackagesByAdmin.Where(a => a.PackageTypeID == packageTypeID).FirstOrDefault();
            if (coll != null)
            {
                coll.IsDelete = false;               
                _dbAccessVM.SaveChanges();
                i = 1;
                return i;
            }
            else {
                return i;
            }
        }
        public PackageTypeByAdmin getPackageTypeDataById(int? packageTypeID)
        {
            PackageTypeByAdmin data = new TourAndTravel.PackageTypeByAdmin();
            if (packageTypeID != null)
            {
                data = _dbAccessVM.PackagesByAdmin.Where(a => a.PackageTypeID == packageTypeID).FirstOrDefault();
                return data;
            }
            else
            { return data; }
        }
        public int UpdatePackageTypeDataById(PackageTypeByAdmin model,out string filename)
        {
            int i = 0;
            PackageTypeByAdmin data = null;
            if (model != null)
            {
                data = _dbAccessVM.PackagesByAdmin.Where(a => a.PackageTypeID == model.PackageTypeID).FirstOrDefault();
                data.PackageDescription = model.PackageDescription;              
              
                data.PackageName = model.PackageName;
                data.PlaceName = model.PlaceName;
                data.PackagePrice = model.PackagePrice;

                data.Duretion = model.Duretion;
                data.PackageInclusions = model.PackageInclusions;
                data.PackageInclusions1 = model.PackageInclusions1;
                data.Day1 = model.Day1;
                data.Day2 = model.Day2;
                data.Day3 = model.Day3;
                data.Day4 = model.Day4;
                data.Day5 = model.Day5;
                data.Day6 = model.Day6;
                data.Day7 = model.Day7;
                data.Day8 = model.Day8;
                data.Day9 = model.Day9;
                data.Day10 = model.Day10;
                data.TermAndCondition = model.TermAndCondition;

                data.ModifiedDate = DateTime.Now;
                data.Image = model.Image;
                data.ModifiedBy = "";         
                if (_dbAccessVM.SaveChanges() > 0) {
                    i= 1;
                    filename = data.Image;
                    return i;
                }
                filename = data.Image;
                return i;
            }
            else
            {
                filename = data.Image;
                return i; 
            }
        }
    }
}