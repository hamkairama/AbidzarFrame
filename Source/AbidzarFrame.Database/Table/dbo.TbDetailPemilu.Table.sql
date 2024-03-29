SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbDetailPemilu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPemilu] [int] NOT NULL,
	[NoUrut] [int] NOT NULL,
	[Kandidat] [varchar](100) NOT NULL,
	[FileName] [varchar](500) NULL,
	[DibuatOleh] [varchar](20) NOT NULL,
	[DibuatTanggal] [datetime] NOT NULL,
	[DieditOleh] [varchar](20) NULL,
	[DieditTanggal] [datetime] NULL,
	[SystemStatus] [bit] NOT NULL,
 CONSTRAINT [PK_TbDetailPemilu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TbDetailPemilu] ADD  CONSTRAINT [DF__TbDetailP__Dibua__12E8C319]  DEFAULT (getdate()) FOR [DibuatTanggal]
GO
ALTER TABLE [dbo].[TbDetailPemilu] ADD  CONSTRAINT [DF__TbDetailP__Syste__13DCE752]  DEFAULT ((0)) FOR [SystemStatus]
GO
ALTER TABLE [dbo].[TbDetailPemilu]  WITH CHECK ADD  CONSTRAINT [FK_TbDetailPemilu_TbPemilu] FOREIGN KEY([IdPemilu])
REFERENCES [dbo].[TbPemilu] ([Id])
GO
ALTER TABLE [dbo].[TbDetailPemilu] CHECK CONSTRAINT [FK_TbDetailPemilu_TbPemilu]
GO
