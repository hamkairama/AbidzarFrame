SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbKewarganegaraan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JenisKewarganegaraan] [varchar](3) NOT NULL,
	[DibuatOleh] [varchar](20) NOT NULL,
	[DibuatTanggal] [datetime] NOT NULL,
	[DieditOleh] [varchar](20) NULL,
	[DieditTanggal] [datetime] NULL,
	[SystemStatus] [bit] NOT NULL,
 CONSTRAINT [PK_TbKewarganegaraan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TbKewarganegaraan] ADD  CONSTRAINT [DF__TbKewarga__Dibua__48CFD27E]  DEFAULT (getdate()) FOR [DibuatTanggal]
GO
ALTER TABLE [dbo].[TbKewarganegaraan] ADD  CONSTRAINT [DF__TbKewarga__Syste__49C3F6B7]  DEFAULT ((0)) FOR [SystemStatus]
GO
