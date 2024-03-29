SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbPemilu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Judul] [varchar](100) NOT NULL,
	[FileName] [varchar](500) NULL,
	[DibuatOleh] [varchar](20) NOT NULL,
	[DibuatTanggal] [datetime] NOT NULL,
	[DieditOleh] [varchar](20) NULL,
	[DieditTanggal] [datetime] NULL,
	[SystemStatus] [bit] NOT NULL,
	[KodeRt] [varchar](20) NULL,
 CONSTRAINT [PK_TbPemilu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TbPemilu] ADD  CONSTRAINT [DF__TbPemilu__Dibuat__100C566E]  DEFAULT (getdate()) FOR [DibuatTanggal]
GO
ALTER TABLE [dbo].[TbPemilu] ADD  CONSTRAINT [DF__TbPemilu__System__11007AA7]  DEFAULT ((0)) FOR [SystemStatus]
GO
