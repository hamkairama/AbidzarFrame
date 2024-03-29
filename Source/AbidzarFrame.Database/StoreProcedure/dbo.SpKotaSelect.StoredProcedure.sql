SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpKotaSelect]
	@Id int,
	@IdProvinsi int = null
AS
BEGIN TRANSACTION
BEGIN TRY
	SET NOCOUNT ON;

	IF @Id > 0
		BEGIN
			SELECT kota.*, provinsi.NamaProvinsi
			FROM TbKota kota
			INNER JOIN TbProvinsi provinsi ON provinsi.Id = kota.IdProvinsi
			WHERE kota.Id = @Id
		END
	ELSE
		BEGIN
			IF @IdProvinsi > 0
				BEGIN
					SELECT kota.*, provinsi.NamaProvinsi
					FROM TbKota kota
					INNER JOIN TbProvinsi provinsi ON provinsi.Id = kota.IdProvinsi			
					WHERE kota.IdProvinsi = @IdProvinsi
				END
			ELSE
				BEGIN
					SELECT kota.*, provinsi.NamaProvinsi
					FROM TbKota kota
					INNER JOIN TbProvinsi provinsi ON provinsi.Id = kota.IdProvinsi	
				END
			
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
