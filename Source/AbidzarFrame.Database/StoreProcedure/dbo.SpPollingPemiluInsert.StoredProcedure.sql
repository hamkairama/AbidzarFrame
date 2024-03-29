SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SpPollingPemiluInsert]	
	@IdDetailPemilu int ,
	@Nik varchar(200),
	@DibuatOleh varchar(20)
AS
BEGIN TRANSACTION
BEGIN TRY
	SET NOCOUNT ON;

	INSERT INTO TbPollingPemilu (IdDetailPemilu, Nik, DibuatOleh) VALUES (@IdDetailPemilu, @Nik, @DibuatOleh)
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
