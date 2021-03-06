SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- ============================================
CREATE PROCEDURE [dbo].[SpPollingPemiluSelectGrafikByIdPemilu]
	@IdPemilu int
AS
BEGIN TRANSACTION
BEGIN TRY
	SET NOCOUNT ON;
	SELECT COUNT(*) AS Total, detailPemilu.Kandidat AS Header
	FROM TbPollingPemilu polling
	INNER JOIN TbDetailPemilu detailPemilu ON detailPemilu.id = polling.IdDetailPemilu
	INNER JOIN TbPemilu pemilu	ON pemilu.Id = detailPemilu.IdPemilu
	WHERE pemilu.Id = @IdPemilu
	GROUP BY detailPemilu.Kandidat 

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
