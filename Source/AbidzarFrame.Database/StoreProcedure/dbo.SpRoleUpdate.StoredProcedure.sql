SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpRoleUpdate]
	@IdRole varchar(20) = null,
	@NamaRole varchar(100) = null,
	@Deskripsi varchar(500) = null,
	@OrderRole int = null,
	@DieditOleh varchar(20) = null
AS
BEGIN TRANSACTION
BEGIN TRY
	SET NOCOUNT ON;

	UPDATE TbRole SET NamaRole = @NamaRole, Deskripsi = @Deskripsi, OrderRole = @OrderRole, DieditOleh = @DieditOleh, DieditTanggal = getdate() WHERE IdRole = @IdRole

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
