USE [master]
GO
/****** Object:  Database [DBSHOP]    Script Date: 11/10/2024 13:07:40 ******/
CREATE DATABASE [DBSHOP]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBSHOP', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVERPC\MSSQL\DATA\DBSHOP.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DBSHOP_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVERPC\MSSQL\DATA\DBSHOP_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DBSHOP] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBSHOP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBSHOP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBSHOP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBSHOP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBSHOP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBSHOP] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBSHOP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBSHOP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBSHOP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBSHOP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBSHOP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBSHOP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBSHOP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBSHOP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBSHOP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBSHOP] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DBSHOP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBSHOP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBSHOP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBSHOP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBSHOP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBSHOP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBSHOP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBSHOP] SET RECOVERY FULL 
GO
ALTER DATABASE [DBSHOP] SET  MULTI_USER 
GO
ALTER DATABASE [DBSHOP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBSHOP] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBSHOP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBSHOP] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DBSHOP] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DBSHOP] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DBSHOP', N'ON'
GO
ALTER DATABASE [DBSHOP] SET QUERY_STORE = ON
GO
ALTER DATABASE [DBSHOP] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [DBSHOP]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 11/10/2024 13:07:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 11/10/2024 13:07:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 11/10/2024 13:07:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 11/10/2024 13:07:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](100) NOT NULL,
	[ProductCode] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[Price] [numeric](18, 2) NOT NULL,
	[Stock] [int] NOT NULL,
	[Image] [nvarchar](500) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 11/10/2024 13:07:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductOrder]    Script Date: 11/10/2024 13:07:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_ProductOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_Date]  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategory_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK_ProductCategory_Category]
