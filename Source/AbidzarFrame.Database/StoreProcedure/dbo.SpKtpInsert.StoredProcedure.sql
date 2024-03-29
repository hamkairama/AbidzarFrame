SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpKtpInsert]
	@Nik varchar(16) = null,
	@Nama varchar(20) = null,
	@TempatLahir varchar(20) = null,
	@TanggalLahir datetime  = null,
	@IdJenisKelamin int  = null,
	@IdKelurahan int = null,
	@Alamat varchar (200) = null,
	@Rt varchar(3) = null,
	@Rw varchar(3) = null,
	@IdAgama int = null,
	@IdStatusPerkawinan int  = null,
	@TanggalPerkawinan datetime = null,
	@IdJenisPekerjaan int = null,
	@IdKewarganegaraan int = null,	
	@IdGolonganDarah int = null,
	@IdPendidikan int = null,
	@IdPhotoKtp int = null,
	@IdSignatureKtp int = null,
	@KodePos int = null,
	@NamaAyah varchar(100) = null,
	@NamaIbu varchar(100) = null,
	@DibuatOleh varchar(20) = null,
	@KodeRt varchar(20)

AS
BEGIN TRANSACTION
BEGIN TRY
	SET NOCOUNT ON; 

	INSERT INTO TbPhotoKtp(NamaFile, DibuatOleh) 
	VALUES ('/Content/Layout/img/no-image.png', @DibuatOleh)

	SET @IdPhotoKtp = (SELECT MAX(Id) FROM TbPhotoKtp)

	INSERT INTO TbKtp(Nik, Nama, TempatLahir, TanggalLahir, IdJenisKelamin, Alamat, IdKelurahan, Rt, Rw, IdAgama, IdStatusPerkawinan,
	TanggalPerkawinan, IdJenisPekerjaan, IdKewarganegaraan, IdGolonganDarah, IdPendidikan, IdPhotoKtp, IdSignatureKtp, KodePos, NamaAyah, NamaIbu, DibuatOleh, KodeRt) 
	VALUES (@Nik, @nama, @TempatLahir, @TanggalLahir, @IdJenisKelamin, @alamat, @IdKelurahan, @Rt, @Rw, @IdAgama, @IdStatusPerkawinan, 
	@TanggalPerkawinan, @IdJenisPekerjaan, @IdKewarganegaraan, @IdGolonganDarah, @IdPendidikan, @IdPhotoKtp, @IdSignatureKtp, @KodePos, @NamaAyah, @NamaIbu, @DibuatOleh, @KodeRt)
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
