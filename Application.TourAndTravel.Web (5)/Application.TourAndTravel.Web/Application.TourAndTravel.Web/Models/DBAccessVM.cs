using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Application.TourAndTravel.Web.Models
{
    public class DBAccessVM : DbContext
    {
        public DBAccessVM() : base("TourAndTravel")
        {
            //invalid object name 'dbo.ordermasters' in entity framework code first approach
            Database.SetInitializer<DBAccessVM>(null);
        }
        public DbSet<AdminLogin> adminLogin { get; set; }
        public DbSet<BookingInfo> bookingInfo { get; set; }
        public DbSet<GetItinerary> getItineraryInfo { get; set; }
        public DbSet<BookingTermsConditions> bookingTerm { get; set; }
        public DbSet<IsLeadGenerated> isLeadGenerated { get; set; }
        public DbSet<Packages> Package { get; set; }
        public DbSet<PackageTypeByAdmin> PackagesByAdmin { get; set; }
        
        public DbSet<RechargeInfo> Recharge { get; set; }
        public DbSet<TravellerRegistration> travellerRegistration { get; set; }
        public DbSet<WalletCRDRHistory> walletCRDRHistories { get; set; }

        //invalid object name 'dbo.ordermasters' in entity framework code first approach
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TravellerRegistrationMap());
            modelBuilder.Configurations.Add(new BookingInfoMap());
            modelBuilder.Configurations.Add(new GetItineraryInfoMap());
            modelBuilder.Configurations.Add(new IsLeadBuyMap());
            modelBuilder.Configurations.Add(new PackageTypeByAdminMap());
            modelBuilder.Configurations.Add(new RechargeInfoMap());
            modelBuilder.Configurations.Add(new AdminLoginMap());
            modelBuilder.Configurations.Add(new WalletCRDRHistoryMap());
        }
        public class TravellerRegistrationMap : EntityTypeConfiguration<TravellerRegistration>
        {
            public TravellerRegistrationMap()
            {

                this.ToTable("TravellerRegistration");

            }
        }
        public class BookingInfoMap : EntityTypeConfiguration<BookingInfo>
        {
            public BookingInfoMap()
            {

                this.ToTable("BookingInfo");

            }
        }

        public class GetItineraryInfoMap : EntityTypeConfiguration<GetItinerary>
        {
            public GetItineraryInfoMap()
            {
                this.ToTable("GetItinerary");
            }
        }

        public class IsLeadBuyMap : EntityTypeConfiguration<IsLeadGenerated>
        {
            public IsLeadBuyMap()
            {

                this.ToTable("IsLeadGenerated");

            }
        }
        public class PackageTypeByAdminMap : EntityTypeConfiguration<PackageTypeByAdmin>
        {

            public PackageTypeByAdminMap()
            {
                this.ToTable("PackageTypeByAdmin");
            }
        }
        public class RechargeInfoMap : EntityTypeConfiguration<RechargeInfo>
        {
            public RechargeInfoMap()
            {
                this.ToTable("RechargeInfo");
            }
        }
        public class AdminLoginMap : EntityTypeConfiguration<AdminLogin>
        {
            public AdminLoginMap()
            {
                this.ToTable("AdminLogin");
            }
        }
        public class WalletCRDRHistoryMap : EntityTypeConfiguration<WalletCRDRHistory>
        {
            public WalletCRDRHistoryMap()
            {
                this.ToTable("WalletCRDRHistory");
            }
        }
    }
}