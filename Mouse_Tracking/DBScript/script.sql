USE [mousetrackingTest]
GO
/****** Object:  Table [dbo].[Mouselog]    Script Date: 10-04-2022 11:30:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mouselog](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[user_id] [nchar](20) NULL,
	[date] [nchar](20) NULL,
	[in_time] [nchar](20) NULL,
	[productive_time] [nchar](20) NULL,
	[idle_time] [nchar](20) NULL,
	[private_time] [nchar](20) NULL,
	[work_time] [nchar](20) NULL,
	[status] [nchar](20) NULL,
	[created_at] [nchar](20) NULL,
	[updated_at] [nchar](20) NULL,
	[leftTime] [nchar](20) NULL,
 CONSTRAINT [PK_Mouselog_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
