SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
  
-- =============================================  
-- Author:  Hamka Irama  
-- Create date: Agustus 2018  
-- Description: <Description,,>  
-- =============================================  
CREATE PROCEDURE [dbo].[SpKecamatanSelect]  
 @Id int,
 @IdKota int  = null
AS  
BEGIN TRANSACTION  
BEGIN TRY  
 SET NOCOUNT ON;  
  
 IF @Id > 0   
  BEGIN  
   SELECT kecamatan.*, kota.NamaKota, kota.IdProvinsi, provinsi.NamaProvinsi   
   FROM TbKecamatan kecamatan  
   INNER JOIN TbKota kota ON kota.Id = kecamatan.IdKota  
   INNER JOIN TbProvinsi provinsi ON provinsi.Id = kota.IdProvinsi  
   WHERE kecamatan.Id = @Id  
  END  
 ELSE  
  BEGIN  
   IF @IdKota > 0
	BEGIN
	   SELECT kecamatan.*, kota.NamaKota, kota.IdProvinsi, provinsi.NamaProvinsi   
	   FROM TbKecamatan kecamatan  
	   INNER JOIN TbKota kota ON kota.Id = kecamatan.IdKota  
	   INNER JOIN TbProvinsi provinsi ON provinsi.Id = kota.IdProvinsi  
	   WHERE kecamatan.IdKota = @IdKota
	END
   ELSE
	BEGIN
	   SELECT kecamatan.*, kota.NamaKota, kota.IdProvinsi, provinsi.NamaProvinsi   
	   FROM TbKecamatan kecamatan  
	   INNER JOIN TbKota kota ON kota.Id = kecamatan.IdKota  
	   INNER JOIN TbProvinsi provinsi ON provinsi.Id = kota.IdProvinsi  
	END 
   
  END  
  
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
