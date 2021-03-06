SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbKtp](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nik] [varchar](16) NOT NULL,
	[Nama] [varchar](100) NOT NULL,
	[TempatLahir] [varchar](100) NOT NULL,
	[TanggalLahir] [datetime] NOT NULL,
	[IdJenisKelamin] [int] NOT NULL,
	[Alamat] [varchar](200) NOT NULL,
	[IdKelurahan] [int] NOT NULL,
	[Rt] [varchar](3) NOT NULL,
	[Rw] [varchar](3) NOT NULL,
	[IdAgama] [int] NOT NULL,
	[IdStatusPerkawinan] [int] NOT NULL,
	[TanggalPerkawinan] [datetime] NULL,
	[IdJenisPekerjaan] [int] NOT NULL,
	[IdKewarganegaraan] [int] NOT NULL,
	[IdGolonganDarah] [int] NOT NULL,
	[IdPendidikan] [int] NOT NULL,
	[IdPhotoKtp] [int] NULL,
	[IdSignatureKtp] [int] NULL,
	[KodePos] [varchar](5) NOT NULL,
	[NamaAyah] [varchar](100) NOT NULL,
	[NamaIbu] [varchar](100) NOT NULL,
	[Kk] [varchar](16) NULL,
	[DibuatOleh] [varchar](20) NOT NULL,
	[DibuatTanggal] [datetime] NOT NULL,
	[DieditOleh] [varchar](20) NULL,
	[DieditTanggal] [datetime] NULL,
	[SystemStatus] [bit] NOT NULL,
	[KodeRt] [varchar](20) NULL,
 CONSTRAINT [PK_TbKtp_1] PRIMARY KEY CLUSTERED 
(
	[Nik] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TbKtp] ADD  CONSTRAINT [DF__TbKtp__DibuatTan__5EBF139D]  DEFAULT (getdate()) FOR [DibuatTanggal]
GO
ALTER TABLE [dbo].[TbKtp] ADD  CONSTRAINT [DF__TbKtp__SystemSta__5FB337D6]  DEFAULT ((0)) FOR [SystemStatus]
GO
ALTER TABLE [dbo].[TbKtp]  WITH CHECK ADD  CONSTRAINT [FK_TbKtp_TbGolonganDarah] FOREIGN KEY([IdGolonganDarah])
REFERENCES [dbo].[TbGolonganDarah] ([Id])
GO
ALTER TABLE [dbo].[TbKtp] CHECK CONSTRAINT [FK_TbKtp_TbGolonganDarah]
GO
ALTER TABLE [dbo].[TbKtp]  WITH CHECK ADD  CONSTRAINT [FK_TbKtp_TbJenisKelamin] FOREIGN KEY([IdJenisKelamin])
REFERENCES [dbo].[TbJenisKelamin] ([Id])
GO
ALTER TABLE [dbo].[TbKtp] CHECK CONSTRAINT [FK_TbKtp_TbJenisKelamin]
GO
ALTER TABLE [dbo].[TbKtp]  WITH CHECK ADD  CONSTRAINT [FK_TbKtp_TbJenisPekerjaan] FOREIGN KEY([IdJenisPekerjaan])
REFERENCES [dbo].[TbJenisPekerjaan] ([Id])
GO
ALTER TABLE [dbo].[TbKtp] CHECK CONSTRAINT [FK_TbKtp_TbJenisPekerjaan]
GO
ALTER TABLE [dbo].[TbKtp]  WITH CHECK ADD  CONSTRAINT [FK_TbKtp_TbKelurahan] FOREIGN KEY([IdKelurahan])
REFERENCES [dbo].[TbKelurahan] ([Id])
GO
ALTER TABLE [dbo].[TbKtp] CHECK CONSTRAINT [FK_TbKtp_TbKelurahan]
GO
ALTER TABLE [dbo].[TbKtp]  WITH CHECK ADD  CONSTRAINT [FK_TbKtp_TbKewarganegaraan] FOREIGN KEY([IdKewarganegaraan])
REFERENCES [dbo].[TbKewarganegaraan] ([Id])
GO
ALTER TABLE [dbo].[TbKtp] CHECK CONSTRAINT [FK_TbKtp_TbKewarganegaraan]
GO
ALTER TABLE [dbo].[TbKtp]  WITH CHECK ADD  CONSTRAINT [FK_TbKtp_TbPendidikan] FOREIGN KEY([IdPendidikan])
REFERENCES [dbo].[TbPendidikan] ([Id])
GO
ALTER TABLE [dbo].[TbKtp] CHECK CONSTRAINT [FK_TbKtp_TbPendidikan]
GO
ALTER TABLE [dbo].[TbKtp]  WITH CHECK ADD  CONSTRAINT [FK_TbKtp_TbPhotoKtp] FOREIGN KEY([IdPhotoKtp])
REFERENCES [dbo].[TbPhotoKtp] ([Id])
GO
ALTER TABLE [dbo].[TbKtp] CHECK CONSTRAINT [FK_TbKtp_TbPhotoKtp]
GO
ALTER TABLE [dbo].[TbKtp]  WITH CHECK ADD  CONSTRAINT [FK_TbKtp_TbSignatureKtp] FOREIGN KEY([IdSignatureKtp])
REFERENCES [dbo].[TbSignatureKtp] ([Id])
GO
ALTER TABLE [dbo].[TbKtp] CHECK CONSTRAINT [FK_TbKtp_TbSignatureKtp]
GO
ALTER TABLE [dbo].[TbKtp]  WITH CHECK ADD  CONSTRAINT [FK_TbKtp_TbStatusPerkawinan] FOREIGN KEY([IdStatusPerkawinan])
REFERENCES [dbo].[TbStatusPerkawinan] ([Id])
GO
ALTER TABLE [dbo].[TbKtp] CHECK CONSTRAINT [FK_TbKtp_TbStatusPerkawinan]
GO
