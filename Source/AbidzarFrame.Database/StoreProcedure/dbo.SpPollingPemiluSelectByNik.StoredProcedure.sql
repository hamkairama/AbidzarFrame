SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- ============================================
CREATE PROCEDURE [dbo].[SpPollingPemiluSelectByNik]
	@Nik varchar(16),
	@IdPemilu int
AS
BEGIN TRANSACTION
BEGIN TRY
	SET NOCOUNT ON;
	SELECT PP.* FROM TbPollingPemilu  PP
	INNER JOIN TbDetailPemilu DP ON PP.IdDetailPemilu = DP.Id
	INNER JOIN TbPemilu P ON P.Id = DP.IdPemilu
	WHERE PP.Nik = @Nik AND P.Id = @IdPemilu
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
