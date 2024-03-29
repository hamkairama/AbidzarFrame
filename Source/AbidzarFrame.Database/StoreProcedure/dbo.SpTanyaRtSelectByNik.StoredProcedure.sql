SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpTanyaRtSelectByNik]
	@Nik varchar(16),
	@KodeRt varchar(20)
AS
BEGIN TRANSACTION
BEGIN TRY
	SET NOCOUNT ON;

	DECLARE @IsKetua varchar(20)

	SELECT @IsKetua = jabatan.NamaJabatan
	FROM TbStruktur struktur
	INNER JOIN TbJabatan jabatan ON jabatan.Id = struktur.IdJabatan
	WHERE struktur.IdKtp = @Nik

	IF UPPER(@IsKetua) = 'KETUA'
		BEGIN
			SELECT tanya.*, ktp.Nama, photo.NamaFile
			FROM TbTanyaRt tanya
			INNER JOIN TbKtp ktp on ktp.Nik = tanya.DibuatOleh
			INNER JOIN TbPhotoKtp photo on photo.Id = ktp.IdPhotoKtp
			WHERE ktp.KodeRt = @KodeRt
		END
	ELSE
		BEGIN			
			SELECT tanya.*, ktp.Nama, photo.NamaFile
			FROM TbTanyaRt tanya
			INNER JOIN TbKtp ktp on ktp.Nik = tanya.DibuatOleh
			INNER JOIN TbPhotoKtp photo on photo.Id = ktp.IdPhotoKtp
			WHERE tanya.DibuatOleh = @Nik and ktp.KodeRt = @KodeRt
		END
COMMIT TRANSACTION
	
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
    EXEC SP_GET_ERROR_INFO  
	SELECT ERROR_MESSAGE(), ERROR_NUMBER()
	DECLARE @tempError VARCHAR(500) = ERROR_MESSAGE()
	RAISERROR (@tempError, 16, 1)
END CATCH
GO
