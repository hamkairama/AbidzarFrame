SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- ============================================
CREATE PROCEDURE [dbo].[SpHistoricalUserLoginSelectByDate]
	@Nik varchar(16) = null,
	@Login datetime
AS
BEGIN TRANSACTION
BEGIN TRY
	SET NOCOUNT ON;
		DECLARE @TotalLogin int, @TotalUser int, @TotalIdle int
		SELECT @TotalUser = COUNT(*) FROM TbUser

			
		--get total login
		SELECT @TotalLogin = COUNT(DISTINCT NIK) FROM TbHistoricalUserLogin WHERE CAST(Login AS DATE) = CAST(GETDATE() AS DATE)

		--get total idle
		SET @TotalIdle  = (@TotalUser - @TotalLogin)

		create table #Temp
		(
			Header Varchar(50), 
			Total int, 
		) 

		INSERT INTO #Temp VALUES ('Login', @TotalLogin)
		INSERT INTO #Temp VALUES ('Idle', @TotalIdle)

		SELECT * FROM #Temp
COMMIT TRANSACTION
DROP TABLE #Temp	
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
    EXEC SP_GET_ERROR_INFO  
	SELECT ERROR_MESSAGE(), ERROR_NUMBER()
	DECLARE @tempError VARCHAR(500) = ERROR_MESSAGE()
	RAISERROR (@tempError, 16, 1)
	DROP TABLE #Temp	
END CATCH
GO
