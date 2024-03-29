CREATE DATABASE [BookStoreOnline]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookStoreOnline', FILENAME = N'E:\Learn\SQLServer\MSSQL14.MSSQLSERVER\MSSQL\DATA\BookStoreOnline.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BookStoreOnline_log', FILENAME = N'E:\Learn\SQLServer\MSSQL14.MSSQLSERVER\MSSQL\DATA\BookStoreOnline_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BookStoreOnline] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookStoreOnline].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookStoreOnline] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookStoreOnline] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookStoreOnline] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookStoreOnline] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookStoreOnline] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookStoreOnline] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BookStoreOnline] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookStoreOnline] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookStoreOnline] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookStoreOnline] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookStoreOnline] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookStoreOnline] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookStoreOnline] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookStoreOnline] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookStoreOnline] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BookStoreOnline] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookStoreOnline] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookStoreOnline] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookStoreOnline] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookStoreOnline] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookStoreOnline] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BookStoreOnline] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookStoreOnline] SET RECOVERY FULL 
GO
ALTER DATABASE [BookStoreOnline] SET  MULTI_USER 
GO
ALTER DATABASE [BookStoreOnline] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookStoreOnline] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookStoreOnline] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookStoreOnline] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BookStoreOnline] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BookStoreOnline', N'ON'
GO
ALTER DATABASE [BookStoreOnline] SET QUERY_STORE = OFF
GO
USE [BookStoreOnline]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 4/4/2020 8:30:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[BookName] [nvarchar](50) NOT NULL,
	[BookDescription] [nvarchar](2000) NULL,
	[BookImage] [varchar](500) NULL,
	[BookPrice] [money] NULL,
	[BookDiscount] [int] NULL,
	[GenreId] [int] NOT NULL,
 CONSTRAINT [PK__Book__3DE0C207D8160B6B] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookGenre]    Script Date: 4/4/2020 8:30:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookGenre](
	[GenreId] [int] IDENTITY(1,1) NOT NULL,
	[GenreName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookOrder]    Script Date: 4/4/2020 8:30:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookOrder](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[Total] [float] NULL,
	[OrderDate] [date] NULL,
 CONSTRAINT [PK__BookOrde__C3905BCFE8019D36] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookOrderMeta]    Script Date: 4/4/2020 8:30:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookOrderMeta](
	[OrderMetaId] [int] IDENTITY(1,1) NOT NULL,
	[BookId] [int] NOT NULL,
	[BookQuantity] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
 CONSTRAINT [PK__BookOrde__6A1B65E8716B3531] PRIMARY KEY CLUSTERED 
(
	[OrderMetaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookRole]    Script Date: 4/4/2020 8:30:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookRole](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](20) NULL,
 CONSTRAINT [PK_BookRole] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookUser]    Script Date: 4/4/2020 8:30:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookUser](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK__BookUser__1788CC4CDF5C60DC] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (1, N'The Queen''s Assassin', N'Perfect for fans of Sarah J. Maas and Red Queen, this is the first novel in a sweeping YA fantasy-romance duet about a deadly assassin, his mysterious apprentice, and the country they are sworn to protect from #1 NYT bestselling author Melissa de la Cruz.', N'/Images/Uploads/1.jpg', 100000.0000, 0, 20)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (4, N'Designing Your Work Life', N'From the authors of the #1 New York Times best seller Designing Your Life ("Life has questions. They have answers" --The NYT)--a job-changing, outlook-changing, life-changing book that shows us how to transform our work lives and create a dream job that is meaningful without necessarily changing the job we have.', N'/Images/Uploads/4.jpg', 90000.0000, 10, 19)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (5, N'Earth the life of our planet', N'Text, photographs, and illustrations offer a visual narrative of the geographical history of Earth.', N'/Images/Uploads/5.jpg', 60000.0000, 0, 20)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (18, N'Designing Your Work Life', N'From the authors of the #1 New York Times best seller Designing Your Life ("Life has questions. They have answers" --The NYT)--a job-changing, outlook-changing, life-changing book that shows us how to transform our work lives and create a dream job that is meaningful without necessarily changing the job we have.', N'/Images/Uploads/4.jpg', 90000.0000, 10, 19)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (19, N'Earth the life of our planet', N'Text, photographs, and illustrations offer a visual narrative of the geographical history of Earth.', N'/Images/Uploads/5.jpg', 60000.0000, 0, 20)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (20, N'Designing Your Work Life', N'From the authors of the #1 New York Times best seller Designing Your Life ("Life has questions. They have answers" --The NYT)--a job-changing, outlook-changing, life-changing book that shows us how to transform our work lives and create a dream job that is meaningful without necessarily changing the job we have.', N'/Images/Uploads/4.jpg', 90000.0000, 10, 19)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (21, N'Earth the life of our planet', N'Text, photographs, and illustrations offer a visual narrative of the geographical history of Earth.', N'/Images/Uploads/5.jpg', 60000.0000, 0, 20)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (22, N'Designing Your Work Life', N'From the authors of the #1 New York Times best seller Designing Your Life ("Life has questions. They have answers" --The NYT)--a job-changing, outlook-changing, life-changing book that shows us how to transform our work lives and create a dream job that is meaningful without necessarily changing the job we have.', N'/Images/Uploads/4.jpg', 90000.0000, 10, 19)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (23, N'Earth the life of our planet', N'Text, photographs, and illustrations offer a visual narrative of the geographical history of Earth.', N'/Images/Uploads/5.jpg', 60000.0000, 0, 20)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (24, N'Designing Your Work Life', N'From the authors of the #1 New York Times best seller Designing Your Life ("Life has questions. They have answers" --The NYT)--a job-changing, outlook-changing, life-changing book that shows us how to transform our work lives and create a dream job that is meaningful without necessarily changing the job we have.', N'/Images/Uploads/4.jpg', 90000.0000, 10, 19)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (25, N'Earth the life of our planet', N'Text, photographs, and illustrations offer a visual narrative of the geographical history of Earth.', N'/Images/Uploads/5.jpg', 60000.0000, 0, 20)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (26, N'Designing Your Work Life', N'From the authors of the #1 New York Times best seller Designing Your Life ("Life has questions. They have answers" --The NYT)--a job-changing, outlook-changing, life-changing book that shows us how to transform our work lives and create a dream job that is meaningful without necessarily changing the job we have.', N'/Images/Uploads/4.jpg', 90000.0000, 10, 19)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (27, N'Earth the life of our planet', N'Text, photographs, and illustrations offer a visual narrative of the geographical history of Earth.', N'/Images/Uploads/5.jpg', 60000.0000, 0, 20)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (28, N'Designing Your Work Life', N'From the authors of the #1 New York Times best seller Designing Your Life ("Life has questions. They have answers" --The NYT)--a job-changing, outlook-changing, life-changing book that shows us how to transform our work lives and create a dream job that is meaningful without necessarily changing the job we have.', N'/Images/Uploads/4.jpg', 90000.0000, 10, 19)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (29, N'Earth the life of our planet', N'Text, photographs, and illustrations offer a visual narrative of the geographical history of Earth.', N'/Images/Uploads/5.jpg', 60000.0000, 0, 20)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (30, N'Designing Your Work Life', N'From the authors of the #1 New York Times best seller Designing Your Life ("Life has questions. They have answers" --The NYT)--a job-changing, outlook-changing, life-changing book that shows us how to transform our work lives and create a dream job that is meaningful without necessarily changing the job we have.', N'/Images/Uploads/4.jpg', 90000.0000, 10, 19)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (31, N'Earth the life of our planet', N'Text, photographs, and illustrations offer a visual narrative of the geographical history of Earth.', N'/Images/Uploads/5.jpg', 60000.0000, 0, 20)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (32, N'Designing Your Work Life', N'From the authors of the #1 New York Times best seller Designing Your Life ("Life has questions. They have answers" --The NYT)--a job-changing, outlook-changing, life-changing book that shows us how to transform our work lives and create a dream job that is meaningful without necessarily changing the job we have.', N'/Images/Uploads/4.jpg', 90000.0000, 10, 19)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (33, N'Earth the life of our planet', N'Text, photographs, and illustrations offer a visual narrative of the geographical history of Earth.', N'/Images/Uploads/5.jpg', 60000.0000, 0, 20)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (34, N'Designing Your Work Life', N'From the authors of the #1 New York Times best seller Designing Your Life ("Life has questions. They have answers" --The NYT)--a job-changing, outlook-changing, life-changing book that shows us how to transform our work lives and create a dream job that is meaningful without necessarily changing the job we have.', N'/Images/Uploads/4.jpg', 90000.0000, 10, 19)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (35, N'Earth the life of our planet', N'Text, photographs, and illustrations offer a visual narrative of the geographical history of Earth.', N'/Images/Uploads/5.jpg', 60000.0000, 0, 20)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (36, N'Designing Your Work Life', N'From the authors of the #1 New York Times best seller Designing Your Life ("Life has questions. They have answers" --The NYT)--a job-changing, outlook-changing, life-changing book that shows us how to transform our work lives and create a dream job that is meaningful without necessarily changing the job we have.', N'/Images/Uploads/4.jpg', 90000.0000, 10, 19)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (37, N'Earth the life of our planet', N'Text, photographs, and illustrations offer a visual narrative of the geographical history of Earth.', N'/Images/Uploads/5.jpg', 60000.0000, 0, 20)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (38, N'Designing Your Work Life', N'From the authors of the #1 New York Times best seller Designing Your Life ("Life has questions. They have answers" --The NYT)--a job-changing, outlook-changing, life-changing book that shows us how to transform our work lives and create a dream job that is meaningful without necessarily changing the job we have.', N'/Images/Uploads/4.jpg', 90000.0000, 10, 19)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (39, N'Earth the life of our planet', N'Text, photographs, and illustrations offer a visual narrative of the geographical history of Earth.', N'/Images/Uploads/5.jpg', 60000.0000, 0, 20)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (40, N'Designing Your Work Life', N'From the authors of the #1 New York Times best seller Designing Your Life ("Life has questions. They have answers" --The NYT)--a job-changing, outlook-changing, life-changing book that shows us how to transform our work lives and create a dream job that is meaningful without necessarily changing the job we have.', N'/Images/Uploads/4.jpg', 90000.0000, 10, 19)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (41, N'Earth the life of our planet', N'Text, photographs, and illustrations offer a visual narrative of the geographical history of Earth.', N'/Images/Uploads/5.jpg', 60000.0000, 0, 20)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (42, N'Designing Your Work Life', N'From the authors of the #1 New York Times best seller Designing Your Life ("Life has questions. They have answers" --The NYT)--a job-changing, outlook-changing, life-changing book that shows us how to transform our work lives and create a dream job that is meaningful without necessarily changing the job we have.', N'/Images/Uploads/4.jpg', 90000.0000, 10, 19)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (43, N'Earth the life of our planet', N'Text, photographs, and illustrations offer a visual narrative of the geographical history of Earth.', N'/Images/Uploads/5.jpg', 60000.0000, 0, 20)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (44, N'Designing Your Work Life', N'From the authors of the #1 New York Times best seller Designing Your Life ("Life has questions. They have answers" --The NYT)--a job-changing, outlook-changing, life-changing book that shows us how to transform our work lives and create a dream job that is meaningful without necessarily changing the job we have.', N'/Images/Uploads/4.jpg', 90000.0000, 10, 19)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (45, N'Earth the life of our planet', N'Text, photographs, and illustrations offer a visual narrative of the geographical history of Earth.', N'/Images/Uploads/5.jpg', 60000.0000, 0, 20)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (46, N'Designing Your Work Life', N'From the authors of the #1 New York Times best seller Designing Your Life ("Life has questions. They have answers" --The NYT)--a job-changing, outlook-changing, life-changing book that shows us how to transform our work lives and create a dream job that is meaningful without necessarily changing the job we have.', N'/Images/Uploads/4.jpg', 90000.0000, 10, 19)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (47, N'Earth the life of our planet', N'Text, photographs, and illustrations offer a visual narrative of the geographical history of Earth.', N'/Images/Uploads/5.jpg', 60000.0000, 0, 20)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (48, N'Designing Your Work Life', N'From the authors of the #1 New York Times best seller Designing Your Life ("Life has questions. They have answers" --The NYT)--a job-changing, outlook-changing, life-changing book that shows us how to transform our work lives and create a dream job that is meaningful without necessarily changing the job we have.', N'/Images/Uploads/4.jpg', 90000.0000, 10, 19)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (49, N'Earth the life of our planet', N'Text, photographs, and illustrations offer a visual narrative of the geographical history of Earth.', N'/Images/Uploads/5.jpg', 60000.0000, 0, 20)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (50, N'Designing Your Work Life', N'From the authors of the #1 New York Times best seller Designing Your Life ("Life has questions. They have answers" --The NYT)--a job-changing, outlook-changing, life-changing book that shows us how to transform our work lives and create a dream job that is meaningful without necessarily changing the job we have.', N'/Images/Uploads/4.jpg', 90000.0000, 10, 19)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (51, N'Earth the life of our planet', N'Text, photographs, and illustrations offer a visual narrative of the geographical history of Earth.', N'/Images/Uploads/5.jpg', 60000.0000, 0, 20)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (52, N'Designing Your Work Life', N'From the authors of the #1 New York Times best seller Designing Your Life ("Life has questions. They have answers" --The NYT)--a job-changing, outlook-changing, life-changing book that shows us how to transform our work lives and create a dream job that is meaningful without necessarily changing the job we have.', N'/Images/Uploads/4.jpg', 90000.0000, 10, 19)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (53, N'Earth the life of our planet', N'Text, photographs, and illustrations offer a visual narrative of the geographical history of Earth.', N'/Images/Uploads/5.jpg', 60000.0000, 0, 20)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (54, N'Designing Your Work Life', N'From the authors of the #1 New York Times best seller Designing Your Life ("Life has questions. They have answers" --The NYT)--a job-changing, outlook-changing, life-changing book that shows us how to transform our work lives and create a dream job that is meaningful without necessarily changing the job we have.', N'/Images/Uploads/4.jpg', 90000.0000, 10, 19)
