SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbJenisKegiatan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JenisKegiatan] [varchar](20) NOT NULL,
	[Deskripsi] [varchar](100) NULL,
	[DibuatOleh] [varchar](20) NOT NULL,
	[DibuatTanggal] [datetime] NOT NULL,
	[DieditOleh] [varchar](20) NULL,
	[DieditTanggal] [datetime] NULL,
	[SystemStatus] [bit] NOT NULL,
	[KodeRt] [varchar](20) NULL,
 CONSTRAINT [PK_TbJenisKegiatan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TbJenisKegiatan] ADD  CONSTRAINT [DF__TbJenisKe__Dibua__1DB06A4F]  DEFAULT (getdate()) FOR [DibuatTanggal]
GO
ALTER TABLE [dbo].[TbJenisKegiatan] ADD  CONSTRAINT [DF__TbJenisKe__Syste__1EA48E88]  DEFAULT ((0)) FOR [SystemStatus]
GO
