SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpProvinsiUpdate]
	@Id int = null,
	@KodeProvinsi varchar(20) = null,
	@NamaProvinsi varchar(20) = null,
	@DieditOleh varchar(20)	= null
AS
BEGIN TRANSACTION
BEGIN TRY
	SET NOCOUNT ON;

	UPDATE TbProvinsi SET KodeProvinsi = @KodeProvinsi, NamaProvinsi = @NamaProvinsi, DieditOleh = @DieditOleh, DieditTanggal = GETDATE() WHERE Id = @Id
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
