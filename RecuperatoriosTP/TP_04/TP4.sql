USE [master]
GO
/****** Object:  Database [TP4]    Script Date: 22/11/2020 18:20:28 ******/
CREATE DATABASE [TP4]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TP4', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\TP4.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TP4_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\TP4_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TP4] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TP4].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TP4] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TP4] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TP4] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TP4] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TP4] SET ARITHABORT OFF 
GO
ALTER DATABASE [TP4] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TP4] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TP4] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TP4] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TP4] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TP4] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TP4] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TP4] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TP4] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TP4] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TP4] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TP4] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TP4] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TP4] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TP4] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TP4] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TP4] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TP4] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TP4] SET  MULTI_USER 
GO
ALTER DATABASE [TP4] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TP4] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TP4] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TP4] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [TP4]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 22/11/2020 18:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[IdPersona] [numeric](18, 0) NOT NULL,
	[UserName] [numeric](8, 0) NOT NULL,
	[PassWord] [nvarchar](50) NOT NULL,
	[Admin] [numeric](1, 0) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personas]    Script Date: 22/11/2020 18:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personas](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Apellido] [nvarchar](50) NULL,
	[Dni] [numeric](8, 0) NOT NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 22/11/2020 18:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[Stock] [numeric](18, 0) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Empleados] ON 

