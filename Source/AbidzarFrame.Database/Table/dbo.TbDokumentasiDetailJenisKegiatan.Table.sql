SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbDokumentasiDetailJenisKegiatan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdDetailJenisKegiatan] [int] NOT NULL,
	[NamaFile] [varchar](500) NOT NULL,
	[DibuatOleh] [varchar](20) NOT NULL,
	[DibuatTanggal] [datetime] NOT NULL,
	[DieditOleh] [varchar](20) NULL,
	[DieditTanggal] [datetime] NULL,
	[SystemStatus] [bit] NOT NULL,
 CONSTRAINT [PK_TbDokumentasiDetailJenisKegiatan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TbDokumentasiDetailJenisKegiatan] ADD  CONSTRAINT [DF__TbDokumen__Dibua__25518C17]  DEFAULT (getdate()) FOR [DibuatTanggal]
GO
ALTER TABLE [dbo].[TbDokumentasiDetailJenisKegiatan] ADD  CONSTRAINT [DF__TbDokumen__Syste__2645B050]  DEFAULT ((0)) FOR [SystemStatus]
GO
ALTER TABLE [dbo].[TbDokumentasiDetailJenisKegiatan]  WITH CHECK ADD  CONSTRAINT [FK_TbDokumentasiDetailJenisKegiatan_TbDetailJenisKegiatan] FOREIGN KEY([IdDetailJenisKegiatan])
REFERENCES [dbo].[TbDetailJenisKegiatan] ([Id])
GO
ALTER TABLE [dbo].[TbDokumentasiDetailJenisKegiatan] CHECK CONSTRAINT [FK_TbDokumentasiDetailJenisKegiatan_TbDetailJenisKegiatan]
GO
