USE [master]
GO
/****** Object:  Database [AdminTool]    Script Date: 15.06.2022 16:47:18 ******/
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
/****** Object:  Table [dbo].[History]    Script Date: 15.06.2022 16:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[History](
	[HistoryID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[TableID] [int] NOT NULL,
	[RecordID] [int] NOT NULL,
	[TypeHistoryID] [int] NOT NULL,
	[DateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_History] PRIMARY KEY CLUSTERED 
(
	[HistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ModeratorList]    Script Date: 15.06.2022 16:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModeratorList](
	[ModeratorID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nchar](40) NOT NULL,
	[LastName] [nchar](40) NOT NULL,
	[Surname] [nchar](40) NOT NULL,
	[PlayerID] [int] NOT NULL,
	[AppointmentDate] [date] NOT NULL,
	[IdUserAppointed] [int] NOT NULL,
 CONSTRAINT [PK_ModeratorList] PRIMARY KEY CLUSTERED 
(
	[ModeratorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OnlineList]    Script Date: 15.06.2022 16:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OnlineList](
	[OnlineListID] [int] IDENTITY(1,1) NOT NULL,
	[OnServer] [int] NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[IdUserAddedMeaning] [int] NOT NULL,
 CONSTRAINT [PK_OnlineList] PRIMARY KEY CLUSTERED 
(
	[OnlineListID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Player]    Script Date: 15.06.2022 16:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Player](
	[PlayerID] [int] IDENTITY(1,1) NOT NULL,
	[Steam64] [nchar](17) NOT NULL,
	[RegistrationDate] [datetime] NOT NULL,
	[PlayerNickname] [nchar](40) NOT NULL,
	[IdUserСheckedQuent] [int] NOT NULL,
	[IdUserConductedInterview] [int] NOT NULL,
	[IdUserAddedSystem] [int] NOT NULL,
	[IsBanned] [bit] NOT NULL,
	[AdditionalDescription] [nchar](255) NULL,
	[ReasonForBlocking] [nchar](255) NULL,
	[IdUserAddedBlock] [int] NULL,
	[DateTimeBanned] [datetime] NULL,
	[IsPermanently] [bit] NULL,
	[DateTimeUnbanned] [datetime] NULL,
 CONSTRAINT [PK_Player] PRIMARY KEY CLUSTERED 
(
	[PlayerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TableName]    Script Date: 15.06.2022 16:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableName](
	[TableID] [int] IDENTITY(1,1) NOT NULL,
	[TableName] [nchar](40) NOT NULL,
 CONSTRAINT [PK_TableName] PRIMARY KEY CLUSTERED 
(
	[TableID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeHistory]    Script Date: 15.06.2022 16:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeHistory](
	[TypeHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nchar](40) NOT NULL,
 CONSTRAINT [PK_TypeHistory] PRIMARY KEY CLUSTERED 
(
	[TypeHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 15.06.2022 16:47:18 ******/
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
	[IsBlocked] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[History] ADD  CONSTRAINT [DF_History_DateTime]  DEFAULT (getdate()) FOR [DateTime]
GO
ALTER TABLE [dbo].[ModeratorList] ADD  CONSTRAINT [DF_ModeratorList_AppointmentDate]  DEFAULT (getdate()) FOR [AppointmentDate]
GO
ALTER TABLE [dbo].[OnlineList] ADD  CONSTRAINT [DF_OnlineList_DateTime]  DEFAULT (getdate()) FOR [DateTime]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_AppointmentDate]  DEFAULT (getdate()) FOR [AppointmentDate]
GO
ALTER TABLE [dbo].[History]  WITH CHECK ADD  CONSTRAINT [FK_History_TableName] FOREIGN KEY([TableID])
REFERENCES [dbo].[TableName] ([TableID])
GO
ALTER TABLE [dbo].[History] CHECK CONSTRAINT [FK_History_TableName]
GO
ALTER TABLE [dbo].[History]  WITH CHECK ADD  CONSTRAINT [FK_History_TypeHistory] FOREIGN KEY([TypeHistoryID])
REFERENCES [dbo].[TypeHistory] ([TypeHistoryID])
GO
ALTER TABLE [dbo].[History] CHECK CONSTRAINT [FK_History_TypeHistory]
GO
ALTER TABLE [dbo].[History]  WITH CHECK ADD  CONSTRAINT [FK_History_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[History] CHECK CONSTRAINT [FK_History_User]
GO
ALTER TABLE [dbo].[ModeratorList]  WITH CHECK ADD  CONSTRAINT [FK_ModeratorList_Player] FOREIGN KEY([PlayerID])
REFERENCES [dbo].[Player] ([PlayerID])
GO
ALTER TABLE [dbo].[ModeratorList] CHECK CONSTRAINT [FK_ModeratorList_Player]
GO
ALTER TABLE [dbo].[ModeratorList]  WITH CHECK ADD  CONSTRAINT [FK_ModeratorList_User] FOREIGN KEY([IdUserAppointed])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[ModeratorList] CHECK CONSTRAINT [FK_ModeratorList_User]
GO
ALTER TABLE [dbo].[OnlineList]  WITH CHECK ADD  CONSTRAINT [FK_OnlineList_User] FOREIGN KEY([IdUserAddedMeaning])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[OnlineList] CHECK CONSTRAINT [FK_OnlineList_User]
GO
ALTER TABLE [dbo].[Player]  WITH CHECK ADD  CONSTRAINT [FK_Player_User] FOREIGN KEY([IdUserСheckedQuent])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Player] CHECK CONSTRAINT [FK_Player_User]
GO
ALTER TABLE [dbo].[Player]  WITH CHECK ADD  CONSTRAINT [FK_Player_User1] FOREIGN KEY([IdUserConductedInterview])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Player] CHECK CONSTRAINT [FK_Player_User1]
GO
ALTER TABLE [dbo].[Player]  WITH CHECK ADD  CONSTRAINT [FK_Player_User2] FOREIGN KEY([IdUserAddedSystem])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Player] CHECK CONSTRAINT [FK_Player_User2]
GO
ALTER TABLE [dbo].[Player]  WITH CHECK ADD  CONSTRAINT [FK_Player_User3] FOREIGN KEY([IdUserAddedBlock])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Player] CHECK CONSTRAINT [FK_Player_User3]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Содержит в себе историю работы с приложением' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'History'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Содержит данные о модераторах' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ModeratorList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Содержит данные о заполненности' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OnlineList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Содержит в себе данные игроков (заблокированных и имеющих доступ)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Player'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Содержит в себе ID и название таблицы. Необходимо для работы истории' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TableName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Содержит в себе тип записи в истории (удалил/заблокировал/обновил информацию). Необходимо для истори' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TypeHistory'
GO
USE [master]
GO
ALTER DATABASE [AdminTool] SET  READ_WRITE 
GO
