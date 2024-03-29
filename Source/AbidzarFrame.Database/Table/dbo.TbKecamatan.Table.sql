SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbKecamatan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdKota] [int] NOT NULL,
	[KodeKecamatan] [varchar](20) NOT NULL,
	[NamaKecamatan] [varchar](20) NOT NULL,
	[DibuatOleh] [varchar](20) NOT NULL,
	[DibuatTanggal] [datetime] NOT NULL,
	[DieditOleh] [varchar](20) NULL,
	[DieditTanggal] [datetime] NULL,
	[SystemStatus] [bit] NOT NULL,
 CONSTRAINT [PK_TbKecamatan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TbKecamatan] ADD  CONSTRAINT [DF__TbKecamat__Dibua__2B3F6F97]  DEFAULT (getdate()) FOR [DibuatTanggal]
GO
ALTER TABLE [dbo].[TbKecamatan] ADD  CONSTRAINT [DF__TbKecamat__Syste__2C3393D0]  DEFAULT ((0)) FOR [SystemStatus]
GO
ALTER TABLE [dbo].[TbKecamatan]  WITH CHECK ADD  CONSTRAINT [FK_TbKecamatan_TbKota] FOREIGN KEY([IdKota])
REFERENCES [dbo].[TbKota] ([Id])
GO
ALTER TABLE [dbo].[TbKecamatan] CHECK CONSTRAINT [FK_TbKecamatan_TbKota]
GO
