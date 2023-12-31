USE [master]
GO
/****** Object:  Database [TourAndTravel]    Script Date: 6/24/2022 12:53:21 AM ******/
CREATE DATABASE [TourAndTravel]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TourAndTravel', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TourAndTravel.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TourAndTravel_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TourAndTravel_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TourAndTravel] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TourAndTravel].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TourAndTravel] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TourAndTravel] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TourAndTravel] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TourAndTravel] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TourAndTravel] SET ARITHABORT OFF 
GO
ALTER DATABASE [TourAndTravel] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TourAndTravel] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TourAndTravel] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TourAndTravel] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TourAndTravel] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TourAndTravel] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TourAndTravel] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TourAndTravel] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TourAndTravel] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TourAndTravel] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TourAndTravel] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TourAndTravel] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TourAndTravel] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TourAndTravel] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TourAndTravel] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TourAndTravel] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TourAndTravel] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TourAndTravel] SET RECOVERY FULL 
GO
ALTER DATABASE [TourAndTravel] SET  MULTI_USER 
GO
ALTER DATABASE [TourAndTravel] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TourAndTravel] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TourAndTravel] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TourAndTravel] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TourAndTravel] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TourAndTravel', N'ON'
GO
ALTER DATABASE [TourAndTravel] SET QUERY_STORE = OFF
GO
USE [TourAndTravel]
GO
/****** Object:  Table [dbo].[AdminLogin]    Script Date: 6/24/2022 12:53:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminLogin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[UserPassword] [nvarchar](50) NULL,
 CONSTRAINT [PK_AdminLogin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookingInfo]    Script Date: 6/24/2022 12:53:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingInfo](
	[BookingInfoID] [bigint] IDENTITY(1,1) NOT NULL,
	[ClientName] [nvarchar](50) NULL,
	[MobileNo] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[NoOfPax] [nvarchar](50) NULL,
	[message] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[Duration] [nvarchar](50) NULL,
 CONSTRAINT [PK_BookingInfo_1] PRIMARY KEY CLUSTERED 
(
	[BookingInfoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookingTermsConditions]    Script Date: 6/24/2022 12:53:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingTermsConditions](
	[BookingTermsConditionsID] [bigint] IDENTITY(1,1) NOT NULL,
	[ConditionFirstBookingAmountRequired] [bit] NULL,
	[ConditionSecondRefundCancelledOne] [bit] NULL,
	[ConditionSecondRefundCancelledTwo] [bit] NULL,
	[ConditionSecondRefundCancelledThree] [bit] NULL,
	[IsDelete] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[ModifiedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_BookingTermsConditions_1] PRIMARY KEY CLUSTERED 
(
	[BookingTermsConditionsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GetItinerary]    Script Date: 6/24/2022 12:53:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GetItinerary](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_GetItinerary] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IsLeadGenerated]    Script Date: 6/24/2022 12:53:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IsLeadGenerated](
	[IsLeadGeneratedID] [bigint] IDENTITY(1,1) NOT NULL,
	[LeadID] [bigint] NULL,
	[TravellerUserName] [nvarchar](50) NULL,
	[SoldLeadCount] [int] NULL,
	[SellDate] [datetime] NULL,
 CONSTRAINT [PK_IsLeadGeneratedID] PRIMARY KEY CLUSTERED 
(
	[IsLeadGeneratedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 6/24/2022 12:53:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Packages]    Script Date: 6/24/2022 12:53:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Packages](
	[PackageID] [bigint] IDENTITY(1,1) NOT NULL,
	[TourType] [nvarchar](50) NULL,
	[Duration] [nvarchar](50) NULL,
	[MealPlan] [nvarchar](50) NULL,
	[PackageTitle] [nvarchar](50) NULL,
	[TotalPrice] [numeric](18, 0) NULL,
	[TourPic] [nvarchar](50) NULL,
	[DayOneArrivalCityName] [nvarchar](50) NULL,
	[DayOneHotelName] [nvarchar](50) NULL,
	[DayOneHotelStar] [nvarchar](50) NULL,
	[DayOnePickupIncluded] [bit] NULL,
	[DayOneWelcomeDrink] [bit] NULL,
	[DayOnePackageTitle] [nvarchar](50) NULL,
	[DayOneAddMore] [nvarchar](50) NULL,
	[DayTwoArrivalCityName] [nvarchar](50) NULL,
	[DayTwoHotelName] [nvarchar](50) NULL,
	[DayTwoHotelStar] [nvarchar](50) NULL,
	[DayTwoPackageTitle] [nvarchar](50) NULL,
	[DayTwoAddMore] [nvarchar](50) NULL,
	[DayThreeArrivalCityName] [nvarchar](50) NULL,
	[DayThreeHotelName] [nvarchar](50) NULL,
	[DayThreeHotelStar] [nvarchar](50) NULL,
	[DayThreePackageTitle] [nvarchar](50) NULL,
	[DayThreeAddMore] [nvarchar](50) NULL,
	[DayFourArrivalCityName] [nvarchar](50) NULL,
	[DayFourHotelName] [nvarchar](50) NULL,
	[DayFourHotelStar] [nvarchar](50) NULL,
	[DayFourPackageTitle] [nvarchar](50) NULL,
	[DayFourAddMore] [nvarchar](50) NULL,
	[DayFiveArrivalCityName] [nvarchar](50) NULL,
	[DayFiveHotelName] [nvarchar](50) NULL,
	[DayFiveHotelStar] [nvarchar](50) NULL,
	[DayFivePackageTitle] [nvarchar](50) NULL,
	[DayFiveAddMore] [nvarchar](50) NULL,
	[DaySixArrivalCityName] [nvarchar](50) NULL,
	[DaySixHotelName] [nvarchar](50) NULL,
	[DaySixHotelStar] [nvarchar](50) NULL,
	[DaySixPackageTitle] [nvarchar](50) NULL,
	[DaySixAddMore] [nvarchar](50) NULL,
	[DaySevenArrivalCityName] [nvarchar](50) NULL,
	[DaySevenHotelName] [nvarchar](50) NULL,
	[DaySevenHotelStar] [nvarchar](50) NULL,
	[DaySevenPackageTitle] [nvarchar](50) NULL,
	[DaySevenAddMore] [nvarchar](50) NULL,
	[DayEightArrivalCityName] [nvarchar](50) NULL,
	[DayEightHotelName] [nvarchar](50) NULL,
	[DayEightHotelStar] [nvarchar](50) NULL,
	[DayEightPackageTitle] [nvarchar](50) NULL,
	[DayEightAddMore] [nvarchar](50) NULL,
	[DayNineArrivalCityName] [nvarchar](50) NULL,
	[DayNineHotelName] [nvarchar](50) NULL,
	[DayNineHotelStar] [nvarchar](50) NULL,
	[DayNinePackageTitle] [nvarchar](50) NULL,
	[DayNineAddMore] [nvarchar](50) NULL,
	[DayTenArrivalCityName] [nvarchar](50) NULL,
	[DayTenHotelName] [nvarchar](50) NULL,
	[DayTenHotelStar] [nvarchar](50) NULL,
	[DayTenPackageTitle] [nvarchar](50) NULL,
	[DayTenAddMore] [nvarchar](50) NULL,
	[IsDelete] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ConditionFirstBookingAmountRequired] [bit] NULL,
	[ConditionSecondRefundCancelledOne] [bit] NULL,
	[ConditionSecondRefundCancelledTwo] [bit] NULL,
	[ConditionSecondRefundCancelledThree] [bit] NULL,
	[NoOfDayNight] [nvarchar](50) NULL,
	[PercentAmount] [numeric](18, 0) NULL,
	[NoOfDayNight1] [nvarchar](50) NULL,
	[PercentAmount1] [numeric](18, 0) NULL,
	[NoOfDayNight2] [nvarchar](50) NULL,
	[PercentAmount2] [numeric](18, 0) NULL,
	[PercentAmount3] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Packages] PRIMARY KEY CLUSTERED 
(
	[PackageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PackageTypeByAdmin]    Script Date: 6/24/2022 12:53:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PackageTypeByAdmin](
	[PackageTypeID] [bigint] IDENTITY(1,1) NOT NULL,
	[PackageName] [nvarchar](50) NULL,
	[PlaceName] [nvarchar](50) NULL,
	[PackagePrice] [numeric](12, 2) NULL,
	[PackageDescription] [nvarchar](max) NULL,
	[Duretion] [nvarchar](50) NULL,
	[PackageInclusions] [nvarchar](max) NULL,
	[PackageInclusions1] [nvarchar](max) NULL,
	[Day1] [nvarchar](max) NULL,
	[Day2] [nvarchar](max) NULL,
	[Day3] [nvarchar](max) NULL,
	[Day4] [nvarchar](max) NULL,
	[Day5] [nvarchar](max) NULL,
	[Day6] [nvarchar](max) NULL,
	[Day7] [nvarchar](max) NULL,
	[Day8] [nvarchar](max) NULL,
	[Day9] [nvarchar](max) NULL,
	[Day10] [nvarchar](max) NULL,
	[Image] [nvarchar](50) NULL,
	[IsDelete] [bit] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[TermAndCondition] [nvarchar](max) NULL,
 CONSTRAINT [PK_PackageTypeByAdmin] PRIMARY KEY CLUSTERED 
(
	[PackageTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RechargeInfo]    Script Date: 6/24/2022 12:53:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RechargeInfo](
	[RechargeInfo] [bigint] IDENTITY(1,1) NOT NULL,
	[TravellerID] [bigint] NULL,
	[TravelAgentName] [nvarchar](50) NULL,
	[TravelAgentEmail] [nvarchar](50) NULL,
	[WalletBalance] [numeric](18, 0) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_RechargeInfo] PRIMARY KEY CLUSTERED 
(
	[RechargeInfo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TravellerRegistration]    Script Date: 6/24/2022 12:53:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TravellerRegistration](
	[TravellerID] [bigint] IDENTITY(1,1) NOT NULL,
	[TravellerName] [nvarchar](50) NULL,
	[TravellerCompanyName] [nvarchar](50) NULL,
	[TravellerAddress] [nvarchar](50) NULL,
	[TravellerEmail] [nvarchar](50) NULL,
	[TravellerMobileNo] [nvarchar](50) NULL,
	[TravellerPassword] [nvarchar](50) NULL,
	[TravellerGSTIN_No] [nvarchar](50) NULL,
	[TravellerPAN_No] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsVerify] [bit] NULL,
 CONSTRAINT [PK_TravellerRegistration] PRIMARY KEY CLUSTERED 
(
	[TravellerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WalletCRDRHistory]    Script Date: 6/24/2022 12:53:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WalletCRDRHistory](
	[CreditDebitID] [bigint] IDENTITY(1,1) NOT NULL,
	[TravellerEmail] [nvarchar](50) NULL,
	[Credit] [numeric](18, 0) NULL,
	[Debit] [numeric](18, 0) NULL,
	[CreditDebitDate] [datetime] NULL,
 CONSTRAINT [PK_WalletCRDRHistory] PRIMARY KEY CLUSTERED 
(
	[CreditDebitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AdminLogin] ON 

INSERT [dbo].[AdminLogin] ([ID], [UserName], [UserPassword]) VALUES (1, N'gaus99@gmail.com', N'Feb@2022')
SET IDENTITY_INSERT [dbo].[AdminLogin] OFF
SET IDENTITY_INSERT [dbo].[BookingInfo] ON 

INSERT [dbo].[BookingInfo] ([BookingInfoID], [ClientName], [MobileNo], [Email], [NoOfPax], [message], [CreatedDate], [Duration]) VALUES (1, N'gauss', N'98975566879', N'gaus99@gmail.com', N'6', N'hgh', CAST(N'2022-05-15T18:19:33.660' AS DateTime), N'4d/6n')
INSERT [dbo].[BookingInfo] ([BookingInfoID], [ClientName], [MobileNo], [Email], [NoOfPax], [message], [CreatedDate], [Duration]) VALUES (2, N'gaus mohd', N'9897556687', N'gauss@chetu.com', N'3', N'hdfadasvcsdhbc', CAST(N'2022-05-17T11:15:01.807' AS DateTime), N'4d/6n')
INSERT [dbo].[BookingInfo] ([BookingInfoID], [ClientName], [MobileNo], [Email], [NoOfPax], [message], [CreatedDate], [Duration]) VALUES (3, N'abhisekh', N'98975566879', N'abhi@chetu.com', N'3', N'sdfsdg', CAST(N'2022-05-18T10:54:52.277' AS DateTime), N'4d/6n')
INSERT [dbo].[BookingInfo] ([BookingInfoID], [ClientName], [MobileNo], [Email], [NoOfPax], [message], [CreatedDate], [Duration]) VALUES (10003, N'gausse', N'98975566879', N'gaus99@gmail.com', N'3', N'hdfadasvcsdhbc', CAST(N'2022-05-22T21:13:51.900' AS DateTime), N'4d/6n')
INSERT [dbo].[BookingInfo] ([BookingInfoID], [ClientName], [MobileNo], [Email], [NoOfPax], [message], [CreatedDate], [Duration]) VALUES (20003, N'gaus mohd', N'98975566879', N'gauss@chetu.com', N'3', N'sdfsdg', CAST(N'2022-05-27T11:36:41.593' AS DateTime), N'4d/6n')
SET IDENTITY_INSERT [dbo].[BookingInfo] OFF
SET IDENTITY_INSERT [dbo].[GetItinerary] ON 

INSERT [dbo].[GetItinerary] ([Id], [Name], [Phone], [Email], [IsDelete]) VALUES (1, N'gaus S', N'9790765898', N'gaus@chetu.com', 0)
SET IDENTITY_INSERT [dbo].[GetItinerary] OFF
SET IDENTITY_INSERT [dbo].[Login] ON 

INSERT [dbo].[Login] ([Id], [Email], [Password]) VALUES (1, N'gaus99@gmail.com', N'Feb@2022')
SET IDENTITY_INSERT [dbo].[Login] OFF
SET IDENTITY_INSERT [dbo].[PackageTypeByAdmin] ON 

INSERT [dbo].[PackageTypeByAdmin] ([PackageTypeID], [PackageName], [PlaceName], [PackagePrice], [PackageDescription], [Duretion], [PackageInclusions], [PackageInclusions1], [Day1], [Day2], [Day3], [Day4], [Day5], [Day6], [Day7], [Day8], [Day9], [Day10], [Image], [IsDelete], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [TermAndCondition]) VALUES (1, N'5', N'dehradun', CAST(4.00 AS Numeric(12, 2)), N'6d7n', N'4 Days / 5 Night', N'Welcome drink on arrival.', N'Parking and Toll tax.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'812722192022.jpg', 0, N'gaus99@gmail.com', CAST(N'2022-05-20T15:12:05.730' AS DateTime), N'', CAST(N'2022-05-22T00:20:19.933' AS DateTime), NULL)
INSERT [dbo].[PackageTypeByAdmin] ([PackageTypeID], [PackageName], [PlaceName], [PackagePrice], [PackageDescription], [Duretion], [PackageInclusions], [PackageInclusions1], [Day1], [Day2], [Day3], [Day4], [Day5], [Day6], [Day7], [Day8], [Day9], [Day10], [Image], [IsDelete], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [TermAndCondition]) VALUES (2, N'5d', N'nsadas', CAST(68.00 AS Numeric(12, 2)), N'5 Days / 6 Night', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'334721482022.jpg', 1, N'gaus99@gmail.com', CAST(N'2022-05-21T09:48:47.727' AS DateTime), N'', CAST(N'2022-05-21T09:48:47.727' AS DateTime), NULL)
INSERT [dbo].[PackageTypeByAdmin] ([PackageTypeID], [PackageName], [PlaceName], [PackagePrice], [PackageDescription], [Duretion], [PackageInclusions], [PackageInclusions1], [Day1], [Day2], [Day3], [Day4], [Day5], [Day6], [Day7], [Day8], [Day9], [Day10], [Image], [IsDelete], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [TermAndCondition]) VALUES (3, N'5 days Packages', N'himallya', CAST(450.00 AS Numeric(12, 2)), N'dvnkdfgvidfhf', N'4 Days / 5 Night', N'Welcome drink on arrival.', N'Parking and Toll tax.', N'day1', N'day2', N'day3', N'day4', N'day5', N'day6', N'day7', N'day8', N'day9', N'day10', N'977322012022.jpg', 1, N'gaus99@gmail.com', CAST(N'2022-05-22T00:01:46.670' AS DateTime), N'', CAST(N'2022-05-22T00:01:46.670' AS DateTime), NULL)
INSERT [dbo].[PackageTypeByAdmin] ([PackageTypeID], [PackageName], [PlaceName], [PackagePrice], [PackageDescription], [Duretion], [PackageInclusions], [PackageInclusions1], [Day1], [Day2], [Day3], [Day4], [Day5], [Day6], [Day7], [Day8], [Day9], [Day10], [Image], [IsDelete], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [TermAndCondition]) VALUES (4, N'6 days Packages', N'himallya', CAST(450.00 AS Numeric(12, 2)), N'dvnkdfgvidfhf', N'5 Days / 7 Night', N'Welcome drink on arrival.', N'Parking and Toll tax.', N'day1', N'day2', N'day3', N'day4', N'day5', N'day6', N'day7', N'day8', N'day9', N'day10', N'26228242022.jpg', 1, N'gaus99@gmail.com', CAST(N'2022-05-28T23:24:36.487' AS DateTime), N'', CAST(N'2022-05-28T23:24:36.487' AS DateTime), N'jkxdfnvdsv')
SET IDENTITY_INSERT [dbo].[PackageTypeByAdmin] OFF
SET IDENTITY_INSERT [dbo].[TravellerRegistration] ON 

INSERT [dbo].[TravellerRegistration] ([TravellerID], [TravellerName], [TravellerCompanyName], [TravellerAddress], [TravellerEmail], [TravellerMobileNo], [TravellerPassword], [TravellerGSTIN_No], [TravellerPAN_No], [CreatedDate], [ModifiedDate], [IsVerify]) VALUES (1, N'gaus', N'rrrr', N'adresss', N'gaus99@gmail.com', N'98979897978', N'Feb@2022', N'8976', N'986578987655', CAST(N'2022-05-15T00:00:00.000' AS DateTime), CAST(N'2022-05-15T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[TravellerRegistration] OFF
USE [master]
GO
ALTER DATABASE [TourAndTravel] SET  READ_WRITE 
GO
