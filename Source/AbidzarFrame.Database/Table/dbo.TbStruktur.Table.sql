SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbStruktur](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdKtp] [varchar](16) NOT NULL,
	[IdJabatan] [int] NOT NULL,
	[AwalPeriode] [datetime] NOT NULL,
	[AkhirPeriode] [datetime] NOT NULL,
	[DibuatOleh] [varchar](20) NOT NULL,
	[DibuatTanggal] [datetime] NOT NULL,
	[DieditOleh] [varchar](20) NULL,
	[DieditTanggal] [datetime] NULL,
	[SystemStatus] [bit] NOT NULL,
 CONSTRAINT [PK_TbStruktur] PRIMARY KEY CLUSTERED 
(
	[IdKtp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TbStruktur] ADD  CONSTRAINT [DF__TbStruktu__Dibua__19DFD96B]  DEFAULT (getdate()) FOR [DibuatTanggal]
GO
ALTER TABLE [dbo].[TbStruktur] ADD  CONSTRAINT [DF__TbStruktu__Syste__1AD3FDA4]  DEFAULT ((0)) FOR [SystemStatus]
GO
ALTER TABLE [dbo].[TbStruktur]  WITH CHECK ADD  CONSTRAINT [FK_TbStruktur_TbJabatan] FOREIGN KEY([IdJabatan])
REFERENCES [dbo].[TbJabatan] ([Id])
GO
ALTER TABLE [dbo].[TbStruktur] CHECK CONSTRAINT [FK_TbStruktur_TbJabatan]
GO