INSERT [dbo].[Book] ([BookId], [BookName], [BookDescription], [BookImage], [BookPrice], [BookDiscount], [GenreId]) VALUES (55, N'Earth the life of our planet', N'Text, photographs, and illustrations offer a visual narrative of the geographical history of Earth.', N'/Images/Uploads/5.jpg', 60000.0000, 0, 20)
SET IDENTITY_INSERT [dbo].[Book] OFF
SET IDENTITY_INSERT [dbo].[BookGenre] ON 

INSERT [dbo].[BookGenre] ([GenreId], [GenreName]) VALUES (1, N'Art')
INSERT [dbo].[BookGenre] ([GenreId], [GenreName]) VALUES (2, N'Biography')
INSERT [dbo].[BookGenre] ([GenreId], [GenreName]) VALUES (3, N'Business')
INSERT [dbo].[BookGenre] ([GenreId], [GenreName]) VALUES (4, N'Children''s')
INSERT [dbo].[BookGenre] ([GenreId], [GenreName]) VALUES (5, N'Classics')
INSERT [dbo].[BookGenre] ([GenreId], [GenreName]) VALUES (6, N'Comics')
INSERT [dbo].[BookGenre] ([GenreId], [GenreName]) VALUES (7, N'Cookbooks')
INSERT [dbo].[BookGenre] ([GenreId], [GenreName]) VALUES (8, N'Fantasy')
INSERT [dbo].[BookGenre] ([GenreId], [GenreName]) VALUES (9, N'Fiction')
INSERT [dbo].[BookGenre] ([GenreId], [GenreName]) VALUES (10, N'Graphic Novels')
INSERT [dbo].[BookGenre] ([GenreId], [GenreName]) VALUES (11, N'Historical Fiction')
INSERT [dbo].[BookGenre] ([GenreId], [GenreName]) VALUES (12, N'History')
INSERT [dbo].[BookGenre] ([GenreId], [GenreName]) VALUES (13, N'Horror')
INSERT [dbo].[BookGenre] ([GenreId], [GenreName]) VALUES (14, N'Memoir')
INSERT [dbo].[BookGenre] ([GenreId], [GenreName]) VALUES (15, N'Music')
INSERT [dbo].[BookGenre] ([GenreId], [GenreName]) VALUES (16, N'Mystery')
INSERT [dbo].[BookGenre] ([GenreId], [GenreName]) VALUES (17, N'Nonfiction')
INSERT [dbo].[BookGenre] ([GenreId], [GenreName]) VALUES (18, N'Poetry')
INSERT [dbo].[BookGenre] ([GenreId], [GenreName]) VALUES (19, N'Psychology')
INSERT [dbo].[BookGenre] ([GenreId], [GenreName]) VALUES (20, N'Romance')
INSERT [dbo].[BookGenre] ([GenreId], [GenreName]) VALUES (21, N'Science')
INSERT [dbo].[BookGenre] ([GenreId], [GenreName]) VALUES (22, N'Science Fiction')
INSERT [dbo].[BookGenre] ([GenreId], [GenreName]) VALUES (23, N'Self Help')
INSERT [dbo].[BookGenre] ([GenreId], [GenreName]) VALUES (24, N'Sports')
INSERT [dbo].[BookGenre] ([GenreId], [GenreName]) VALUES (25, N'Thriller')
INSERT [dbo].[BookGenre] ([GenreId], [GenreName]) VALUES (26, N'Travel')
INSERT [dbo].[BookGenre] ([GenreId], [GenreName]) VALUES (28, N'Geography')
SET IDENTITY_INSERT [dbo].[BookGenre] OFF
SET IDENTITY_INSERT [dbo].[BookOrder] ON 

