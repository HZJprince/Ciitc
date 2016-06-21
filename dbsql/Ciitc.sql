USE [master]
GO
/****** Object:  Database [Ciitc]    Script Date: 2016/6/21 星期二 10:24:01 ******/
CREATE DATABASE [Ciitc]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Ciitc', FILENAME = N'D:\DB\Ciitc.mdf' , SIZE = 23552KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Ciitc_log', FILENAME = N'D:\DB\Ciitc_log.ldf' , SIZE = 123648KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Ciitc] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Ciitc].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Ciitc] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Ciitc] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Ciitc] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Ciitc] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Ciitc] SET ARITHABORT OFF 
GO
ALTER DATABASE [Ciitc] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Ciitc] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Ciitc] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Ciitc] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Ciitc] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Ciitc] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Ciitc] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Ciitc] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Ciitc] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Ciitc] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Ciitc] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Ciitc] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Ciitc] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Ciitc] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Ciitc] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Ciitc] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Ciitc] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Ciitc] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Ciitc] SET RECOVERY FULL 
GO
ALTER DATABASE [Ciitc] SET  MULTI_USER 
GO
ALTER DATABASE [Ciitc] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Ciitc] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Ciitc] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Ciitc] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Ciitc', N'ON'
GO
USE [Ciitc]
GO
/****** Object:  Table [dbo].[CX]    Script Date: 2016/6/21 星期二 10:24:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CX](
	[DISTRICT_CODE] [varchar](6) NULL,
	[COMPANY_CODE] [varchar](4) NULL,
	[QUERY_SEQUENCE_NO] [varchar](50) NULL,
	[QUERY_DATE] [varchar](8) NULL,
	[BILL_DATE] [varchar](8) NULL,
	[START_DATE] [varchar](8) NULL,
	[END_DATE] [varchar](8) NULL,
	[LICENSE_TYPE] [varchar](10) NULL,
	[MOTOR_TYPE_CODE] [varchar](10) NULL,
	[USE_NATURE_CODE] [varchar](10) NULL,
	[LICENSE_NO] [varchar](30) NULL,
	[FRAME_NO] [varchar](30) NULL,
	[ENGINE_NO] [varchar](50) NULL,
	[PREMIUM] [varchar](10) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QD]    Script Date: 2016/6/21 星期二 10:24:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QD](
	[DISTRICT_CODE] [varchar](6) NULL,
	[COMPANY_CODE] [varchar](4) NULL,
	[POLICY_NO] [varchar](22) NULL,
	[QUERY_SEQUENCE_NO] [varchar](50) NULL,
	[CONFIRMSEQUENCE_NO] [varchar](50) NULL,
	[CONFIRM_DATE] [varchar](8) NULL,
	[BILL_DATE] [varchar](8) NULL,
	[START_DATE] [varchar](8) NULL,
	[END_DATE] [varchar](8) NULL,
	[LICENSE_TYPE] [varchar](10) NULL,
	[MOTOR_TYPE_CODE] [varchar](10) NULL,
	[USE_NATURE_CODE] [varchar](10) NULL,
	[LICENSE_NO] [varchar](30) NULL,
	[FRAME_NO] [varchar](30) NULL,
	[ENGINE_NO] [varchar](50) NULL,
	[PREMIUM] [varchar](10) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [Ciitc] SET  READ_WRITE 
GO
