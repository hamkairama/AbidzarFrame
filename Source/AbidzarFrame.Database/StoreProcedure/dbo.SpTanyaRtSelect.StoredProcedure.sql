SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpTanyaRtSelect]
	@Id int,
	@KodeRt varchar(20) = null
AS
BEGIN TRANSACTION
BEGIN TRY
	SET NOCOUNT ON;

	IF @id > 0 
		BEGIN
			SELECT * 
			FROM TbTanyaRt tanya
			INNER JOIN TbKtp ktp on ktp.Nik = tanya.DibuatOleh
			WHERE tanya.Id = @Id and (ktp.KodeRt = @KodeRt or @KodeRt is null)
		END
	ELSE
		BEGIN
			SELECT * 
			FROM TbTanyaRt tanya
			INNER JOIN TbKtp ktp on ktp.Nik = tanya.DibuatOleh
			WHERE (ktp.KodeRt = @KodeRt or @KodeRt is null)
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
