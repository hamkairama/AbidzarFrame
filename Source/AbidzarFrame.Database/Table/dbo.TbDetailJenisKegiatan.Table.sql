SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbDetailJenisKegiatan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdJenisKegiatan] [int] NOT NULL,
	[NamaKegiatan] [varchar](100) NOT NULL,
	[Lokasi] [varchar](100) NOT NULL,
	[Deskripsi] [varchar](500) NOT NULL,
	[TanggalKegiatan] [datetime] NOT NULL,
	[DibuatOleh] [varchar](20) NOT NULL,
	[DibuatTanggal] [datetime] NOT NULL,
	[DieditOleh] [varchar](20) NULL,
	[DieditTanggal] [datetime] NULL,
	[SystemStatus] [bit] NOT NULL,
 CONSTRAINT [PK_TbDetailJenisKegiatan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TbDetailJenisKegiatan] ADD  DEFAULT (getdate()) FOR [DibuatTanggal]
GO
ALTER TABLE [dbo].[TbDetailJenisKegiatan] ADD  DEFAULT ((0)) FOR [SystemStatus]
GO
ALTER TABLE [dbo].[TbDetailJenisKegiatan]  WITH CHECK ADD  CONSTRAINT [FK_TbDetailJenisKegiatan_TbJenisKegiatan] FOREIGN KEY([IdJenisKegiatan])
REFERENCES [dbo].[TbJenisKegiatan] ([Id])
GO
ALTER TABLE [dbo].[TbDetailJenisKegiatan] CHECK CONSTRAINT [FK_TbDetailJenisKegiatan_TbJenisKegiatan]
GO
