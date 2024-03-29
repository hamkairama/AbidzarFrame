SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpTanyaRtDetailSelectByIdTanyaRt]
	@IdTanyaRt int
AS
BEGIN TRANSACTION
BEGIN TRY
	SET NOCOUNT ON;

	SELECT tanyaDetail.*, ktp.Nama, photo.NamaFile
	FROM TbTanyaRtDetail tanyaDetail
	INNER JOIN TbTanyaRt tanya on tanya.Id = tanyaDetail.IdTanyaRt
	INNER JOIN TbKtp ktp on ktp.Nik = tanya.DibuatOleh
	INNER JOIN TbPhotoKtp photo on photo.Id = ktp.IdPhotoKtp
	WHERE tanyaDetail.IdTanyaRt = @IdTanyaRt

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
