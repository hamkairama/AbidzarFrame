SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbUserApi](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NamaApi] [varchar](200) NOT NULL,
	[IdUser] [varchar](20) NOT NULL,
	[Sandi] [varchar](200) NOT NULL,
	[Status] [bit] NOT NULL,
	[DibuatOleh] [varchar](20) NOT NULL,
	[DibuatTanggal] [datetime] NOT NULL,
	[DieditOleh] [varchar](20) NULL,
	[DieditTanggal] [datetime] NULL,
	[SystemStatus] [bit] NOT NULL,
 CONSTRAINT [PK_TbUserApi] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[NamaApi] ASC,
	[IdUser] ASC,
	[Sandi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TbUserApi] ADD  CONSTRAINT [DF_TbUserApi_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[TbUserApi] ADD  CONSTRAINT [DF_TbUserApi_DibuatTanggal]  DEFAULT (getdate()) FOR [DibuatTanggal]
GO
ALTER TABLE [dbo].[TbUserApi] ADD  CONSTRAINT [DF_TbUserApi_SystemStatus]  DEFAULT ((0)) FOR [SystemStatus]
GO