INSERT [dbo].[BookOrder] ([OrderId], [UserId], [Total], [OrderDate]) VALUES (4, 3, 282000, CAST(N'2020-04-03' AS Date))
INSERT [dbo].[BookOrder] ([OrderId], [UserId], [Total], [OrderDate]) VALUES (5, 3, 141000, CAST(N'2020-04-03' AS Date))
INSERT [dbo].[BookOrder] ([OrderId], [UserId], [Total], [OrderDate]) VALUES (6, 9, 81000, CAST(N'2020-04-03' AS Date))
INSERT [dbo].[BookOrder] ([OrderId], [UserId], [Total], [OrderDate]) VALUES (7, 3, 401000, CAST(N'2020-04-03' AS Date))
SET IDENTITY_INSERT [dbo].[BookOrder] OFF
SET IDENTITY_INSERT [dbo].[BookOrderMeta] ON 

INSERT [dbo].[BookOrderMeta] ([OrderMetaId], [BookId], [BookQuantity], [OrderId]) VALUES (7, 55, 2, 4)
INSERT [dbo].[BookOrderMeta] ([OrderMetaId], [BookId], [BookQuantity], [OrderId]) VALUES (8, 54, 2, 4)
INSERT [dbo].[BookOrderMeta] ([OrderMetaId], [BookId], [BookQuantity], [OrderId]) VALUES (9, 55, 1, 5)
INSERT [dbo].[BookOrderMeta] ([OrderMetaId], [BookId], [BookQuantity], [OrderId]) VALUES (10, 54, 1, 5)
INSERT [dbo].[BookOrderMeta] ([OrderMetaId], [BookId], [BookQuantity], [OrderId]) VALUES (11, 54, 1, 6)
INSERT [dbo].[BookOrderMeta] ([OrderMetaId], [BookId], [BookQuantity], [OrderId]) VALUES (12, 54, 1, 7)
INSERT [dbo].[BookOrderMeta] ([OrderMetaId], [BookId], [BookQuantity], [OrderId]) VALUES (13, 55, 2, 7)
INSERT [dbo].[BookOrderMeta] ([OrderMetaId], [BookId], [BookQuantity], [OrderId]) VALUES (14, 1, 2, 7)
SET IDENTITY_INSERT [dbo].[BookOrderMeta] OFF
SET IDENTITY_INSERT [dbo].[BookRole] ON 

