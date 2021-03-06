SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbPollingPemilu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdDetailPemilu] [int] NOT NULL,
	[Nik] [varchar](16) NOT NULL,
	[DibuatOleh] [varchar](20) NOT NULL,
	[DibuatTanggal] [datetime] NOT NULL,
	[DieditOleh] [varchar](20) NULL,
	[DieditTanggal] [datetime] NULL,
	[SystemStatus] [bit] NOT NULL,
 CONSTRAINT [PK_TbPollingPemilu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TbPollingPemilu] ADD  DEFAULT (getdate()) FOR [DibuatTanggal]
GO
ALTER TABLE [dbo].[TbPollingPemilu] ADD  DEFAULT ((0)) FOR [SystemStatus]
GO
ALTER TABLE [dbo].[TbPollingPemilu]  WITH CHECK ADD  CONSTRAINT [FK_TbPollingPemilu_TbDetailPemilu] FOREIGN KEY([IdDetailPemilu])
REFERENCES [dbo].[TbDetailPemilu] ([Id])
GO
ALTER TABLE [dbo].[TbPollingPemilu] CHECK CONSTRAINT [FK_TbPollingPemilu_TbDetailPemilu]
GO
ALTER TABLE [dbo].[TbPollingPemilu]  WITH CHECK ADD  CONSTRAINT [FK_TbPollingPemilu_TbKtp] FOREIGN KEY([Nik])
REFERENCES [dbo].[TbKtp] ([Nik])
GO
ALTER TABLE [dbo].[TbPollingPemilu] CHECK CONSTRAINT [FK_TbPollingPemilu_TbKtp]
GO
