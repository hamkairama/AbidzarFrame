SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpUserSelect]
	@Nik varchar(16) = null,
	@Sandi varchar(max) = null
AS
BEGIN TRANSACTION
BEGIN TRY
	SET NOCOUNT ON;

	SELECT usr.* , ktp.Nama, photo.NamaFile, ktp.KodeRt
	FROM TbUser usr
	INNER JOIN TbKtp ktp on ktp.Nik = usr.Nik
	INNER JOIN TbPhotoKtp photo on photo.Id = ktp.IdPhotoKtp
	WHERE (usr.Nik = @Nik or @Nik is null) AND (usr.Sandi = @Sandi or @Sandi is null) --AND Status = 1

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
