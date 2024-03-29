SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpKtpUpdate]
	@Id int = null,
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
	@DieditOleh varchar(20) = null

AS
BEGIN TRANSACTION
BEGIN TRY
	SET NOCOUNT ON;

	UPDATE TbKtp SET Nik = @Nik, Nama = @Nama, TempatLahir = @TempatLahir, TanggalLahir = @TanggalLahir, IdJenisKelamin = @IdJenisKelamin, Alamat = @Alamat, 
	IdKelurahan = @IdKelurahan, Rt = @Rt, Rw = @Rw, IdAgama = @IdAgama, IdStatusPerkawinan = @IdStatusPerkawinan, TanggalPerkawinan = @TanggalPerkawinan, IdJenisPekerjaan = @IdJenisPekerjaan, 
	IdKewarganegaraan = @IdKewarganegaraan, IdGolonganDarah = @IdGolonganDarah, IdPendidikan = @IdPendidikan, IdPhotoKtp = @IdPhotoKtp, IdSignatureKtp = @IdSignatureKtp,
	KodePos = @KodePos, NamaAyah = @NamaAyah, NamaIbu = @NamaIbu, DieditOleh = @DieditOleh, DieditTanggal = GETDATE() WHERE Id = @Id
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
