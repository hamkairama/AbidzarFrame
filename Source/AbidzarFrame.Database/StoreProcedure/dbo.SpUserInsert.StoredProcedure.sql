SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpUserInsert]
	@Nik varchar(16) = null,
	@Sandi varchar(max) = null,
	@Email varchar(20) = null,
	@IsMobile bit = null,
	@IdRole varchar(20) = null,
	@Status bit,
	@DibuatOleh varchar(20) = null
AS
BEGIN TRANSACTION
BEGIN TRY
	SET NOCOUNT ON;

	INSERT INTO TbUser (Nik, Sandi, Email, KodeVerifikasi, IsMobile, IdRole, Status, DibuatOleh) VALUES (@Nik, @Sandi, @Email, NEWID(), @IsMobile, @IdRole, @Status, @DibuatOleh)

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
