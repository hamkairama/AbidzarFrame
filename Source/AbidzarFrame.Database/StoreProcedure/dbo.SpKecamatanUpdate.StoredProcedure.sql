SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpKecamatanUpdate]
	@Id int  = null,
	@IdKota int  = null,
	@KodeKecamatan varchar(20)  = null,
	@NamaKecamatan varchar(20)  = null,
	@DieditOleh varchar(20)  = null
AS
BEGIN TRANSACTION
BEGIN TRY
	SET NOCOUNT ON;
	
	update TbKecamatan set IdKota = @IdKota, KodeKecamatan = @KodeKecamatan, NamaKecamatan = @NamaKecamatan, DieditOleh = @DieditOleh, DieditTanggal = GETDATE() where Id = @Id
	
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
