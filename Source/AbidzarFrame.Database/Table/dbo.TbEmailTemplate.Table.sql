SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbEmailTemplate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[KodeTemplate] [varchar](20) NOT NULL,
	[Template] [text] NOT NULL,
	[DibuatOleh] [varchar](20) NOT NULL,
	[DibuatTanggal] [datetime] NOT NULL,
	[DieditOleh] [varchar](20) NULL,
	[DieditTanggal] [datetime] NULL,
	[SystemStatus] [bit] NOT NULL,
 CONSTRAINT [PK_TbEmailTemplate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[KodeTemplate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[TbEmailTemplate] ADD  CONSTRAINT [DF_TbEmailTemplate_DibuatTanggal]  DEFAULT (getdate()) FOR [DibuatTanggal]
GO
ALTER TABLE [dbo].[TbEmailTemplate] ADD  CONSTRAINT [DF_TbEmailTemplate_SystemStatus]  DEFAULT ((0)) FOR [SystemStatus]
GO
