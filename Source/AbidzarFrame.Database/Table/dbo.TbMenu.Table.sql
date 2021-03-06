SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbMenu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NamaMenu] [varchar](100) NOT NULL,
	[ParentId] [int] NULL,
	[NamaParent] [varchar](100) NULL,
	[NamaIcon] [varchar](50) NULL,
	[MenuArea] [varchar](50) NULL,
	[MenuController] [varchar](50) NULL,
	[MenuAction] [varchar](50) NULL,
	[MenuLink] [varchar](150) NULL,
	[Sequence] [int] NULL,
	[DibuatOleh] [varchar](20) NOT NULL,
	[DibuatTanggal] [datetime] NOT NULL,
	[DieditOleh] [varchar](20) NULL,
	[DieditTanggal] [datetime] NULL,
	[SystemStatus] [bit] NOT NULL,
 CONSTRAINT [PK_TbMenu] PRIMARY KEY CLUSTERED 
(
	[NamaMenu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TbMenu] ADD  CONSTRAINT [DF_TbMenu_DibuatTanggal]  DEFAULT (getdate()) FOR [DibuatTanggal]
GO
ALTER TABLE [dbo].[TbMenu] ADD  CONSTRAINT [DF_TbMenu_SystemStatus]  DEFAULT ((0)) FOR [SystemStatus]
GO
