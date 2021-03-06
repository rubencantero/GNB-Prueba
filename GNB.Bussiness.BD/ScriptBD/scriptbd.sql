USE [master]
GO
/****** Object:  Database [ruben_cantero]    Script Date: 15/03/2022 10:28:40 ******/
CREATE DATABASE [ruben_cantero]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ruben_cantero', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ruben_cantero.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ruben_cantero_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ruben_cantero_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ruben_cantero] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ruben_cantero].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ruben_cantero] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ruben_cantero] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ruben_cantero] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ruben_cantero] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ruben_cantero] SET ARITHABORT OFF 
GO
ALTER DATABASE [ruben_cantero] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ruben_cantero] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ruben_cantero] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ruben_cantero] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ruben_cantero] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ruben_cantero] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ruben_cantero] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ruben_cantero] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ruben_cantero] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ruben_cantero] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ruben_cantero] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ruben_cantero] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ruben_cantero] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ruben_cantero] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ruben_cantero] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ruben_cantero] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ruben_cantero] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ruben_cantero] SET RECOVERY FULL 
GO
ALTER DATABASE [ruben_cantero] SET  MULTI_USER 
GO
ALTER DATABASE [ruben_cantero] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ruben_cantero] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ruben_cantero] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ruben_cantero] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ruben_cantero] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ruben_cantero] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ruben_cantero', N'ON'
GO
ALTER DATABASE [ruben_cantero] SET QUERY_STORE = OFF
GO
USE [ruben_cantero]
GO
/****** Object:  User [admin]    Script Date: 15/03/2022 10:28:40 ******/
CREATE USER [admin] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[db_accessadmin]
GO
/****** Object:  Table [dbo].[Conversions]    Script Date: 15/03/2022 10:28:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Conversions](
	[pk_ConvertId] [int] IDENTITY(1,1) NOT NULL,
	[ConvertFrom] [nvarchar](max) NOT NULL,
	[ConvertTo] [nvarchar](max) NOT NULL,
	[ConvertAmount] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[pk_ConvertId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 15/03/2022 10:28:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[pk_TransactionId] [int] IDENTITY(1,1) NOT NULL,
	[TransactionSku] [nvarchar](max) NULL,
	[TransactionAmount] [decimal](18, 0) NULL,
	[TransactionCurrency] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[pk_TransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Conversions] ON 

INSERT [dbo].[Conversions] ([pk_ConvertId], [ConvertFrom], [ConvertTo], [ConvertAmount]) VALUES (1, N'DOL', N'EUR', CAST(1.10 AS Decimal(18, 2)))
INSERT [dbo].[Conversions] ([pk_ConvertId], [ConvertFrom], [ConvertTo], [ConvertAmount]) VALUES (3, N'EUR', N'DOL', CAST(0.80 AS Decimal(18, 2)))
INSERT [dbo].[Conversions] ([pk_ConvertId], [ConvertFrom], [ConvertTo], [ConvertAmount]) VALUES (4, N'DOL', N'LIB', CAST(1.60 AS Decimal(18, 2)))
INSERT [dbo].[Conversions] ([pk_ConvertId], [ConvertFrom], [ConvertTo], [ConvertAmount]) VALUES (5, N'LIB', N'DOL', CAST(1.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Conversions] OFF
GO
SET IDENTITY_INSERT [dbo].[Transactions] ON 

INSERT [dbo].[Transactions] ([pk_TransactionId], [TransactionSku], [TransactionAmount], [TransactionCurrency]) VALUES (1, N'TT58585', CAST(9 AS Decimal(18, 0)), N'EUR')
INSERT [dbo].[Transactions] ([pk_TransactionId], [TransactionSku], [TransactionAmount], [TransactionCurrency]) VALUES (2, N'TT58585', CAST(25 AS Decimal(18, 0)), N'LIB')
INSERT [dbo].[Transactions] ([pk_TransactionId], [TransactionSku], [TransactionAmount], [TransactionCurrency]) VALUES (3, N'TT58585', CAST(15 AS Decimal(18, 0)), N'DOL')
INSERT [dbo].[Transactions] ([pk_TransactionId], [TransactionSku], [TransactionAmount], [TransactionCurrency]) VALUES (4, N'PPKL', CAST(34 AS Decimal(18, 0)), N'LIB')
INSERT [dbo].[Transactions] ([pk_TransactionId], [TransactionSku], [TransactionAmount], [TransactionCurrency]) VALUES (5, N'GJG8989', CAST(19 AS Decimal(18, 0)), N'EUR')
INSERT [dbo].[Transactions] ([pk_TransactionId], [TransactionSku], [TransactionAmount], [TransactionCurrency]) VALUES (6, N'GJG8989', CAST(56 AS Decimal(18, 0)), N'DOL')
SET IDENTITY_INSERT [dbo].[Transactions] OFF
GO
USE [master]
GO
ALTER DATABASE [ruben_cantero] SET  READ_WRITE 
GO
