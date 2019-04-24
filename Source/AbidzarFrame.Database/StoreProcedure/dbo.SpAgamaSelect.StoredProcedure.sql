SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpAgamaSelect]
	@Id int
AS
BEGIN TRANSACTION
BEGIN TRY
	SET NOCOUNT ON;

	IF @id > 0 
		BEGIN
			SELECT * FROM TbAgama WHERE Id = @Id
		END
	ELSE
		BEGIN
			SELECT * FROM TbAgama
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
