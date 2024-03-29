SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpLaporanKasUpdate]
	@Id int = null,
	@Deskripsi varchar(500),
	@Tanggal DateTime,
	@Total Decimal,
	@Tipe varchar(2),
	@DieditOleh varchar(20) = null
AS
BEGIN TRANSACTION
BEGIN TRY
	SET NOCOUNT ON;

	UPDATE TbLaporanKas SET Deskripsi = @Deskripsi, Tanggal = @Tanggal, Total = @Total, Tipe = @Tipe, DieditOleh = @DieditOleh, DieditTanggal = getdate() WHERE Id = @Id

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
