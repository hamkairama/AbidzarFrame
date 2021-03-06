SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpDetailJenisKegiatanUpdate]
	@Id int,
	@IdJenisKegiatan int,
	@NamaKegiatan varchar(100),
	@Deskripsi varchar(500),
	@Lokasi varchar(100),
	@TanggalKegiatan datetime,
	@DieditOleh varchar(20)
AS
BEGIN
	SET NOCOUNT ON;
	
	Update TbDetailJenisKegiatan set IdJenisKegiatan = @IdJenisKegiatan, NamaKegiatan = @NamaKegiatan, Deskripsi = @Deskripsi, Lokasi = @Lokasi, TanggalKegiatan = @TanggalKegiatan,
	DieditOleh = @DieditOleh, DieditTanggal = GETDATE() where Id = @Id

END



GO
