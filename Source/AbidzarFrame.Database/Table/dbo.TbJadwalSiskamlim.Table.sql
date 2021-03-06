SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbJadwalSiskamlim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nik] [varchar](20) NULL,
	[Nama] [varchar](100) NOT NULL,
	[Tanggal] [datetime] NOT NULL,
	[DibuatOleh] [varchar](20) NOT NULL,
	[DibuatTanggal] [datetime] NOT NULL,
	[DieditOleh] [varchar](20) NULL,
	[DieditTanggal] [datetime] NULL,
	[SystemStatus] [bit] NOT NULL
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TbJadwalSiskamlim] ADD  DEFAULT (getdate()) FOR [DibuatTanggal]
GO
ALTER TABLE [dbo].[TbJadwalSiskamlim] ADD  DEFAULT ((0)) FOR [SystemStatus]
GO
