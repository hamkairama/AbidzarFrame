SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
  
-- =============================================  
-- Author:  Hamka Irama  
-- Create date: Agustus 2018  
-- Description: <Description,,>  
-- =============================================  
CREATE PROCEDURE [dbo].[SpKelurahanSelect]  
 @Id int,
 @IdKecamatan int = NULL   
AS  
BEGIN  
 SET NOCOUNT ON;  
   
 if @Id > 0  
  begin  
   select kelurahan.*, kecamatan.NamaKecamatan, kecamatan.IdKota, kota.NamaKota, kota.IdProvinsi, provinsi.NamaProvinsi  
   from TbKelurahan kelurahan  
   inner join TbKecamatan kecamatan on kecamatan.Id = kelurahan.IdKecamatan  
   INNER JOIN TbKota kota ON kota.Id = kecamatan.IdKota  
   INNER JOIN TbProvinsi provinsi ON provinsi.Id = kota.IdProvinsi  
   where kelurahan.Id = @Id  
  end  
 else  
  begin  
	if @IdKecamatan > 0
		begin
		   select kelurahan.*, kecamatan.NamaKecamatan, kecamatan.IdKota, kota.NamaKota, kota.IdProvinsi, provinsi.NamaProvinsi  
		   from TbKelurahan kelurahan  
		   inner join TbKecamatan kecamatan on kecamatan.Id = kelurahan.IdKecamatan  
		   INNER JOIN TbKota kota ON kota.Id = kecamatan.IdKota  
		   INNER JOIN TbProvinsi provinsi ON provinsi.Id = kota.IdProvinsi  
		   where kelurahan.IdKecamatan = @IdKecamatan
		end
	else
		begin
		   select kelurahan.*, kecamatan.NamaKecamatan, kecamatan.IdKota, kota.NamaKota, kota.IdProvinsi, provinsi.NamaProvinsi  
		   from TbKelurahan kelurahan  
		   inner join TbKecamatan kecamatan on kecamatan.Id = kelurahan.IdKecamatan  
		   INNER JOIN TbKota kota ON kota.Id = kecamatan.IdKota  
		   INNER JOIN TbProvinsi provinsi ON provinsi.Id = kota.IdProvinsi  
		end
   
  end  
  
END  
  
  
GO
