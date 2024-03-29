SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbRole](
	[IdRole] [varchar](20) NOT NULL,
	[NamaRole] [varchar](100) NOT NULL,
	[Deskripsi] [varchar](500) NULL,
	[OrderRole] [int] NULL,
	[DibuatOleh] [varchar](20) NOT NULL,
	[DibuatTanggal] [datetime] NOT NULL,
	[DieditOleh] [varchar](20) NULL,
	[DieditTanggal] [datetime] NULL,
	[SystemStatus] [bit] NOT NULL,
 CONSTRAINT [PK_TbRole] PRIMARY KEY CLUSTERED 
(
	[IdRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TbRole] ADD  CONSTRAINT [DF_TbRole_DibuatTanggal]  DEFAULT (getdate()) FOR [DibuatTanggal]
GO
ALTER TABLE [dbo].[TbRole] ADD  CONSTRAINT [DF_TbRole_SystemStatus]  DEFAULT ((0)) FOR [SystemStatus]
GO
