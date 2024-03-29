SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpStrukturSelect]
	@Id int,
	@KodeRt varchar(20) = null
AS
BEGIN
	SET NOCOUNT ON;
	
	if @Id > 0
		begin
			select struktur.*, jabatan.NamaJabatan, ktp.Nama, ktp.Nik, photoKtp.NamaFile
			from TbStruktur struktur
			inner join TbJabatan jabatan on jabatan.Id = struktur.IdJabatan
			inner join TbKtp ktp on ktp.Nik = struktur.IdKtp
			left join TbPhotoKtp photoKtp on photoKtp.Id = ktp.IdPhotoKtp
			where struktur.Id = @Id and (ktp.KodeRt = @KodeRt or @KodeRt is null)
		end
	else	
		begin
			select struktur.*, jabatan.NamaJabatan, ktp.Nama, ktp.Nik, photoKtp.NamaFile
			from TbStruktur struktur
			inner join TbJabatan jabatan on jabatan.Id = struktur.IdJabatan
			inner join TbKtp ktp on ktp.Nik = struktur.IdKtp
			left join TbPhotoKtp photoKtp on photoKtp.Id = ktp.IdPhotoKtp
			where (ktp.KodeRt = @KodeRt or @KodeRt is null)
		end
END



GO
