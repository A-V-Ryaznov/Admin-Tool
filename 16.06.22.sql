USE [master]
GO
/****** Object:  Database [AdminTool]    Script Date: 16.06.2022 0:21:06 ******/
CREATE DATABASE [AdminTool]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AdminTool', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\AdminTool.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AdminTool_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\AdminTool_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [AdminTool] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AdminTool].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AdminTool] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AdminTool] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AdminTool] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AdminTool] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AdminTool] SET ARITHABORT OFF 
GO
ALTER DATABASE [AdminTool] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AdminTool] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AdminTool] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AdminTool] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AdminTool] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AdminTool] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AdminTool] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AdminTool] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AdminTool] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AdminTool] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AdminTool] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AdminTool] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AdminTool] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AdminTool] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AdminTool] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AdminTool] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AdminTool] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AdminTool] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AdminTool] SET  MULTI_USER 
GO
ALTER DATABASE [AdminTool] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AdminTool] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AdminTool] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AdminTool] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AdminTool] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AdminTool] SET QUERY_STORE = OFF
GO
USE [AdminTool]
GO
/****** Object:  Table [dbo].[Blacklist]    Script Date: 16.06.2022 0:21:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blacklist](
	[PlayerID] [int] IDENTITY(1,1) NOT NULL,
	[Steam64] [nchar](17) NOT NULL,
	[PlayerNickname] [nchar](40) NOT NULL,
	[ReasonForBlocking] [nchar](40) NOT NULL,
	[DateTimeBanned] [datetime] NOT NULL,
	[DateTimeUnbanned] [datetime] NULL,
 CONSTRAINT [PK_Blacklist] PRIMARY KEY CLUSTERED 
(
	[PlayerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ModeratorList]    Script Date: 16.06.2022 0:21:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModeratorList](
	[ModeratorID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nchar](40) NOT NULL,
	[LastName] [nchar](40) NOT NULL,
	[Steam64] [nchar](17) NOT NULL,
	[AppointmentDate] [date] NOT NULL,
 CONSTRAINT [PK_ModeratorList] PRIMARY KEY CLUSTERED 
(
	[ModeratorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 16.06.2022 0:21:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nchar](40) NOT NULL,
	[LastName] [nchar](40) NOT NULL,
	[Username] [nchar](20) NOT NULL,
	[Password] [nchar](32) NOT NULL,
	[AppointmentDate] [date] NOT NULL,
	[Nickname] [nchar](40) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Whitelist]    Script Date: 16.06.2022 0:21:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Whitelist](
	[PlayerID] [int] IDENTITY(1,1) NOT NULL,
	[PlayerNickname] [nchar](40) NOT NULL,
	[Steam64] [nchar](17) NOT NULL,
	[RegistrationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Player] PRIMARY KEY CLUSTERED 
(
	[PlayerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Blacklist] ON 

INSERT [dbo].[Blacklist] ([PlayerID], [Steam64], [PlayerNickname], [ReasonForBlocking], [DateTimeBanned], [DateTimeUnbanned]) VALUES (1, N'12345678876543219', N'test                                    ', N'Введите причину                         ', CAST(N'2022-06-15T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Blacklist] ([PlayerID], [Steam64], [PlayerNickname], [ReasonForBlocking], [DateTimeBanned], [DateTimeUnbanned]) VALUES (2, N'12345678912345678', N'time                                    ', N'Введите причину                         ', CAST(N'2022-06-15T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Blacklist] ([PlayerID], [Steam64], [PlayerNickname], [ReasonForBlocking], [DateTimeBanned], [DateTimeUnbanned]) VALUES (4, N'76561198199427677', N'Senya                                   ', N'Введите причину                         ', CAST(N'2022-06-15T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Blacklist] ([PlayerID], [Steam64], [PlayerNickname], [ReasonForBlocking], [DateTimeBanned], [DateTimeUnbanned]) VALUES (6, N'12345678912345678', N'ded                                     ', N'Введите причину                         ', CAST(N'2022-06-15T00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Blacklist] OFF
GO
SET IDENTITY_INSERT [dbo].[ModeratorList] ON 

INSERT [dbo].[ModeratorList] ([ModeratorID], [FirstName], [LastName], [Steam64], [AppointmentDate]) VALUES (8, N'Данил                                   ', N'Куранов                                 ', N'76561198433847596', CAST(N'2022-06-13' AS Date))
SET IDENTITY_INSERT [dbo].[ModeratorList] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Username], [Password], [AppointmentDate], [Nickname]) VALUES (1, N'Артем                                   ', N'Оганесьянц                              ', N'admin01             ', N'Ryaznov13                       ', CAST(N'2022-06-13' AS Date), N'Ryaznov                                 ')
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Username], [Password], [AppointmentDate], [Nickname]) VALUES (2, N'Кирилл                                  ', N'Маяцкий                                 ', N'admin02             ', N'KKrill                          ', CAST(N'2022-06-13' AS Date), N'KOT                                     ')
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Username], [Password], [AppointmentDate], [Nickname]) VALUES (3, N'Иван                                    ', N'Петров                                  ', N'admin               ', N'admin                           ', CAST(N'2022-06-13' AS Date), N'Ivan                                    ')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[Whitelist] ON 

INSERT [dbo].[Whitelist] ([PlayerID], [PlayerNickname], [Steam64], [RegistrationDate]) VALUES (1, N'Korzh                                   ', N'76561199019689974', CAST(N'2022-06-13T16:52:07.203' AS DateTime))
INSERT [dbo].[Whitelist] ([PlayerID], [PlayerNickname], [Steam64], [RegistrationDate]) VALUES (4, N'Qwaranou                                ', N'76561198873299119', CAST(N'2022-06-13T16:53:01.033' AS DateTime))
INSERT [dbo].[Whitelist] ([PlayerID], [PlayerNickname], [Steam64], [RegistrationDate]) VALUES (5, N'NHanterULL                              ', N'76561199131802554', CAST(N'2022-06-13T16:53:27.867' AS DateTime))
INSERT [dbo].[Whitelist] ([PlayerID], [PlayerNickname], [Steam64], [RegistrationDate]) VALUES (8, N'Nekitosik                               ', N'76561198291471428', CAST(N'2022-06-13T16:55:09.553' AS DateTime))
INSERT [dbo].[Whitelist] ([PlayerID], [PlayerNickname], [Steam64], [RegistrationDate]) VALUES (9, N'Petrov                                  ', N'76561198265075266', CAST(N'2022-06-13T16:55:57.020' AS DateTime))
INSERT [dbo].[Whitelist] ([PlayerID], [PlayerNickname], [Steam64], [RegistrationDate]) VALUES (11, N'Anton                                   ', N'76561198265075266', CAST(N'2022-06-13T19:58:23.667' AS DateTime))
INSERT [dbo].[Whitelist] ([PlayerID], [PlayerNickname], [Steam64], [RegistrationDate]) VALUES (13, N'Hedgehog                                ', N'76561198939718122', CAST(N'2022-06-13T19:58:48.880' AS DateTime))
INSERT [dbo].[Whitelist] ([PlayerID], [PlayerNickname], [Steam64], [RegistrationDate]) VALUES (15, N'Ceva                                    ', N'76561198050328805', CAST(N'2022-06-13T19:59:11.803' AS DateTime))
INSERT [dbo].[Whitelist] ([PlayerID], [PlayerNickname], [Steam64], [RegistrationDate]) VALUES (17, N'Petrov                                  ', N'76561198858071020', CAST(N'2022-06-13T19:59:32.773' AS DateTime))
INSERT [dbo].[Whitelist] ([PlayerID], [PlayerNickname], [Steam64], [RegistrationDate]) VALUES (20, N'STRIKE                                  ', N'76561198144883729', CAST(N'2022-06-13T19:59:52.857' AS DateTime))
INSERT [dbo].[Whitelist] ([PlayerID], [PlayerNickname], [Steam64], [RegistrationDate]) VALUES (21, N'Connor                                  ', N'76561199071164762', CAST(N'2022-06-13T20:00:06.853' AS DateTime))
INSERT [dbo].[Whitelist] ([PlayerID], [PlayerNickname], [Steam64], [RegistrationDate]) VALUES (23, N'EgorA                                   ', N'76561198271043620', CAST(N'2022-06-13T20:00:25.430' AS DateTime))
INSERT [dbo].[Whitelist] ([PlayerID], [PlayerNickname], [Steam64], [RegistrationDate]) VALUES (25, N'red1                                    ', N'76561199029806719', CAST(N'2022-06-13T20:01:00.410' AS DateTime))
INSERT [dbo].[Whitelist] ([PlayerID], [PlayerNickname], [Steam64], [RegistrationDate]) VALUES (33, N'Rolf                                    ', N'78965432187654321', CAST(N'2022-06-15T00:00:00.000' AS DateTime))
INSERT [dbo].[Whitelist] ([PlayerID], [PlayerNickname], [Steam64], [RegistrationDate]) VALUES (36, N'Rozzi                                   ', N'76561198427995316', CAST(N'2022-06-15T00:00:00.000' AS DateTime))
INSERT [dbo].[Whitelist] ([PlayerID], [PlayerNickname], [Steam64], [RegistrationDate]) VALUES (37, N'Рязнов                                  ', N'76561198168862720', CAST(N'2022-06-15T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Whitelist] OFF
GO
ALTER TABLE [dbo].[Blacklist] ADD  CONSTRAINT [DF_Blacklist_DateTimeBanned]  DEFAULT (getdate()) FOR [DateTimeBanned]
GO
ALTER TABLE [dbo].[ModeratorList] ADD  CONSTRAINT [DF_ModeratorList_AppointmentDate]  DEFAULT (getdate()) FOR [AppointmentDate]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_AppointmentDate]  DEFAULT (getdate()) FOR [AppointmentDate]
GO
ALTER TABLE [dbo].[Whitelist] ADD  CONSTRAINT [DF_Player_RegistrationDate]  DEFAULT (getdate()) FOR [RegistrationDate]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Содержит данные о модераторах' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ModeratorList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Содержит в себе данные игроков (заблокированных и имеющих доступ)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Whitelist'
GO
USE [master]
GO
ALTER DATABASE [AdminTool] SET  READ_WRITE 
GO
