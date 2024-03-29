SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbKota](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdProvinsi] [int] NOT NULL,
	[KodeKota] [varchar](20) NOT NULL,
	[NamaKota] [varchar](20) NOT NULL,
	[DibuatOleh] [varchar](20) NOT NULL,
	[DibuatTanggal] [datetime] NOT NULL,
	[DieditOleh] [varchar](20) NULL,
	[DieditTanggal] [datetime] NULL,
	[SystemStatus] [bit] NOT NULL,
 CONSTRAINT [PK_TbKota] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TbKota] ADD  CONSTRAINT [DF__TbKota__DibuatTa__276EDEB3]  DEFAULT (getdate()) FOR [DibuatTanggal]
GO
ALTER TABLE [dbo].[TbKota] ADD  CONSTRAINT [DF__TbKota__SystemSt__286302EC]  DEFAULT ((0)) FOR [SystemStatus]
GO
ALTER TABLE [dbo].[TbKota]  WITH CHECK ADD  CONSTRAINT [FK_TbKota_TbProvinsi] FOREIGN KEY([IdProvinsi])
REFERENCES [dbo].[TbProvinsi] ([Id])
GO
ALTER TABLE [dbo].[TbKota] CHECK CONSTRAINT [FK_TbKota_TbProvinsi]
GO
