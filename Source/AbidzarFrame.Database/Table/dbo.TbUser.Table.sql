SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nik] [varchar](16) NOT NULL,
	[Sandi] [varchar](max) NOT NULL,
	[Email] [varchar](200) NOT NULL,
	[Status] [bit] NOT NULL,
	[KodeVerifikasi] [uniqueidentifier] NOT NULL,
	[IsMobile] [bit] NOT NULL,
	[IdRole] [varchar](20) NULL,
	[DibuatOleh] [varchar](20) NOT NULL,
	[DibuatTanggal] [datetime] NOT NULL,
	[DieditOleh] [varchar](20) NULL,
	[DieditTanggal] [datetime] NULL,
	[SystemStatus] [bit] NOT NULL,
 CONSTRAINT [PK_TbUser] PRIMARY KEY CLUSTERED 
(
	[Nik] ASC,
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[TbUser] ADD  CONSTRAINT [DF_TbUser_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[TbUser] ADD  CONSTRAINT [DF_TbUser_IsMobile]  DEFAULT ((0)) FOR [IsMobile]
GO
ALTER TABLE [dbo].[TbUser] ADD  CONSTRAINT [DF_TbUser_DibuatTanggal]  DEFAULT (getdate()) FOR [DibuatTanggal]
GO
ALTER TABLE [dbo].[TbUser] ADD  CONSTRAINT [DF_TbUser_SystemStatus]  DEFAULT ((0)) FOR [SystemStatus]
GO
