SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpKotaInsert]
	@IdProvinsi int = null,
	@KodeKota varchar(20) = null,
	@NamaKota varchar(20) = null,
	@DibuatOleh varchar(20) = null	
AS
BEGIN TRANSACTION
BEGIN TRY
	SET NOCOUNT ON;

	INSERT INTO TbKota (IdProvinsi, KodeKota, NamaKota, DibuatOleh) VALUES (@IdProvinsi, @KodeKota, @NamaKota, @DibuatOleh)
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
