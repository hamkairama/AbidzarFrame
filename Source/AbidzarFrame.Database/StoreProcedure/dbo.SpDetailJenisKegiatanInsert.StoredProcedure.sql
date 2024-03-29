SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpDetailJenisKegiatanInsert]
	@IdJenisKegiatan int,
	@NamaKegiatan varchar(100),
	@Lokasi varchar(100),
	@Deskripsi varchar(500),
	@TanggalKegiatan datetime,
	@DibuatOleh varchar(20)
AS
BEGIN
	SET NOCOUNT ON;
	
	Insert into TbDetailJenisKegiatan (IdJenisKegiatan, NamaKegiatan, Lokasi, Deskripsi, TanggalKegiatan, DibuatOleh)
	values (@IdJenisKegiatan, @NamaKegiatan, @Lokasi, @Deskripsi, @TanggalKegiatan, @DibuatOleh)

END



GO
