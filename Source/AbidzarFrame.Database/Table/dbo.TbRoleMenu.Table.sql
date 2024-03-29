SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbRoleMenu](
	[IdRole] [varchar](20) NOT NULL,
	[IdMenu] [int] NOT NULL,
	[DibuatOleh] [varchar](20) NOT NULL,
	[DibuatTanggal] [datetime] NOT NULL,
	[DieditOleh] [varchar](20) NULL,
	[DieditTanggal] [datetime] NULL,
	[SystemStatus] [bit] NOT NULL
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TbRoleMenu] ADD  CONSTRAINT [DF_TbRoleMenu_DibuatTanggal]  DEFAULT (getdate()) FOR [DibuatTanggal]
GO
ALTER TABLE [dbo].[TbRoleMenu] ADD  CONSTRAINT [DF_TbRoleMenu_SystemStatus]  DEFAULT ((0)) FOR [SystemStatus]
GO
