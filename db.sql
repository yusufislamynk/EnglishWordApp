USE [EnglishProject]
GO
/****** Object:  Table [dbo].[Log]    Script Date: 24.05.2024 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[logID] [int] IDENTITY(1,1) NOT NULL,
	[userID] [int] NULL,
	[wordID] [int] NULL,
	[trueCount] [int] NULL,
	[falseCount] [int] NULL,
	[examID] [nchar](255) NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[logID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 24.05.2024 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[userID] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](200) NULL,
	[surname] [varchar](200) NULL,
	[username] [varchar](200) NULL,
	[email] [varchar](200) NULL,
	[password] [varchar](200) NULL,
	[questionCount] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[userID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Word]    Script Date: 24.05.2024 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Word](
	[wordID] [int] IDENTITY(1,1) NOT NULL,
	[wordTR] [varchar](50) NULL,
	[wordEN] [varchar](50) NULL,
	[wordSentence] [varchar](max) NOT NULL,
	[isLearning] [bit] NULL,
	[userID] [int] NULL,
	[replyDate] [date] NULL,
	[wordImage] [varchar](max) NULL,
 CONSTRAINT [PK_Word] PRIMARY KEY CLUSTERED 
(
	[wordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
