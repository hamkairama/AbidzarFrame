SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpRoleMenuSelect]
	@IdRole varchar(20) = null ,
	@IdMenu Varchar(20) = null
AS
BEGIN TRANSACTION
BEGIN TRY
	SET NOCOUNT ON;

	IF @IdRole IS NOT NULL
		BEGIN
			SELECT * FROM TbRoleMenu WHERE IdRole = @IdRole
		END
	ELSE
		BEGIN		
			SELECT * FROM TbRoleMenu
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
