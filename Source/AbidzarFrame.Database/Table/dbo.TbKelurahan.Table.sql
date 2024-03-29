SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbKelurahan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdKecamatan] [int] NOT NULL,
	[KodeKelurahan] [varchar](20) NOT NULL,
	[NamaKelurahan] [varchar](20) NOT NULL,
	[DibuatOleh] [varchar](20) NOT NULL,
	[DibuatTanggal] [datetime] NOT NULL,
	[DieditOleh] [varchar](20) NULL,
	[DieditTanggal] [datetime] NULL,
	[SystemStatus] [bit] NOT NULL,
 CONSTRAINT [PK_TbKelurahan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TbKelurahan] ADD  CONSTRAINT [DF__TbKelurah__Dibua__2F10007B]  DEFAULT (getdate()) FOR [DibuatTanggal]
GO
ALTER TABLE [dbo].[TbKelurahan] ADD  CONSTRAINT [DF__TbKelurah__Syste__300424B4]  DEFAULT ((0)) FOR [SystemStatus]
GO
ALTER TABLE [dbo].[TbKelurahan]  WITH CHECK ADD  CONSTRAINT [FK_TbKelurahan_TbKecamatan] FOREIGN KEY([IdKecamatan])
REFERENCES [dbo].[TbKecamatan] ([Id])
GO
ALTER TABLE [dbo].[TbKelurahan] CHECK CONSTRAINT [FK_TbKelurahan_TbKecamatan]
GO
