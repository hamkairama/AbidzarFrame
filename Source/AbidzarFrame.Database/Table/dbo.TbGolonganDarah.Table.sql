SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbGolonganDarah](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GolonganDarah] [varchar](2) NOT NULL,
	[DibuatOleh] [varchar](20) NOT NULL,
	[DibuatTanggal] [datetime] NOT NULL,
	[DieditOleh] [varchar](20) NULL,
	[DieditTanggal] [datetime] NULL,
	[SystemStatus] [bit] NOT NULL,
 CONSTRAINT [PK_TbGolonganDarah] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TbGolonganDarah] ADD  CONSTRAINT [DF__TbGolonga__Dibua__4CA06362]  DEFAULT (getdate()) FOR [DibuatTanggal]
GO
ALTER TABLE [dbo].[TbGolonganDarah] ADD  CONSTRAINT [DF__TbGolonga__Syste__4D94879B]  DEFAULT ((0)) FOR [SystemStatus]
GO
