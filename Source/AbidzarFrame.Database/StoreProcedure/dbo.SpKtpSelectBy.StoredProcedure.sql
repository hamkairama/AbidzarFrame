SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpKtpSelectBy]
	@Nik varchar(16) = null,
	@Nama varchar (100) = null,
	@KodeRt varchar(20)

AS
BEGIN
	SET NOCOUNT ON;
	select ktp.*, jk.Deskripsi as JenisKelamin, kelurahan.NamaKelurahan, agama.NamaAgama, sp.StatusPerkawinan, pekerjaan.JenisPekerjaan, kw.JenisKewarganegaraan,
	gd.GolonganDarah, pendidikan.Pendidikan, photo.NamaFile as NamaFilePhoto, signat.NamaFile as NamaFileSignature, kecamatan.NamaKecamatan, kota.NamaKota, provinsi.NamaProvinsi,
	kota.Id as IdKota, kecamatan.id as IdKecamatan
	from TbKtp ktp
	inner join TbJenisKelamin jk on jk.Id = ktp.IdJenisKelamin
	inner join TbKelurahan kelurahan on kelurahan.Id = ktp.IdKelurahan
	inner join TbAgama agama on agama.Id = ktp.IdAgama
	inner join TbStatusPerkawinan sp on sp.Id = ktp.IdStatusPerkawinan
	inner join TbJenisPekerjaan pekerjaan on pekerjaan.Id = ktp.IdJenisPekerjaan
	inner join TbKewarganegaraan kw on kw.Id = ktp.IdKewarganegaraan
	inner join TbGolonganDarah gd on gd.Id = ktp.IdGolonganDarah
	inner join TbPendidikan pendidikan on pendidikan.Id = ktp.IdPendidikan
	left join TbPhotoKtp photo on photo.Id = ktp.IdPhotoKtp
	left join TbSignatureKtp signat on signat.Id = ktp.IdSignatureKtp
	inner join TbKecamatan kecamatan on kecamatan.Id = kelurahan.IdKecamatan
	inner join TbKota kota on kota.Id = kecamatan.IdKota
	inner join TbProvinsi provinsi on provinsi.Id = kota.IdProvinsi
	where (ktp.Nik like '%'+@Nik+'%' or @Nik is null)
	and (ktp.Nama like '%'+@Nama+'%' or @Nama is null)
	and KodeRt = @KodeRt
END



GO
