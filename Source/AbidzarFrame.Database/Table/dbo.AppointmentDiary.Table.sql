SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppointmentDiary](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[SomeImportantKey] [int] NULL,
	[DateTimeScheduled] [datetime] NOT NULL,
	[AppointmentLength] [int] NOT NULL,
	[StatusENUM] [int] NOT NULL,
	[DibuatOleh] [varchar](20) NOT NULL,
	[DibuatTanggal] [datetime] NOT NULL,
	[DieditOleh] [varchar](20) NULL,
	[DieditTanggal] [datetime] NULL,
	[SystemStatus] [bit] NOT NULL,
	[KodeRt] [varchar](20) NULL
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[AppointmentDiary] ADD  CONSTRAINT [DF__Appointme__Statu__7775B2CE]  DEFAULT ((0)) FOR [StatusENUM]
GO
ALTER TABLE [dbo].[AppointmentDiary] ADD  CONSTRAINT [DF__Appointme__Dibua__7869D707]  DEFAULT (getdate()) FOR [DibuatTanggal]
GO
ALTER TABLE [dbo].[AppointmentDiary] ADD  CONSTRAINT [DF__Appointme__Syste__795DFB40]  DEFAULT ((0)) FOR [SystemStatus]
GO