INSERT [dbo].[BookRole] ([RoleId], [RoleName]) VALUES (1, N'User')
INSERT [dbo].[BookRole] ([RoleId], [RoleName]) VALUES (2, N'Admin')
SET IDENTITY_INSERT [dbo].[BookRole] OFF
SET IDENTITY_INSERT [dbo].[BookUser] ON 

INSERT [dbo].[BookUser] ([UserId], [Username], [Password], [RoleId]) VALUES (1, N'admin', N'admin', 2)
INSERT [dbo].[BookUser] ([UserId], [Username], [Password], [RoleId]) VALUES (2, N'user', N'user', 1)
INSERT [dbo].[BookUser] ([UserId], [Username], [Password], [RoleId]) VALUES (3, N'alex', N'123', 2)
INSERT [dbo].[BookUser] ([UserId], [Username], [Password], [RoleId]) VALUES (8, N'hihi', N'hihi', 1)
INSERT [dbo].[BookUser] ([UserId], [Username], [Password], [RoleId]) VALUES (9, N'lola', N'123', 1)
SET IDENTITY_INSERT [dbo].[BookUser] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__BookUser__536C85E4E5886154]    Script Date: 4/4/2020 8:30:06 PM ******/
ALTER TABLE [dbo].[BookUser] ADD  CONSTRAINT [UQ__BookUser__536C85E4E5886154] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Genre] FOREIGN KEY([GenreId])
REFERENCES [dbo].[BookGenre] ([GenreId])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Genre]
GO
ALTER TABLE [dbo].[BookOrder]  WITH CHECK ADD  CONSTRAINT [FK__BookOrder__UserI__5070F446] FOREIGN KEY([UserId])
REFERENCES [dbo].[BookUser] ([UserId])
GO
ALTER TABLE [dbo].[BookOrder] CHECK CONSTRAINT [FK__BookOrder__UserI__5070F446]
GO
ALTER TABLE [dbo].[BookOrderMeta]  WITH CHECK ADD  CONSTRAINT [FK__BookOrder__BookI__534D60F1] FOREIGN KEY([BookId])
REFERENCES [dbo].[Book] ([BookId])
GO
ALTER TABLE [dbo].[BookOrderMeta] CHECK CONSTRAINT [FK__BookOrder__BookI__534D60F1]
GO
ALTER TABLE [dbo].[BookOrderMeta]  WITH CHECK ADD  CONSTRAINT [FK__BookOrder__Order__5629CD9C] FOREIGN KEY([OrderId])
REFERENCES [dbo].[BookOrder] ([OrderId])
GO
ALTER TABLE [dbo].[BookOrderMeta] CHECK CONSTRAINT [FK__BookOrder__Order__5629CD9C]
GO
ALTER TABLE [dbo].[BookUser]  WITH CHECK ADD  CONSTRAINT [FK_BookUser_BookRole] FOREIGN KEY([RoleId])
REFERENCES [dbo].[BookRole] ([RoleId])
GO
ALTER TABLE [dbo].[BookUser] CHECK CONSTRAINT [FK_BookUser_BookRole]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [CK__Book__BookDiscou__440B1D61] CHECK  (([BookDiscount]>=(0) AND [BookDiscount]<=(100)))
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [CK__Book__BookDiscou__440B1D61]
GO
ALTER TABLE [dbo].[BookOrderMeta]  WITH CHECK ADD  CONSTRAINT [CK__BookOrder__BookQ__5535A963] CHECK  (([BookQuantity]>(0)))
GO
ALTER TABLE [dbo].[BookOrderMeta] CHECK CONSTRAINT [CK__BookOrder__BookQ__5535A963]
GO
USE [master]
GO
ALTER DATABASE [BookStoreOnline] SET  READ_WRITE 
GO
