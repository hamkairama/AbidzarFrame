SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbTanyaRtDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdTanyaRt] [int] NOT NULL,
	[Deskripsi] [text] NOT NULL,
	[DibuatOleh] [varchar](20) NOT NULL,
	[DibuatTanggal] [datetime] NOT NULL,
	[DieditOleh] [varchar](20) NULL,
	[DieditTanggal] [datetime] NULL,
	[SystemStatus] [bit] NOT NULL,
 CONSTRAINT [PK_TbTanyaRtDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[TbTanyaRtDetail] ADD  DEFAULT (getdate()) FOR [DibuatTanggal]
GO
ALTER TABLE [dbo].[TbTanyaRtDetail] ADD  DEFAULT ((0)) FOR [SystemStatus]
GO
ALTER TABLE [dbo].[TbTanyaRtDetail]  WITH CHECK ADD  CONSTRAINT [FK_TbTanyaRtDetail_TbTanyaRt] FOREIGN KEY([IdTanyaRt])
REFERENCES [dbo].[TbTanyaRt] ([Id])
GO
ALTER TABLE [dbo].[TbTanyaRtDetail] CHECK CONSTRAINT [FK_TbTanyaRtDetail_TbTanyaRt]
GO
