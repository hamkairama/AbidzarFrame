SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpLaporanKasInsert]
	@Deskripsi varchar(500),
	@Tanggal DateTime,
	@Total Decimal,
	@Tipe varchar(2),
	@DibuatOleh varchar(20),
	@KodeRt varchar(20)
AS
BEGIN TRANSACTION
BEGIN TRY
	SET NOCOUNT ON;

	INSERT INTO TbLaporanKas (Deskripsi, Tanggal, Total, Tipe, DibuatOleh, KodeRt) 
	VALUES (@Deskripsi, @Tanggal, @Total, @Tipe, @DibuatOleh, @KodeRt)
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