GO
ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategory_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK_ProductCategory_Product]
GO
ALTER TABLE [dbo].[ProductOrder]  WITH CHECK ADD  CONSTRAINT [FK_ProductOrder_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[ProductOrder] CHECK CONSTRAINT [FK_ProductOrder_Order]
GO
ALTER TABLE [dbo].[ProductOrder]  WITH CHECK ADD  CONSTRAINT [FK_ProductOrder_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ProductOrder] CHECK CONSTRAINT [FK_ProductOrder_Product]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name]) VALUES (1, N'mens clothing')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (2, N'jewelery')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (3, N'electronics')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (4, N'womens clothing')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [Name], [Email], [Address]) VALUES (1, N'juan', N'juan@gmail.com', N'street')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [ProductName], [ProductCode], [Description], [Price], [Stock], [Image]) VALUES (1, N'Fjallraven - Foldsack No. 1 Backpack, Fits 15 Laptops', N'PR001', N'Your perfect pack for everyday use and walks in the forest. Stash your laptop (up to 15 inches) in the padded sleeve, your everyday', CAST(1500.00 AS Numeric(18, 2)), 7, N'https://fakestoreapi.com/img/81fPKd-2AYL._AC_SL1500_.jpg')
INSERT [dbo].[Product] ([Id], [ProductName], [ProductCode], [Description], [Price], [Stock], [Image]) VALUES (2, N'Mens Casual Premium Slim Fit T-Shirts', N'PR002', N'Slim-fitting style, contrast raglan long sleeve, three-button henley placket, light weight & soft fabric for breathable and comfortable wearing.', CAST(2100.00 AS Numeric(18, 2)), 25, N'https://fakestoreapi.com/img/71-3HjGNDUL._AC_SY879._SX._UX._SY._UY_.jpg')
INSERT [dbo].[Product] ([Id], [ProductName], [ProductCode], [Description], [Price], [Stock], [Image]) VALUES (3, N'Mens Cotton Jacket', N'PC003', N'great outerwear jackets for Spring/Autumn/Winter, suitable for many occasions, such as working, hiking, camping, mountain/rock climbing, cycling, traveling or other outdoors.', CAST(2900.00 AS Numeric(18, 2)), 7, N'https://fakestoreapi.com/img/71li-ujtlUL._AC_UX679_.jpg')
INSERT [dbo].[Product] ([Id], [ProductName], [ProductCode], [Description], [Price], [Stock], [Image]) VALUES (4, N'Mens Casual Slim Fit', N'PC004', N'The color could be slightly different between on the screen and in practice. / Please note that body builds vary by person, therefore, detailed size information should be reviewed below on the product description.', CAST(450.00 AS Numeric(18, 2)), 12, N'https://fakestoreapi.com/img/71YXzeOuslL._AC_UY879_.jpg')
INSERT [dbo].[Product] ([Id], [ProductName], [ProductCode], [Description], [Price], [Stock], [Image]) VALUES (5, N'John Hardy Women Legends Naga Gold & Silver Dragon Station Chain Bracelet', N'PR005', N'From our Legends Collection, the Naga was inspired by the mythical water dragon that protects the ocean pearl.', CAST(3000.00 AS Numeric(18, 2)), 55, N'https://fakestoreapi.com/img/71pWzhdJNwL._AC_UL640_QL65_ML3_.jpg')
INSERT [dbo].[Product] ([Id], [ProductName], [ProductCode], [Description], [Price], [Stock], [Image]) VALUES (6, N'Solid Gold Petite Micropave', N'PR006', N'Satisfaction Guaranteed. Return or exchange any order within 30 days.Designed and sold by Hafeez Center in the United States. Satisfaction Guaranteed. Return or exchange any order within 30 days.', CAST(6000.00 AS Numeric(18, 2)), 17, N'https://fakestoreapi.com/img/61sbMiUnoGL._AC_UL640_QL65_ML3_.jpg')
INSERT [dbo].[Product] ([Id], [ProductName], [ProductCode], [Description], [Price], [Stock], [Image]) VALUES (7, N'White Gold Plated Princess', N'PR007', N'Classic Created Wedding Engagement Solitaire Diamond Promise Ring for Her. Gifts to spoil your love more for Engagement, Wedding, Anniversary, Valentines Day...', CAST(1200.00 AS Numeric(18, 2)), 44, N'https://fakestoreapi.com/img/71YAIFU48IL._AC_UL640_QL65_ML3_.jpg')
INSERT [dbo].[Product] ([Id], [ProductName], [ProductCode], [Description], [Price], [Stock], [Image]) VALUES (8, N'Pierced Owl Rose Gold Plated Stainless Steel Double', N'PR008', N'Rose Gold Plated Double Flared Tunnel Plug Earrings. Made of 316L Stainless Steel', CAST(1900.00 AS Numeric(18, 2)), 4, N'https://fakestoreapi.com/img/51UDEzMJVpL._AC_UL640_QL65_ML3_.jpg')
INSERT [dbo].[Product] ([Id], [ProductName], [ProductCode], [Description], [Price], [Stock], [Image]) VALUES (9, N'WD 2TB Elements Portable External Hard Drive - USB 3.0', N'PR009', N'USB 3.0 and USB 2.0 Compatibility Fast data transfers Improve PC Performance High Capacity; Compatibility Formatted NTFS', CAST(200.00 AS Numeric(18, 2)), 90, N'https://fakestoreapi.com/img/61IBBVJvSDL._AC_SY879_.jpg')
INSERT [dbo].[Product] ([Id], [ProductName], [ProductCode], [Description], [Price], [Stock], [Image]) VALUES (10, N'SanDisk SSD PLUS 1TB Internal SSD - SATA III 6 Gb/s', N'PR0010', N'Easy upgrade for faster boot up, shutdown, application load and response (As compared to 5400 RPM SATA 2.5” hard drive.)', CAST(3200.00 AS Numeric(18, 2)), 9, N'https://fakestoreapi.com/img/61U7T1koQqL._AC_SX679_.jpg')
INSERT [dbo].[Product] ([Id], [ProductName], [ProductCode], [Description], [Price], [Stock], [Image]) VALUES (11, N'Silicon Power 256GB SSD 3D NAND A55 SLC Cache Performance Boost SATA III 2.5', N'PR0011', N'3D NAND flash are applied to deliver high transfer speeds Remarkable transfer speeds that enable faster bootup and improved overall system performance.', CAST(11000.00 AS Numeric(18, 2)), 12, N'https://fakestoreapi.com/img/71kWymZ+c+L._AC_SX679_.jpg')
INSERT [dbo].[Product] ([Id], [ProductName], [ProductCode], [Description], [Price], [Stock], [Image]) VALUES (12, N'WD 4TB Gaming Drive Works with Playstation 4 Portable External Hard Drive', N'PR0012', N'Expand your PS4 gaming experience, Play anywhere Fast and easy, setup Sleek design with high capacity, 3-year manufacturers limited warranty', CAST(4600.00 AS Numeric(18, 2)), 11, N'https://fakestoreapi.com/img/61mtL65D4cL._AC_SX679_.jpg')
INSERT [dbo].[Product] ([Id], [ProductName], [ProductCode], [Description], [Price], [Stock], [Image]) VALUES (13, N'Acer SB220Q bi 21.5 inches Full HD (1920 x 1080) IPS Ultra-Thin', N'PR0013', N'21. 5 inches Full HD (1920 x 1080) widescreen IPS display And Radeon free Sync technology. No compatibility for VESA Mount Refresh Rate: 75Hz', CAST(9000.00 AS Numeric(18, 2)), 6, N'https://fakestoreapi.com/img/81QpkIctqPL._AC_SX679_.jpg')
INSERT [dbo].[Product] ([Id], [ProductName], [ProductCode], [Description], [Price], [Stock], [Image]) VALUES (14, N'Samsung 49-Inch CHG90 144Hz Curved Gaming Monitor (LC49HG90DMNXZA) – Super Ultrawide Screen QLED', N'PR0014', N'49 INCH SUPER ULTRAWIDE 32:9 CURVED GAMING MONITOR with dual 27 inch screen side by side QUANTUM DOT (QLED) TECHNOLOGY, HDR support', CAST(700.00 AS Numeric(18, 2)), 22, N'https://fakestoreapi.com/img/81Zt42ioCgL._AC_SX679_.jpg')
INSERT [dbo].[Product] ([Id], [ProductName], [ProductCode], [Description], [Price], [Stock], [Image]) VALUES (15, N'BIYLACLESEN Womens 3-in-1 Snowboard Jacket Winter Coats', N'PR0015', N'Note:The Jackets is US standard size, Please choose size as your usual wear Material: 100% Polyester; Detachable Liner Fabric: Warm Fleece. Detachable Functional Liner: Skin Friendly.', CAST(100.00 AS Numeric(18, 2)), 120, N'https://fakestoreapi.com/img/51Y5NI-I5jL._AC_UX679_.jpg')
INSERT [dbo].[Product] ([Id], [ProductName], [ProductCode], [Description], [Price], [Stock], [Image]) VALUES (16, N'Lock and Love Womens Removable Hooded Faux Leather Moto Biker Jacket', N'PR0016', N'100% POLYURETHANE(shell) 100% POLYESTER(lining) 75% POLYESTER 25% COTTON (SWEATER), Faux leather material for style and comfort / 2 pockets of front, 2-For-One Hooded denim style.', CAST(190.00 AS Numeric(18, 2)), 8, N'https://fakestoreapi.com/img/81XH0e8fefL._AC_UY879_.jpg')
INSERT [dbo].[Product] ([Id], [ProductName], [ProductCode], [Description], [Price], [Stock], [Image]) VALUES (17, N'Rain Jacket Women Windbreaker Striped Climbing Raincoats', N'PR0017', N'Lightweight perfet for trip or casual wear---Long sleeve with hooded, adjustable drawstring waist design. Button and zipper front closure raincoat, fully stripes Lined.', CAST(60.00 AS Numeric(18, 2)), 19, N'https://fakestoreapi.com/img/71HblAHs5xL._AC_UY879_-2.jpg')
INSERT [dbo].[Product] ([Id], [ProductName], [ProductCode], [Description], [Price], [Stock], [Image]) VALUES (18, N'MBJ Womens Solid Short Sleeve Boat Neck V', N'PR0018', N'95% RAYON 5% SPANDEX, Made in USA or Imported, Do Not Bleach, Lightweight fabric with great stretch for comfort, Ribbed on sleeves and neckline / Double stitching on bottom hem', CAST(7800.00 AS Numeric(18, 2)), 4, N'https://fakestoreapi.com/img/71z3kpMAYsL._AC_UY879_.jpg')
INSERT [dbo].[Product] ([Id], [ProductName], [ProductCode], [Description], [Price], [Stock], [Image]) VALUES (19, N'Opna Womens Short Sleeve Moisture', N'PR0019', N'100% Polyester, Machine wash, 100% cationic polyester interlock, Machine Wash & Pre Shrunk for a Great Fit, Lightweight, roomy and highly breathable with moisture wicking fabric which helps to keep moisture away.', CAST(300.00 AS Numeric(18, 2)), 30, N'https://fakestoreapi.com/img/51eg55uWmdL._AC_UX679_.jpg')
INSERT [dbo].[Product] ([Id], [ProductName], [ProductCode], [Description], [Price], [Stock], [Image]) VALUES (20, N'DANVOUY Womens T Shirt Casual Cotton Short', N'PR0020', N'95%Cotton,5%Spandex, Features: Casual, Short Sleeve, Letter Print,V-Neck,Fashion Tees, The fabric is soft and has some stretch., Occasion: Casual/Office/Beach/School/Home/Street. Season: Spring,Summer,Autumn,Winter.', CAST(3300.00 AS Numeric(18, 2)), 5, N'https://fakestoreapi.com/img/61pHAEJ4NML._AC_UX679_.jpg')
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductCategory] ON 

