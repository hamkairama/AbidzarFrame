SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Create by	: Hamka
-- Create date	: 2018
-- Description	: delete role menu by role id
-- =============================================
CREATE PROCEDURE [dbo].[SpRoleMenuDelete] 
	@IdRole varchar(20)

AS
DECLARE @ERR int
BEGIN TRANSACTION ; 
BEGIN TRY

    DELETE FROM TbRoleMenu
    WHERE IdRole = @IdRole 
    
COMMIT TRANSACTION;
	
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
	EXEC SP_GET_ERROR_INFO 
	SELECT ERROR_MESSAGE(), ERROR_NUMBER()
	DECLARE @tempError VARCHAR(500) = ERROR_MESSAGE()
	RAISERROR (@tempError, 16, 1)
END CATCH
GO
