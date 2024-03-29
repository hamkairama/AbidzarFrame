SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpRoleSelect]
	@IdRole varchar(20) = null
AS
BEGIN TRANSACTION
BEGIN TRY
	SET NOCOUNT ON;

	IF @IdRole is not null 
		BEGIN
			SELECT * FROM TbRole WHERE IdRole = @IdRole
		END
	ELSE
		BEGIN
			SELECT * FROM TbRole
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
