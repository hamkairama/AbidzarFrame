SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpDetailPemiluUpdate]
	@Id int = null,
	@IdPemilu int ,
	@NoUrut int,
	@Kandidat varchar(200),
	@FileName varchar(500) = null,
	@DieditOleh varchar(20) = null
AS
BEGIN TRANSACTION
BEGIN TRY
	SET NOCOUNT ON;

	UPDATE TbDetailPemilu SET @IdPemilu = @IdPemilu, NoUrut = @NoUrut, Kandidat = @Kandidat, FileName = @FileName, DieditOleh = @DieditOleh, DieditTanggal = getdate() WHERE Id = @Id

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
