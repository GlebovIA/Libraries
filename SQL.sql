USE [Libraries]
GO
/****** Object:  User [admin]    Script Date: 01.10.2024 20:36:45 ******/
CREATE USER [admin] FOR LOGIN [admin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [librarian1]    Script Date: 01.10.2024 20:36:45 ******/
CREATE USER [librarian1] FOR LOGIN [librarian1] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [reader1]    Script Date: 01.10.2024 20:36:45 ******/
CREATE USER [reader1] FOR LOGIN [reader1] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  DatabaseRole [Administrator]    Script Date: 01.10.2024 20:36:45 ******/
CREATE ROLE [Administrator]
GO
/****** Object:  DatabaseRole [Librarian]    Script Date: 01.10.2024 20:36:45 ******/
CREATE ROLE [Librarian]
GO
/****** Object:  DatabaseRole [Reader]    Script Date: 01.10.2024 20:36:45 ******/
CREATE ROLE [Reader]
GO
ALTER ROLE [Administrator] ADD MEMBER [admin]
GO
ALTER ROLE [db_owner] ADD MEMBER [admin]
GO
ALTER ROLE [db_datareader] ADD MEMBER [admin]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [admin]
GO
ALTER ROLE [Librarian] ADD MEMBER [librarian1]
GO
ALTER ROLE [Reader] ADD MEMBER [reader1]
GO
/****** Object:  Schema [LIBRARIAN]    Script Date: 01.10.2024 20:36:45 ******/
CREATE SCHEMA [LIBRARIAN]
GO
/****** Object:  Schema [READER]    Script Date: 01.10.2024 20:36:45 ******/
CREATE SCHEMA [READER]
GO
/****** Object:  Table [dbo].[Educations]    Script Date: 01.10.2024 20:36:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Educations](
	[Id_education] [int] IDENTITY(1,1) NOT NULL,
	[Education] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Educations] PRIMARY KEY CLUSTERED 
(
	[Id_education] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fonds]    Script Date: 01.10.2024 20:36:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fonds](
	[Id_fond] [int] IDENTITY(1,1) NOT NULL,
	[Fond_name] [varchar](100) NOT NULL,
	[Library] [int] NOT NULL,
	[Book_count] [int] NULL,
	[Journal_count] [int] NULL,
	[Newspaper_count] [int] NULL,
	[Collection_count] [int] NULL,
	[Dissertation_count] [int] NULL,
	[Report_count] [int] NULL,
 CONSTRAINT [PK__Fonds__403DBE6EA22DC698] PRIMARY KEY CLUSTERED 
(
	[Id_fond] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jobs]    Script Date: 01.10.2024 20:36:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jobs](
	[Id_job] [int] IDENTITY(1,1) NOT NULL,
	[Job_name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Jobs] PRIMARY KEY CLUSTERED 
(
	[Id_job] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libraries]    Script Date: 01.10.2024 20:36:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libraries](
	[Id_library] [int] IDENTITY(1,1) NOT NULL,
	[Library_name] [varchar](100) NOT NULL,
	[City] [varchar](40) NOT NULL,
	[Address] [varchar](100) NOT NULL,
 CONSTRAINT [PK__Librarie__E11589D5345E5727] PRIMARY KEY CLUSTERED 
(
	[Id_library] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Literature_sources]    Script Date: 01.10.2024 20:36:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Literature_sources](
	[Id_source] [int] IDENTITY(1,1) NOT NULL,
	[Source_name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Literature_sources] PRIMARY KEY CLUSTERED 
(
	[Id_source] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Literature_types]    Script Date: 01.10.2024 20:36:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Literature_types](
	[Id_type] [int] IDENTITY(1,1) NOT NULL,
	[Type_name] [varchar](100) NULL,
 CONSTRAINT [PK__Literatu__74C1FDF6BBFEAA2E] PRIMARY KEY CLUSTERED 
(
	[Id_type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Replenishments]    Script Date: 01.10.2024 20:36:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Replenishments](
	[Id_replenishment] [int] IDENTITY(1,1) NOT NULL,
	[Fond] [int] NOT NULL,
	[Worker] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[Literature_source] [int] NOT NULL,
	[Literature_type] [int] NOT NULL,
	[Publishing_company] [nvarchar](200) NOT NULL,
	[Publishing_date] [date] NOT NULL,
	[Copy_count] [int] NOT NULL,
 CONSTRAINT [PK_Replenishments] PRIMARY KEY CLUSTERED 
(
	[Id_replenishment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 01.10.2024 20:36:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id_user] [int] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](50) NULL,
	[Role] [varchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Workers]    Script Date: 01.10.2024 20:36:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workers](
	[Id_worker] [int] IDENTITY(1,1) NOT NULL,
	[Worker_surname] [varchar](30) NOT NULL,
	[Worker_name] [varchar](30) NOT NULL,
	[Worker_patronymic] [varchar](30) NOT NULL,
	[Library] [int] NOT NULL,
	[Job] [int] NOT NULL,
	[Birth_date] [date] NOT NULL,
	[Admission_date] [date] NOT NULL,
	[Education] [int] NOT NULL,
	[Salary] [decimal](8, 2) NOT NULL,
 CONSTRAINT [PK__Workers__230FFE72F3DEBDB7] PRIMARY KEY CLUSTERED 
(
	[Id_worker] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Fonds]  WITH CHECK ADD  CONSTRAINT [FK__Fonds__Library__38996AB5] FOREIGN KEY([Library])
REFERENCES [dbo].[Libraries] ([Id_library])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Fonds] CHECK CONSTRAINT [FK__Fonds__Library__38996AB5]
GO
ALTER TABLE [dbo].[Jobs]  WITH CHECK ADD  CONSTRAINT [FK_Jobs_Jobs] FOREIGN KEY([Id_job])
REFERENCES [dbo].[Jobs] ([Id_job])
GO
ALTER TABLE [dbo].[Jobs] CHECK CONSTRAINT [FK_Jobs_Jobs]
GO
ALTER TABLE [dbo].[Replenishments]  WITH CHECK ADD  CONSTRAINT [FK_Replenishments_Fonds] FOREIGN KEY([Fond])
REFERENCES [dbo].[Fonds] ([Id_fond])
GO
ALTER TABLE [dbo].[Replenishments] CHECK CONSTRAINT [FK_Replenishments_Fonds]
GO
ALTER TABLE [dbo].[Replenishments]  WITH CHECK ADD  CONSTRAINT [FK_Replenishments_Literature_sources] FOREIGN KEY([Literature_source])
REFERENCES [dbo].[Literature_sources] ([Id_source])
GO
ALTER TABLE [dbo].[Replenishments] CHECK CONSTRAINT [FK_Replenishments_Literature_sources]
GO
ALTER TABLE [dbo].[Replenishments]  WITH CHECK ADD  CONSTRAINT [FK_Replenishments_Literature_types] FOREIGN KEY([Literature_type])
REFERENCES [dbo].[Literature_types] ([Id_type])
GO
ALTER TABLE [dbo].[Replenishments] CHECK CONSTRAINT [FK_Replenishments_Literature_types]
GO
ALTER TABLE [dbo].[Replenishments]  WITH CHECK ADD  CONSTRAINT [FK_Replenishments_Workers] FOREIGN KEY([Worker])
REFERENCES [dbo].[Workers] ([Id_worker])
GO
ALTER TABLE [dbo].[Replenishments] CHECK CONSTRAINT [FK_Replenishments_Workers]
GO
ALTER TABLE [dbo].[Workers]  WITH CHECK ADD  CONSTRAINT [FK_Workers_Educations] FOREIGN KEY([Education])
REFERENCES [dbo].[Educations] ([Id_education])
GO
ALTER TABLE [dbo].[Workers] CHECK CONSTRAINT [FK_Workers_Educations]
GO
ALTER TABLE [dbo].[Workers]  WITH CHECK ADD  CONSTRAINT [FK_Workers_Jobs] FOREIGN KEY([Job])
REFERENCES [dbo].[Jobs] ([Id_job])
GO
ALTER TABLE [dbo].[Workers] CHECK CONSTRAINT [FK_Workers_Jobs]
GO
ALTER TABLE [dbo].[Workers]  WITH CHECK ADD  CONSTRAINT [FK_Workers_Libraries] FOREIGN KEY([Library])
REFERENCES [dbo].[Libraries] ([Id_library])
GO
ALTER TABLE [dbo].[Workers] CHECK CONSTRAINT [FK_Workers_Libraries]
GO
