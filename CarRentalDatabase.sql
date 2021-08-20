USE [master]
GO
/****** Object:  Database [RentACar]    Script Date: 19.08.2021 19:31:25 ******/
CREATE DATABASE [RentACar]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RentACar', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\RentACar.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RentACar_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\RentACar_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [RentACar] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RentACar].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RentACar] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RentACar] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RentACar] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RentACar] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RentACar] SET ARITHABORT OFF 
GO
ALTER DATABASE [RentACar] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RentACar] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RentACar] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RentACar] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RentACar] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RentACar] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RentACar] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RentACar] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RentACar] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RentACar] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RentACar] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RentACar] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RentACar] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RentACar] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RentACar] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RentACar] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RentACar] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RentACar] SET RECOVERY FULL 
GO
ALTER DATABASE [RentACar] SET  MULTI_USER 
GO
ALTER DATABASE [RentACar] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RentACar] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RentACar] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RentACar] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RentACar] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RentACar] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'RentACar', N'ON'
GO
ALTER DATABASE [RentACar] SET QUERY_STORE = OFF
GO
USE [RentACar]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 19.08.2021 19:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[BrandId] [int] IDENTITY(1,1) NOT NULL,
	[BrandName] [varchar](50) NULL,
 CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED 
(
	[BrandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cards]    Script Date: 19.08.2021 19:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cards](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cardNumber] [nvarchar](20) NULL,
	[cardOnName] [nvarchar](50) NULL,
	[cardValidDate] [nvarchar](10) NULL,
	[cardCvv] [nvarchar](10) NULL,
	[customerId] [int] NULL,
	[cardType] [nvarchar](20) NULL,
 CONSTRAINT [PK_Cards] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarImages]    Script Date: 19.08.2021 19:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NULL,
	[ImagePath] [nvarchar](max) NULL,
	[Date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 19.08.2021 19:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrandId] [int] NULL,
	[ColorId] [int] NULL,
	[ModelYear] [int] NULL,
	[DailyPrice] [decimal](18, 0) NULL,
	[Description] [varchar](max) NULL,
	[CarName] [varchar](50) NULL,
	[CarFindexPoint] [int] NULL,
 CONSTRAINT [PK_Car] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Colors]    Script Date: 19.08.2021 19:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colors](
	[ColorId] [int] IDENTITY(1,1) NOT NULL,
	[ColorName] [varchar](50) NULL,
	[ColorCode] [varchar](50) NULL,
 CONSTRAINT [PK_Colors] PRIMARY KEY CLUSTERED 
(
	[ColorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 19.08.2021 19:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CompanyName] [varchar](50) NULL,
	[CustomerFindexPoint] [int] NULL,
 CONSTRAINT [PK_Customers_1] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperationClaims]    Script Date: 19.08.2021 19:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rentals]    Script Date: 19.08.2021 19:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rentals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NULL,
	[CustomerId] [int] NULL,
	[RentDate] [date] NULL,
	[ReturnDate] [date] NULL,
 CONSTRAINT [PK_Rentals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserOperationClaims]    Script Date: 19.08.2021 19:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserOperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[OperationClaimId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserProfilePictures]    Script Date: 19.08.2021 19:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfilePictures](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[PicturePath] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserProfilePictures] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 19.08.2021 19:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[PasswordHash] [varbinary](500) NULL,
	[PasswordSalt] [varbinary](500) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Brands] ON 

INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (1, N'Audi')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2, N'Wolksvagen')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (3, N'Renault')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (4, N'Kia')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (5, N'Ford')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (7, N'Tesla')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (8, N'Seat')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (9, N'Honda')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (10, N'Fiat')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (11, N'Mercedes Benz')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (12, N'Porsche')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (1012, N'Togg')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (1013, N'Tofas')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (1014, N'Yeni')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (1015, N'asdasdfkasf')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (1016, N'asdasdfkasf')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (1017, N'YeniMarka')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2012, N'audi2')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2013, N'Audi2')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2014, N'Audi2')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2015, N'Audi2')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2016, N'Audi2')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2017, N'Audi2')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2018, N'Try')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2019, N'Try')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2020, N'Try')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2021, N'Try')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2022, N'Try')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2023, N'Try')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2024, N'Try')
SET IDENTITY_INSERT [dbo].[Brands] OFF
GO
SET IDENTITY_INSERT [dbo].[Cards] ON 

INSERT [dbo].[Cards] ([id], [cardNumber], [cardOnName], [cardValidDate], [cardCvv], [customerId], [cardType]) VALUES (11, N'2222222222222222', N'Deneme Deneme', N'22-2029', N'123', 2, N'Visa')
INSERT [dbo].[Cards] ([id], [cardNumber], [cardOnName], [cardValidDate], [cardCvv], [customerId], [cardType]) VALUES (1010, N'1234123412341234', N'Deneme Deneme', N'22-2029', N'126', 2, N'Visa')
INSERT [dbo].[Cards] ([id], [cardNumber], [cardOnName], [cardValidDate], [cardCvv], [customerId], [cardType]) VALUES (1011, N'1237852114569874', N'Deneme2 Deneme2', N'23-2030', N'321', 2, N'Master Card')
INSERT [dbo].[Cards] ([id], [cardNumber], [cardOnName], [cardValidDate], [cardCvv], [customerId], [cardType]) VALUES (1012, N'1111 1111 1111 1111', N'Deneme Deneme', N'22-2029', N'123', 2, N'Visa')
INSERT [dbo].[Cards] ([id], [cardNumber], [cardOnName], [cardValidDate], [cardCvv], [customerId], [cardType]) VALUES (1013, N'1326 5478 9156 9871', N'Deneme Deneme', N'22-2029', N'123', 2, N'Master Card')
INSERT [dbo].[Cards] ([id], [cardNumber], [cardOnName], [cardValidDate], [cardCvv], [customerId], [cardType]) VALUES (1014, N'1111 3333 1111 2222', N'Deneme Deneme', N'22-2029', N'123', 2, N'Visa')
INSERT [dbo].[Cards] ([id], [cardNumber], [cardOnName], [cardValidDate], [cardCvv], [customerId], [cardType]) VALUES (1015, N'2222 2222 2222 3333', N'Deneme Deneme', N'22-2029', N'123', 2, N'Master Card')
INSERT [dbo].[Cards] ([id], [cardNumber], [cardOnName], [cardValidDate], [cardCvv], [customerId], [cardType]) VALUES (2011, N'1234 5678 9908 4225', N'String string', N'12/2029', N'123', 1004, N'Visa')
SET IDENTITY_INSERT [dbo].[Cards] OFF
GO
SET IDENTITY_INSERT [dbo].[CarImages] ON 

INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (1, 1, N'Uploads/Images/CarImages/defaultImage.png', CAST(N'2021-03-02T00:00:00.000' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (2, 2, N'Uploads/Images/CarImages/defaultImage.png', CAST(N'2021-03-02T00:00:00.000' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (3, 2, N'Uploads/Images/CarImages/defaultImage.png', CAST(N'2021-03-02T00:00:00.000' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (4, 3, N'Uploads/Images/CarImages/defaultImage.png', CAST(N'2021-03-02T00:00:00.000' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (5, 4, N'Uploads/Images/CarImages/audiA8Kirmizi.jpg', CAST(N'2021-03-02T21:43:31.000' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (6, 4, N'Uploads/Images/CarImages/defaultImage.png', CAST(N'2021-03-02T21:47:29.000' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (7, 5, N'Uploads/Images/CarImages/passatBeyaz.jpg', CAST(N'2021-03-02T22:17:35.000' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (8, 10, N'Uploads/Images/CarImages/defaultImage.png', CAST(N'2021-03-02T22:05:20.000' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (9, 10, N'Uploads/Images/CarImages/defaultImage.png', CAST(N'2021-03-02T22:07:33.000' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (10, 11, N'Uploads/Images/CarImages/jettaYesil.jpg', CAST(N'2021-03-02T22:09:22.000' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (11, 11, N'Uploads/Images/CarImages/defaultImage.png', CAST(N'2021-03-02T22:09:56.000' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (13, 6, N'Uploads/Images/CarImages/clioSiyah.png', CAST(N'2021-03-02T22:18:42.000' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (14, 6, N'Uploads/Images/CarImages/defaultImage.png', CAST(N'2021-03-02T22:28:12.000' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (15, 8, N'Uploads/Images/CarImages/kiaGri.jpg', CAST(N'2021-03-02T22:50:06.000' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (16, 8, N'Uploads/Images/CarImages/defaultImage.png', CAST(N'2021-03-17T00:41:56.570' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (17, 4, N'Uploads/Images/CarImages/defaultImage.png', CAST(N'2021-03-18T18:49:45.057' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (18, 12, N'Uploads/Images/CarImages/egeaKirmizi.jpg', CAST(N'2021-03-18T18:50:34.840' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (19, 14, N'Uploads/Images/CarImages/egeaBeyaz.jpg', CAST(N'2021-03-18T18:51:23.253' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (20, 15, N'Uploads/Images/CarImages/mustangSiyah.jpg', CAST(N'2021-03-18T18:51:23.253' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (21, 16, N'Uploads/Images/CarImages/audiA5.png', CAST(N'2021-03-18T18:51:23.253' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (22, 17, N'Uploads/Images/CarImages/audiA3Kirmizi.jpg', CAST(N'2021-03-18T18:51:23.253' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (23, 18, N'Uploads/Images/CarImages/defaultImage.png', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (24, 18, N'Uploads/Images/CarImages/defaultImage.png', CAST(N'2021-04-06T22:03:45.740' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (25, 19, N'Uploads/Images/CarImages/defaultImage.png', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (1024, 21, N'Uploads/Images/CarImages/audiA3Kirmizi.jpg', CAST(N'2021-05-15T18:59:47.217' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (1025, 21, N'Uploads/Images/CarImages/audiA3Kirmizi.jpg', CAST(N'2021-05-15T19:46:49.393' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (1026, 21, N'Uploads/Images/CarImages/audiA3Kirmizi.jpg', CAST(N'2021-05-15T20:06:46.557' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (1028, 21, N'Uploads\Images\CarImages\211742387cc402a66-1cc9-40c7-897c-69e65333d430.png', CAST(N'2021-05-15T21:17:39.223' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (1029, 15, N'Uploads\Images\CarImages\21215139363648e21-c7c4-4405-b0db-0edb56f88f2e.png', CAST(N'2021-05-15T21:21:51.393' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (1030, 15, N'Uploads\Images\CarImages\\213716350f524bfea-12e3-4539-b626-7b4067911084.png', CAST(N'2021-05-15T21:37:16.350' AS DateTime))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (1031, 15, N'Uploads\Images\CarImages\214937455baa6b299-398a-4a66-a120-68e7fdcd3947.png', CAST(N'2021-05-15T21:49:37.453' AS DateTime))
SET IDENTITY_INSERT [dbo].[CarImages] OFF
GO
SET IDENTITY_INSERT [dbo].[Cars] ON 

INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description], [CarName], [CarFindexPoint]) VALUES (4, 1, 1, 2021, CAST(500 AS Decimal(18, 0)), N'Sedan', N'A8', 100)
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description], [CarName], [CarFindexPoint]) VALUES (5, 2, 2, 2019, CAST(120 AS Decimal(18, 0)), N'Sedan', N'Passat', 20)
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description], [CarName], [CarFindexPoint]) VALUES (6, 3, 3, 2021, CAST(300 AS Decimal(18, 0)), N'Hatchback', N'Clio', 100)
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description], [CarName], [CarFindexPoint]) VALUES (7, 4, 4, 2019, CAST(115 AS Decimal(18, 0)), N'Suv', N'Sportage', 40)
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description], [CarName], [CarFindexPoint]) VALUES (8, 4, 5, 2019, CAST(205 AS Decimal(18, 0)), N'Suv', N'Sportage', 50)
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description], [CarName], [CarFindexPoint]) VALUES (11, 2, 6, 2019, CAST(300 AS Decimal(18, 0)), N'Sedan', N'Jetta', 60)
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description], [CarName], [CarFindexPoint]) VALUES (12, 10, 1, 2021, CAST(300 AS Decimal(18, 0)), N'Sedan', N'Egea', 70)
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description], [CarName], [CarFindexPoint]) VALUES (14, 10, 2, 2019, CAST(120 AS Decimal(18, 0)), N'Sedan Araç', N'Egea', 80)
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description], [CarName], [CarFindexPoint]) VALUES (15, 5, 3, 2020, CAST(450 AS Decimal(18, 0)), N'Spor-Sedan', N'Mustang', 90)
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description], [CarName], [CarFindexPoint]) VALUES (16, 8, 8, 2021, CAST(200 AS Decimal(18, 0)), N'Spor-Sedan', N'A5', 100)
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description], [CarName], [CarFindexPoint]) VALUES (17, 1, 1, 1, CAST(200 AS Decimal(18, 0)), N'Sedan', N'A3', 110)
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description], [CarName], [CarFindexPoint]) VALUES (18, 1, 2, 2021, CAST(100 AS Decimal(18, 0)), N'Sedan', N'A7', 100)
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description], [CarName], [CarFindexPoint]) VALUES (19, 1, 1, 2012, CAST(100 AS Decimal(18, 0)), N'Sedan', N'a1', 200)
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description], [CarName], [CarFindexPoint]) VALUES (20, 2, 2, 2021, CAST(100 AS Decimal(18, 0)), N'Sedan', N'saa', 100)
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description], [CarName], [CarFindexPoint]) VALUES (21, 1, 1, 2021, CAST(100 AS Decimal(18, 0)), N'AAa', N'AA', 100)
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description], [CarName], [CarFindexPoint]) VALUES (1062, 11, 3, 2020, CAST(1000 AS Decimal(18, 0)), N'Sedan', N'C 180', 100)
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description], [CarName], [CarFindexPoint]) VALUES (2062, 1, 5, 2019, CAST(2019 AS Decimal(18, 0)), N'Sedan', N'A', 2019)
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description], [CarName], [CarFindexPoint]) VALUES (2063, 1, 3, 2012, CAST(201 AS Decimal(18, 0)), N'b', N'A', 80)
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description], [CarName], [CarFindexPoint]) VALUES (2064, 9, 11, 2021, CAST(300 AS Decimal(18, 0)), N'Sedan', N'Civic', 190)
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description], [CarName], [CarFindexPoint]) VALUES (2065, 9, 11, 2022, CAST(2022 AS Decimal(18, 0)), N'Sedan', N'Test', 2022)
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description], [CarName], [CarFindexPoint]) VALUES (2066, 5, 1, 2019, CAST(100 AS Decimal(18, 0)), N'Sedan', N'test', 200)
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description], [CarName], [CarFindexPoint]) VALUES (2067, 8, 1, 2021, CAST(100 AS Decimal(18, 0)), N'Sedan', N'ABC', 100)
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description], [CarName], [CarFindexPoint]) VALUES (2068, 7, 10, 200, CAST(100 AS Decimal(18, 0)), N'Test', N'Tesla', 100)
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description], [CarName], [CarFindexPoint]) VALUES (2069, 4, 1, 2021, CAST(100 AS Decimal(18, 0)), N'Sedan', N'ZZZ', 100)
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description], [CarName], [CarFindexPoint]) VALUES (2070, 5, 1, 2021, CAST(200 AS Decimal(18, 0)), N'Sedan', N'ZZZZ', 200)
SET IDENTITY_INSERT [dbo].[Cars] OFF
GO
SET IDENTITY_INSERT [dbo].[Colors] ON 

INSERT [dbo].[Colors] ([ColorId], [ColorName], [ColorCode]) VALUES (1, N'Kırmızı', N'asdasd')
INSERT [dbo].[Colors] ([ColorId], [ColorName], [ColorCode]) VALUES (2, N'Beyaz', N'#FFFFFF')
INSERT [dbo].[Colors] ([ColorId], [ColorName], [ColorCode]) VALUES (3, N'Siyah', N'#000000')
INSERT [dbo].[Colors] ([ColorId], [ColorName], [ColorCode]) VALUES (5, N'Gri', N'#808080')
INSERT [dbo].[Colors] ([ColorId], [ColorName], [ColorCode]) VALUES (6, N'Yeşil', N'#008000')
INSERT [dbo].[Colors] ([ColorId], [ColorName], [ColorCode]) VALUES (10, N'Mavi', N'#0000ff')
INSERT [dbo].[Colors] ([ColorId], [ColorName], [ColorCode]) VALUES (11, N'Turuncu', N'#FF7F00')
INSERT [dbo].[Colors] ([ColorId], [ColorName], [ColorCode]) VALUES (12, N'Deneme', N'#gftpue')
INSERT [dbo].[Colors] ([ColorId], [ColorName], [ColorCode]) VALUES (13, N'Lila', N'c8a2c8')
INSERT [dbo].[Colors] ([ColorId], [ColorName], [ColorCode]) VALUES (14, N'Turkuaz', N'30d5c8')
INSERT [dbo].[Colors] ([ColorId], [ColorName], [ColorCode]) VALUES (1028, N'Kahverengi', N'#jthgghe')
SET IDENTITY_INSERT [dbo].[Colors] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([CustomerId], [UserId], [CompanyName], [CustomerFindexPoint]) VALUES (1, 1, N'A', 100)
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[OperationClaims] ON 

INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (1, N'car.list')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (2, N'admin')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (3, N'car.add')
SET IDENTITY_INSERT [dbo].[OperationClaims] OFF
GO
SET IDENTITY_INSERT [dbo].[UserProfilePictures] ON 

INSERT [dbo].[UserProfilePictures] ([Id], [UserId], [PicturePath]) VALUES (1, 1, N'Uploads\Images\CarImages\212920578a445dd79-eb66-492c-9f93-edf1cef491ce.jpg')
SET IDENTITY_INSERT [dbo].[UserProfilePictures] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt], [Status]) VALUES (1, N'Fatih', N'Baycu', N'fatih.baycu@gmail.com', 0x3147147A40DD3A91B849C1ECCA673DB4314F6857A6C2C17986A6F86DDFBA32F4223C1A7B405B610877438F9B225380CE9AB56D5FA59D8FBAFAC47480C0E02B02, 0xB52DD7B75568BB0DEADE71A18CB05501A351DC0CB5AB81298F471E3217D67F8E45180E467B86096B12871C9456C69D64B8D72C9E91C51A17EB5DBD079D0C43CE88FE88A5D5FA50E90D14A6B5BFA4FAC497CD31CEE65D8395A7CF5E6463F388259D27FBF254981967CD0517221F773FDC4A82B39FC2EF33B4229E29721292CDA1, 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Rentals] ADD  CONSTRAINT [DF_Rentals_ReturnDate]  DEFAULT (NULL) FOR [ReturnDate]
GO
USE [master]
GO
ALTER DATABASE [RentACar] SET  READ_WRITE 
GO
