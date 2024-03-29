SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbDetailJenisInformasi](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdJenisInformasi] [int] NOT NULL,
	[Judul] [varchar](100) NULL,
	[NamaFile] [varchar](100) NULL,
	[Deskripsi] [text] NOT NULL,
	[DibuatOleh] [varchar](20) NOT NULL,
	[DibuatTanggal] [datetime] NOT NULL,
	[DieditOleh] [varchar](20) NULL,
	[DieditTanggal] [datetime] NULL,
	[SystemStatus] [bit] NOT NULL,
 CONSTRAINT [PK_TbDetailJenisInformasi] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[TbDetailJenisInformasi] ADD  CONSTRAINT [DF__TbDetailJ__Dibua__2CF2ADDF]  DEFAULT (getdate()) FOR [DibuatTanggal]
GO
ALTER TABLE [dbo].[TbDetailJenisInformasi] ADD  CONSTRAINT [DF__TbDetailJ__Syste__2DE6D218]  DEFAULT ((0)) FOR [SystemStatus]
GO
ALTER TABLE [dbo].[TbDetailJenisInformasi]  WITH CHECK ADD  CONSTRAINT [FK_TbDetailJenisInformasi_TbJenisInformasi] FOREIGN KEY([IdJenisInformasi])
REFERENCES [dbo].[TbJenisInformasi] ([Id])
GO
ALTER TABLE [dbo].[TbDetailJenisInformasi] CHECK CONSTRAINT [FK_TbDetailJenisInformasi_TbJenisInformasi]
GO
