SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbJenisKelamin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JenisKelamin] [char](1) NOT NULL,
	[Deskripsi] [varchar](20) NOT NULL,
	[DibuatOleh] [varchar](20) NOT NULL,
	[DibuatTanggal] [datetime] NOT NULL,
	[DieditOleh] [varchar](20) NULL,
	[DieditTanggal] [datetime] NULL,
	[SystemStatus] [bit] NOT NULL,
 CONSTRAINT [PK_TbJenisKelamin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TbJenisKelamin] ADD  CONSTRAINT [DF__TbJenisKe__Dibua__66603565]  DEFAULT (getdate()) FOR [DibuatTanggal]
GO
ALTER TABLE [dbo].[TbJenisKelamin] ADD  CONSTRAINT [DF__TbJenisKe__Syste__6754599E]  DEFAULT ((0)) FOR [SystemStatus]
GO
