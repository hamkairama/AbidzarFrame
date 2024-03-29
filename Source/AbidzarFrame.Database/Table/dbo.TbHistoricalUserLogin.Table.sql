SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbHistoricalUserLogin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nik] [varchar](16) NOT NULL,
	[Login] [datetime] NULL,
	[Logout] [datetime] NULL,
	[IsMobile] [bit] NOT NULL,
	[DibuatOleh] [varchar](20) NOT NULL,
	[DibuatTanggal] [datetime] NOT NULL,
	[DieditOleh] [varchar](20) NULL,
	[DieditTanggal] [datetime] NULL,
	[SystemStatus] [bit] NOT NULL,
 CONSTRAINT [PK_TbHistoricalUserLogin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TbHistoricalUserLogin] ADD  CONSTRAINT [DF_TbHistoricalUserLogin_IsMobile]  DEFAULT ((0)) FOR [IsMobile]
GO
ALTER TABLE [dbo].[TbHistoricalUserLogin] ADD  DEFAULT (getdate()) FOR [DibuatTanggal]
GO
ALTER TABLE [dbo].[TbHistoricalUserLogin] ADD  DEFAULT ((0)) FOR [SystemStatus]
GO
