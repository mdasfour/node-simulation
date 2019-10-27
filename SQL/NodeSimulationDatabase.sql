﻿USE [master]
GO
CREATE DATABASE [NodeSimulation]
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NodeSimulation].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [NodeSimulation] SET ANSI_NULL_DEFAULT ON 
GO

ALTER DATABASE [NodeSimulation] SET ANSI_NULLS ON 
GO

ALTER DATABASE [NodeSimulation] SET ANSI_PADDING ON 
GO

ALTER DATABASE [NodeSimulation] SET ANSI_WARNINGS ON 
GO

ALTER DATABASE [NodeSimulation] SET ARITHABORT ON 
GO

ALTER DATABASE [NodeSimulation] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [NodeSimulation] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [NodeSimulation] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [NodeSimulation] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [NodeSimulation] SET CURSOR_DEFAULT  LOCAL 
GO

ALTER DATABASE [NodeSimulation] SET CONCAT_NULL_YIELDS_NULL ON 
GO

ALTER DATABASE [NodeSimulation] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [NodeSimulation] SET QUOTED_IDENTIFIER ON 
GO

ALTER DATABASE [NodeSimulation] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [NodeSimulation] SET  DISABLE_BROKER 
GO

ALTER DATABASE [NodeSimulation] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [NodeSimulation] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [NodeSimulation] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [NodeSimulation] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [NodeSimulation] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [NodeSimulation] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [NodeSimulation] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [NodeSimulation] SET RECOVERY FULL 
GO

ALTER DATABASE [NodeSimulation] SET  MULTI_USER 
GO

ALTER DATABASE [NodeSimulation] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [NodeSimulation] SET DB_CHAINING OFF 
GO

ALTER DATABASE [NodeSimulation] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [NodeSimulation] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [NodeSimulation] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [NodeSimulation] SET QUERY_STORE = OFF
GO

USE [NodeSimulation]
GO

ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO

ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO

ALTER DATABASE [NodeSimulation] SET  READ_WRITE 
GO