INSERT [dbo].[Empleados] ([Id], [IdPersona], [UserName], [PassWord], [Admin]) VALUES (CAST(2 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(12345678 AS Numeric(8, 0)), N'a3dcb4d229de6fde0db5686dee47145d', CAST(1 AS Numeric(1, 0)))
INSERT [dbo].[Empleados] ([Id], [IdPersona], [UserName], [PassWord], [Admin]) VALUES (CAST(3 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(23456789 AS Numeric(8, 0)), N'e661e42b6cd1a627512d70462074fa22', CAST(0 AS Numeric(1, 0)))
SET IDENTITY_INSERT [dbo].[Empleados] OFF
GO
SET IDENTITY_INSERT [dbo].[Personas] ON 

INSERT [dbo].[Personas] ([Id], [Nombre], [Apellido], [Dni]) VALUES (CAST(11 AS Numeric(18, 0)), N'Rick', N'Sanchez', CAST(12345678 AS Numeric(8, 0)))
INSERT [dbo].[Personas] ([Id], [Nombre], [Apellido], [Dni]) VALUES (CAST(12 AS Numeric(18, 0)), N'Morty', N'Smith', CAST(23456789 AS Numeric(8, 0)))
INSERT [dbo].[Personas] ([Id], [Nombre], [Apellido], [Dni]) VALUES (CAST(13 AS Numeric(18, 0)), N'Marge', N'Simpson', CAST(11111111 AS Numeric(8, 0)))
INSERT [dbo].[Personas] ([Id], [Nombre], [Apellido], [Dni]) VALUES (CAST(14 AS Numeric(18, 0)), N'Homer', N'Simpson', CAST(22222222 AS Numeric(8, 0)))
INSERT [dbo].[Personas] ([Id], [Nombre], [Apellido], [Dni]) VALUES (CAST(15 AS Numeric(18, 0)), N'Lisa', N'Simpson', CAST(33333333 AS Numeric(8, 0)))
INSERT [dbo].[Personas] ([Id], [Nombre], [Apellido], [Dni]) VALUES (CAST(16 AS Numeric(18, 0)), N'Bart', N'Simpson', CAST(44444444 AS Numeric(8, 0)))
INSERT [dbo].[Personas] ([Id], [Nombre], [Apellido], [Dni]) VALUES (CAST(17 AS Numeric(18, 0)), N'Ana', N'Amari', CAST(5555555 AS Numeric(8, 0)))
INSERT [dbo].[Personas] ([Id], [Nombre], [Apellido], [Dni]) VALUES (CAST(18 AS Numeric(18, 0)), N'Winston', N' ', CAST(6666666 AS Numeric(8, 0)))
INSERT [dbo].[Personas] ([Id], [Nombre], [Apellido], [Dni]) VALUES (CAST(19 AS Numeric(18, 0)), N'Aleksandra', N'Zaryanova', CAST(1 AS Numeric(8, 0)))
INSERT [dbo].[Personas] ([Id], [Nombre], [Apellido], [Dni]) VALUES (CAST(20 AS Numeric(18, 0)), N'Cloude', N'Strife', CAST(12 AS Numeric(8, 0)))
INSERT [dbo].[Personas] ([Id], [Nombre], [Apellido], [Dni]) VALUES (CAST(21 AS Numeric(18, 0)), N'Squall', N'Leonhart', CAST(1234 AS Numeric(8, 0)))
INSERT [dbo].[Personas] ([Id], [Nombre], [Apellido], [Dni]) VALUES (CAST(22 AS Numeric(18, 0)), N'Queen', N'Peach', CAST(1256 AS Numeric(8, 0)))
INSERT [dbo].[Personas] ([Id], [Nombre], [Apellido], [Dni]) VALUES (CAST(23 AS Numeric(18, 0)), N'Arthas', N'Menethil', CAST(1214 AS Numeric(8, 0)))
INSERT [dbo].[Personas] ([Id], [Nombre], [Apellido], [Dni]) VALUES (CAST(24 AS Numeric(18, 0)), N' ', N'SinNombre', CAST(6451 AS Numeric(8, 0)))
INSERT [dbo].[Personas] ([Id], [Nombre], [Apellido], [Dni]) VALUES (CAST(25 AS Numeric(18, 0)), N'Ana', N'Perez', CAST(12414 AS Numeric(8, 0)))
INSERT [dbo].[Personas] ([Id], [Nombre], [Apellido], [Dni]) VALUES (CAST(26 AS Numeric(18, 0)), N'Pedro', N'Perez', CAST(4547 AS Numeric(8, 0)))
INSERT [dbo].[Personas] ([Id], [Nombre], [Apellido], [Dni]) VALUES (CAST(27 AS Numeric(18, 0)), N'Perez', N'Simpson', CAST(5474 AS Numeric(8, 0)))
INSERT [dbo].[Personas] ([Id], [Nombre], [Apellido], [Dni]) VALUES (CAST(28 AS Numeric(18, 0)), N'Apu', N'Nahasapeemapetilon', CAST(123 AS Numeric(8, 0)))
INSERT [dbo].[Personas] ([Id], [Nombre], [Apellido], [Dni]) VALUES (CAST(29 AS Numeric(18, 0)), N'Sanjay', N'Nahasapeemapetilon', CAST(98876433 AS Numeric(8, 0)))
INSERT [dbo].[Personas] ([Id], [Nombre], [Apellido], [Dni]) VALUES (CAST(49 AS Numeric(18, 0)), N'Aleksandra', N'Zaryanova', CAST(1 AS Numeric(8, 0)))
SET IDENTITY_INSERT [dbo].[Personas] OFF
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [Stock]) VALUES (CAST(1 AS Numeric(18, 0)), N'Almohada', CAST(3000.00 AS Decimal(18, 2)), CAST(0 AS Numeric(18, 0)))
INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [Stock]) VALUES (CAST(2 AS Numeric(18, 0)), N'Helicoptero Apache', CAST(3200.00 AS Decimal(18, 2)), CAST(0 AS Numeric(18, 0)))
INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [Stock]) VALUES (CAST(3 AS Numeric(18, 0)), N'Cama', CAST(10450.00 AS Decimal(18, 2)), CAST(0 AS Numeric(18, 0)))
INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [Stock]) VALUES (CAST(4 AS Numeric(18, 0)), N'Camisa Infant Annilhilator', CAST(11450.00 AS Decimal(18, 2)), CAST(118 AS Numeric(18, 0)))
INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [Stock]) VALUES (CAST(5 AS Numeric(18, 0)), N'Camisa SexBob-Omb', CAST(11460.00 AS Decimal(18, 2)), CAST(54 AS Numeric(18, 0)))
INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [Stock]) VALUES (CAST(6 AS Numeric(18, 0)), N'Carrito RC', CAST(5460.00 AS Decimal(18, 2)), CAST(65 AS Numeric(18, 0)))
INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [Stock]) VALUES (CAST(7 AS Numeric(18, 0)), N'Cerealitas', CAST(300.00 AS Decimal(18, 2)), CAST(76 AS Numeric(18, 0)))
INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [Stock]) VALUES (CAST(8 AS Numeric(18, 0)), N'Cobija', CAST(5000.00 AS Decimal(18, 2)), CAST(87 AS Numeric(18, 0)))
INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [Stock]) VALUES (CAST(9 AS Numeric(18, 0)), N'DuffBeer', CAST(100.00 AS Decimal(18, 2)), CAST(0 AS Numeric(18, 0)))
INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [Stock]) VALUES (CAST(10 AS Numeric(18, 0)), N'KramerArt', CAST(500000.00 AS Decimal(18, 2)), CAST(0 AS Numeric(18, 0)))
INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [Stock]) VALUES (CAST(11 AS Numeric(18, 0)), N'MAGA Hat', CAST(10.00 AS Decimal(18, 2)), CAST(0 AS Numeric(18, 0)))
INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [Stock]) VALUES (CAST(12 AS Numeric(18, 0)), N'Leche', CAST(200.00 AS Decimal(18, 2)), CAST(58 AS Numeric(18, 0)))
INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [Stock]) VALUES (CAST(13 AS Numeric(18, 0)), N'Perro', CAST(50000.00 AS Decimal(18, 2)), CAST(5 AS Numeric(18, 0)))
INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [Stock]) VALUES (CAST(14 AS Numeric(18, 0)), N'Pizza', CAST(600.00 AS Decimal(18, 2)), CAST(14 AS Numeric(18, 0)))
INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [Stock]) VALUES (CAST(15 AS Numeric(18, 0)), N'RTX2080', CAST(60000.00 AS Decimal(18, 2)), CAST(4 AS Numeric(18, 0)))
INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [Stock]) VALUES (CAST(16 AS Numeric(18, 0)), N'Snickers', CAST(200.00 AS Decimal(18, 2)), CAST(321 AS Numeric(18, 0)))
INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [Stock]) VALUES (CAST(17 AS Numeric(18, 0)), N'TimeMachine', CAST(1000.00 AS Decimal(18, 2)), CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [Stock]) VALUES (CAST(18 AS Numeric(18, 0)), N'WindowsVista', CAST(0.00 AS Decimal(18, 2)), CAST(999 AS Numeric(18, 0)))
INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [Stock]) VALUES (CAST(19 AS Numeric(18, 0)), N'Zucaritas', CAST(600.00 AS Decimal(18, 2)), CAST(99 AS Numeric(18, 0)))
INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [Stock]) VALUES (CAST(79 AS Numeric(18, 0)), N'PruebaUno', CAST(1.00 AS Decimal(18, 2)), CAST(0 AS Numeric(18, 0)))
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [FK_Empleados_Personas] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[Personas] ([Id])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [FK_Empleados_Personas]
GO
USE [master]
GO
ALTER DATABASE [TP4] SET  READ_WRITE 
GO
