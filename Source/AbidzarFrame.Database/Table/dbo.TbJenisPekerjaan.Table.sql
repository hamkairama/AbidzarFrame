SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbJenisPekerjaan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JenisPekerjaan] [varchar](100) NOT NULL,
	[DibuatOleh] [varchar](20) NOT NULL,
	[DibuatTanggal] [datetime] NOT NULL,
	[DieditOleh] [varchar](20) NULL,
	[DieditTanggal] [datetime] NULL,
	[SystemStatus] [bit] NOT NULL,
 CONSTRAINT [PK_TbJenisPekerjaan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TbJenisPekerjaan] ADD  CONSTRAINT [DF__TbJenisPe__Dibua__403A8C7D]  DEFAULT (getdate()) FOR [DibuatTanggal]
GO
ALTER TABLE [dbo].[TbJenisPekerjaan] ADD  CONSTRAINT [DF__TbJenisPe__Syste__412EB0B6]  DEFAULT ((0)) FOR [SystemStatus]
GO
