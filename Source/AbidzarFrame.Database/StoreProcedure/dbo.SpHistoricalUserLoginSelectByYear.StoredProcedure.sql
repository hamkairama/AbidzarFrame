SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- ============================================
CREATE PROCEDURE [dbo].[SpHistoricalUserLoginSelectByYear]
	@Nik varchar(16) = null,
	@Login datetime
AS
BEGIN TRANSACTION
BEGIN TRY
	SET NOCOUNT ON;

	IF @Nik is not null 
		BEGIN
			SELECT COUNT(*) AS Total,  DATENAME(YEAR, LOGIN) AS Header, YEAR(LOGIN) AS ORDER_ID FROM TbHistoricalUserLogin 
			WHERE Nik = @Nik 
			GROUP BY DATENAME(YEAR, LOGIN), YEAR(LOGIN)
			ORDER BY YEAR(LOGIN)  ASC
		END
	ELSE
		BEGIN
			SELECT COUNT(*) AS Total,  DATENAME(YEAR, LOGIN)  AS Header, YEAR(LOGIN) AS ORDER_ID FROM TbHistoricalUserLogin 
			GROUP BY DATENAME(YEAR, LOGIN), YEAR(LOGIN)
			ORDER BY YEAR(LOGIN)  ASC
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