INSERT [dbo].[ProductCategory] ([Id], [ProductId], [CategoryId]) VALUES (1, 1, 1)
INSERT [dbo].[ProductCategory] ([Id], [ProductId], [CategoryId]) VALUES (2, 2, 1)
INSERT [dbo].[ProductCategory] ([Id], [ProductId], [CategoryId]) VALUES (3, 3, 1)
INSERT [dbo].[ProductCategory] ([Id], [ProductId], [CategoryId]) VALUES (4, 4, 1)
INSERT [dbo].[ProductCategory] ([Id], [ProductId], [CategoryId]) VALUES (5, 5, 2)
INSERT [dbo].[ProductCategory] ([Id], [ProductId], [CategoryId]) VALUES (6, 6, 2)
INSERT [dbo].[ProductCategory] ([Id], [ProductId], [CategoryId]) VALUES (7, 7, 2)
INSERT [dbo].[ProductCategory] ([Id], [ProductId], [CategoryId]) VALUES (8, 8, 2)
INSERT [dbo].[ProductCategory] ([Id], [ProductId], [CategoryId]) VALUES (9, 9, 3)
INSERT [dbo].[ProductCategory] ([Id], [ProductId], [CategoryId]) VALUES (10, 10, 3)
INSERT [dbo].[ProductCategory] ([Id], [ProductId], [CategoryId]) VALUES (11, 11, 3)
INSERT [dbo].[ProductCategory] ([Id], [ProductId], [CategoryId]) VALUES (12, 12, 3)
INSERT [dbo].[ProductCategory] ([Id], [ProductId], [CategoryId]) VALUES (13, 13, 3)
INSERT [dbo].[ProductCategory] ([Id], [ProductId], [CategoryId]) VALUES (14, 14, 3)
INSERT [dbo].[ProductCategory] ([Id], [ProductId], [CategoryId]) VALUES (15, 15, 4)
INSERT [dbo].[ProductCategory] ([Id], [ProductId], [CategoryId]) VALUES (16, 16, 4)
INSERT [dbo].[ProductCategory] ([Id], [ProductId], [CategoryId]) VALUES (17, 17, 4)
INSERT [dbo].[ProductCategory] ([Id], [ProductId], [CategoryId]) VALUES (18, 18, 4)
INSERT [dbo].[ProductCategory] ([Id], [ProductId], [CategoryId]) VALUES (19, 19, 4)
INSERT [dbo].[ProductCategory] ([Id], [ProductId], [CategoryId]) VALUES (20, 20, 4)
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF
GO
USE [master]
GO
ALTER DATABASE [DBSHOP] SET  READ_WRITE 
GO
