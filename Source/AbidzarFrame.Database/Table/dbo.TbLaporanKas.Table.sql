SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbLaporanKas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Deskripsi] [varchar](500) NOT NULL,
	[Tanggal] [datetime] NOT NULL,
	[Total] [decimal](18, 0) NOT NULL,
	[Tipe] [varchar](2) NOT NULL,
	[DibuatOleh] [varchar](20) NOT NULL,
	[DibuatTanggal] [datetime] NOT NULL,
	[DieditOleh] [varchar](20) NULL,
	[DieditTanggal] [datetime] NULL,
	[SystemStatus] [bit] NOT NULL,
	[KodeRt] [varchar](20) NULL,
 CONSTRAINT [PK_TbLaporanKas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TbLaporanKas] ADD  CONSTRAINT [DF_TbLaporanKas_Tipe]  DEFAULT ((0)) FOR [Tipe]
GO
ALTER TABLE [dbo].[TbLaporanKas] ADD  DEFAULT (getdate()) FOR [DibuatTanggal]
GO
ALTER TABLE [dbo].[TbLaporanKas] ADD  DEFAULT ((0)) FOR [SystemStatus]
GO
