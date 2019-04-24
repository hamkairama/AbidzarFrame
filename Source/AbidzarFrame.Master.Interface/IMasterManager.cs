using AbidzarFrame.Master.Interface.Dto;
using System.Collections.Generic;
using System.ServiceModel;


namespace AbidzarFrame.Master.Interface
{
    [ServiceContract()]
    public interface IMasterManager
    {
        #region Agama
        [OperationContract()]
        AgamaResponse GetAgamaFindBy(AgamaRequest request);

        [OperationContract()]
        AgamaResponse GetAgamaList(AgamaRequest request);

        [OperationContract()]
        AgamaResponse InsertAgama(AgamaRequest request);

        [OperationContract()]
        AgamaResponse UpdateAgama(AgamaRequest request);

        [OperationContract()]
        AgamaResponse DeleteAgama(AgamaRequest request);
        #endregion

        #region DetailJenisInformasi
        [OperationContract()]
        DetailJenisInformasiResponse GetDetailJenisInformasiFindBy(DetailJenisInformasiRequest request);

        [OperationContract()]
        DetailJenisInformasiResponse GetDetailJenisInformasiNewest(DetailJenisInformasiRequest request);

        [OperationContract()]
        DetailJenisInformasiResponse GetDetailJenisInformasiList(DetailJenisInformasiRequest request);

        [OperationContract()]
        DetailJenisInformasiResponse GetDetailJenisInformasiListByIdJenisInformasi(DetailJenisInformasiRequest request);

        [OperationContract()]
        DetailJenisInformasiResponse InsertDetailJenisInformasi(DetailJenisInformasiRequest request);

        [OperationContract()]
        DetailJenisInformasiResponse UpdateDetailJenisInformasi(DetailJenisInformasiRequest request);

        [OperationContract()]
        DetailJenisInformasiResponse DeleteDetailJenisInformasi(DetailJenisInformasiRequest request);
        #endregion

        #region DetailJenisKegiatan
        [OperationContract()]
        DetailJenisKegiatanResponse GetDetailJenisKegiatanFindBy(DetailJenisKegiatanRequest request);

        [OperationContract()]
        DetailJenisKegiatanResponse GetDetailJenisKegiatanList(DetailJenisKegiatanRequest request);

        [OperationContract()]
        DetailJenisKegiatanResponse GetDetailJenisKegiatanListByIdJenisKegiatan(DetailJenisKegiatanRequest request);

        [OperationContract()]
        DetailJenisKegiatanResponse InsertDetailJenisKegiatan(DetailJenisKegiatanRequest request);

        [OperationContract()]
        DetailJenisKegiatanResponse UpdateDetailJenisKegiatan(DetailJenisKegiatanRequest request);

        [OperationContract()]
        DetailJenisKegiatanResponse DeleteDetailJenisKegiatan(DetailJenisKegiatanRequest request);
        #endregion

        #region DokumentasiDetailJenisKegiatan
        [OperationContract()]
        DokumentasiDetailJenisKegiatanResponse GetDokumentasiDetailJenisKegiatanFindBy(DokumentasiDetailJenisKegiatanRequest request);

        [OperationContract()]
        DokumentasiDetailJenisKegiatanResponse GetDokumentasiDetailJenisKegiatanList(DokumentasiDetailJenisKegiatanRequest request);

        [OperationContract()]
        DokumentasiDetailJenisKegiatanResponse GetDokumentasiDetailJenisKegiatanListByIdDetailJenisKegiatan(DokumentasiDetailJenisKegiatanRequest request);

        [OperationContract()]
        DokumentasiDetailJenisKegiatanResponse InsertDokumentasiDetailJenisKegiatan(DokumentasiDetailJenisKegiatanRequest request);

        [OperationContract()]
        DokumentasiDetailJenisKegiatanResponse UpdateDokumentasiDetailJenisKegiatan(DokumentasiDetailJenisKegiatanRequest request);

        [OperationContract()]
        DokumentasiDetailJenisKegiatanResponse DeleteDokumentasiDetailJenisKegiatan(DokumentasiDetailJenisKegiatanRequest request);
        #endregion

        #region GolonganDarah
        [OperationContract()]
        GolonganDarahResponse GetGolonganDarahFindBy(GolonganDarahRequest request);

        [OperationContract()]
        GolonganDarahResponse GetGolonganDarahList(GolonganDarahRequest request);

        [OperationContract()]
        GolonganDarahResponse InsertGolonganDarah(GolonganDarahRequest request);

        [OperationContract()]
        GolonganDarahResponse UpdateGolonganDarah(GolonganDarahRequest request);

        [OperationContract()]
        GolonganDarahResponse DeleteGolonganDarah(GolonganDarahRequest request);
        #endregion      

        #region Jabatan
        [OperationContract()]
        JabatanResponse GetJabatanFindBy(JabatanRequest request);

        [OperationContract()]
        JabatanResponse GetJabatanList(JabatanRequest request);

        [OperationContract()]
        JabatanResponse InsertJabatan(JabatanRequest request);

        [OperationContract()]
        JabatanResponse UpdateJabatan(JabatanRequest request);

        [OperationContract()]
        JabatanResponse DeleteJabatan(JabatanRequest request);
        #endregion

        #region JenisInformasi
        [OperationContract()]
        JenisInformasiResponse GetJenisInformasiFindBy(JenisInformasiRequest request);

        [OperationContract()]
        JenisInformasiResponse GetJenisInformasiList(JenisInformasiRequest request);

        [OperationContract()]
        JenisInformasiResponse InsertJenisInformasi(JenisInformasiRequest request);

        [OperationContract()]
        JenisInformasiResponse UpdateJenisInformasi(JenisInformasiRequest request);

        [OperationContract()]
        JenisInformasiResponse DeleteJenisInformasi(JenisInformasiRequest request);
        #endregion

        #region JenisKegiatan
        [OperationContract()]
        JenisKegiatanResponse GetJenisKegiatanFindBy(JenisKegiatanRequest request);

        [OperationContract()]
        JenisKegiatanResponse GetJenisKegiatanList(JenisKegiatanRequest request);

        [OperationContract()]
        JenisKegiatanResponse InsertJenisKegiatan(JenisKegiatanRequest request);

        [OperationContract()]
        JenisKegiatanResponse UpdateJenisKegiatan(JenisKegiatanRequest request);

        [OperationContract()]
        JenisKegiatanResponse DeleteJenisKegiatan(JenisKegiatanRequest request);
        #endregion

        #region JenisKelamin
        [OperationContract()]
        JenisKelaminResponse GetJenisKelaminFindBy(JenisKelaminRequest request);

        [OperationContract()]
        JenisKelaminResponse GetJenisKelaminList(JenisKelaminRequest request);

        [OperationContract()]
        JenisKelaminResponse InsertJenisKelamin(JenisKelaminRequest request);

        [OperationContract()]
        JenisKelaminResponse UpdateJenisKelamin(JenisKelaminRequest request);

        [OperationContract()]
        JenisKelaminResponse DeleteJenisKelamin(JenisKelaminRequest request);
        #endregion

        #region JenisPekerjaan
        [OperationContract()]
        JenisPekerjaanResponse GetJenisPekerjaanFindBy(JenisPekerjaanRequest request);

        [OperationContract()]
        JenisPekerjaanResponse GetJenisPekerjaanList(JenisPekerjaanRequest request);

        [OperationContract()]
        JenisPekerjaanResponse InsertJenisPekerjaan(JenisPekerjaanRequest request);

        [OperationContract()]
        JenisPekerjaanResponse UpdateJenisPekerjaan(JenisPekerjaanRequest request);

        [OperationContract()]
        JenisPekerjaanResponse DeleteJenisPekerjaan(JenisPekerjaanRequest request);
        #endregion

        #region Kecamatan
        [OperationContract()]
        KecamatanResponse GetKecamatanFindBy(KecamatanRequest request);

        [OperationContract()]
        KecamatanResponse GetKecamatanList(KecamatanRequest request);

        [OperationContract()]
        KecamatanResponse InsertKecamatan(KecamatanRequest request);

        [OperationContract()]
        KecamatanResponse UpdateKecamatan(KecamatanRequest request);

        [OperationContract()]
        KecamatanResponse DeleteKecamatan(KecamatanRequest request);
        #endregion

        #region Kelurahan
        [OperationContract()]
        KelurahanResponse GetKelurahanFindBy(KelurahanRequest request);

        [OperationContract()]
        KelurahanResponse GetKelurahanList(KelurahanRequest request);

        [OperationContract()]
        KelurahanResponse InsertKelurahan(KelurahanRequest request);

        [OperationContract()]
        KelurahanResponse UpdateKelurahan(KelurahanRequest request);

        [OperationContract()]
        KelurahanResponse DeleteKelurahan(KelurahanRequest request);
        #endregion

        #region Kewarganegaraan
        [OperationContract()]
        KewarganegaraanResponse GetKewarganegaraanFindBy(KewarganegaraanRequest request);

        [OperationContract()]
        KewarganegaraanResponse GetKewarganegaraanList(KewarganegaraanRequest request);

        [OperationContract()]
        KewarganegaraanResponse InsertKewarganegaraan(KewarganegaraanRequest request);

        [OperationContract()]
        KewarganegaraanResponse UpdateKewarganegaraan(KewarganegaraanRequest request);

        [OperationContract()]
        KewarganegaraanResponse DeleteKewarganegaraan(KewarganegaraanRequest request);
        #endregion

        #region Kota
        [OperationContract()]
        KotaResponse GetKotaFindBy(KotaRequest request);

        [OperationContract()]
        KotaResponse GetKotaList(KotaRequest request);

        [OperationContract()]
        KotaResponse InsertKota(KotaRequest request);

        [OperationContract()]
        KotaResponse UpdateKota(KotaRequest request);

        [OperationContract()]
        KotaResponse DeleteKota(KotaRequest request);
        #endregion

        #region Ktp
        [OperationContract()]
        KtpResponse GetKtpFindBy(KtpRequest request);

        [OperationContract()]
        KtpResponse GetKtpList(KtpRequest request);

        [OperationContract()]
        KtpResponse GetKtpListBy(KtpRequest request);

        [OperationContract()]
        KtpResponse InsertKtp(KtpRequest request);

        [OperationContract()]
        KtpResponse UpdateKtp(KtpRequest request);

        [OperationContract()]
        KtpResponse DeleteKtp(KtpRequest request);
        #endregion

        #region Pendidikan
        [OperationContract()]
        PendidikanResponse GetPendidikanFindBy(PendidikanRequest request);

        [OperationContract()]
        PendidikanResponse GetPendidikanList(PendidikanRequest request);

        [OperationContract()]
        PendidikanResponse InsertPendidikan(PendidikanRequest request);

        [OperationContract()]
        PendidikanResponse UpdatePendidikan(PendidikanRequest request);

        [OperationContract()]
        PendidikanResponse DeletePendidikan(PendidikanRequest request);
        #endregion

        #region Provinsi
        [OperationContract()]
        ProvinsiResponse GetProvinsiFindBy(ProvinsiRequest request);

        [OperationContract()]
        ProvinsiResponse GetProvinsiList(ProvinsiRequest request);

        [OperationContract()]
        ProvinsiResponse InsertProvinsi(ProvinsiRequest request);

        [OperationContract()]
        ProvinsiResponse UpdateProvinsi(ProvinsiRequest request);

        [OperationContract()]
        ProvinsiResponse DeleteProvinsi(ProvinsiRequest request);
        #endregion

        #region SignatureKtp
        [OperationContract()]
        SignatureKtpResponse GetSignatureKtpFindBy(SignatureKtpRequest request);

        [OperationContract()]
        SignatureKtpResponse GetSignatureKtpList(SignatureKtpRequest request);

        [OperationContract()]
        SignatureKtpResponse InsertSignatureKtp(SignatureKtpRequest request);

        [OperationContract()]
        SignatureKtpResponse UpdateSignatureKtp(SignatureKtpRequest request);

        [OperationContract()]
        SignatureKtpResponse DeleteSignatureKtp(SignatureKtpRequest request);
        #endregion

        #region StatusPerkawinan
        [OperationContract()]
        StatusPerkawinanResponse GetStatusPerkawinanFindBy(StatusPerkawinanRequest request);

        [OperationContract()]
        StatusPerkawinanResponse GetStatusPerkawinanList(StatusPerkawinanRequest request);

        [OperationContract()]
        StatusPerkawinanResponse InsertStatusPerkawinan(StatusPerkawinanRequest request);

        [OperationContract()]
        StatusPerkawinanResponse UpdateStatusPerkawinan(StatusPerkawinanRequest request);

        [OperationContract()]
        StatusPerkawinanResponse DeleteStatusPerkawinan(StatusPerkawinanRequest request);
        #endregion

        #region Struktur
        [OperationContract()]
        StrukturResponse GetStrukturFindBy(StrukturRequest request);

        [OperationContract()]
        StrukturResponse GetStrukturList(StrukturRequest request);

        [OperationContract()]
        StrukturResponse InsertStruktur(StrukturRequest request);

        [OperationContract()]
        StrukturResponse UpdateStruktur(StrukturRequest request);

        [OperationContract()]
        StrukturResponse UpdateStrukturByDrag(StrukturRequest request);

        [OperationContract()]
        StrukturResponse DeleteStruktur(StrukturRequest request);
        #endregion

        #region PhotoKtp
        [OperationContract()]
        PhotoKtpResponse GetPhotoKtpFindBy(PhotoKtpRequest request);

        [OperationContract()]
        PhotoKtpResponse GetPhotoKtpList(PhotoKtpRequest request);

        [OperationContract()]
        PhotoKtpResponse InsertPhotoKtp(PhotoKtpRequest request);

        [OperationContract()]
        PhotoKtpResponse UpdatePhotoKtp(PhotoKtpRequest request);

        [OperationContract()]
        PhotoKtpResponse DeletePhotoKtp(PhotoKtpRequest request);
        #endregion

        //#region JadwalSiskamling
        //[OperationContract()]
        //JadwalSiskamlingResponse GetJadwalSiskamlingFindBy(JadwalSiskamlingRequest request);

        //[OperationContract()]
        //JadwalSiskamlingResponse GetJadwalSiskamlingList(JadwalSiskamlingRequest request);

        //[OperationContract()]
        //JadwalSiskamlingResponse InsertJadwalSiskamling(JadwalSiskamlingRequest request);

        //[OperationContract()]
        //JadwalSiskamlingResponse UpdateJadwalSiskamling(JadwalSiskamlingRequest request);

        //[OperationContract()]
        //JadwalSiskamlingResponse DeleteJadwalSiskamling(JadwalSiskamlingRequest request);
        //#endregion

        #region AppointmentDairy
        [OperationContract()]
        AppointmentDiaryResponse GetAppointmentDiarySelectByDateRange(AppointmentDiaryRequest request);

        [OperationContract()]
        AppointmentDiaryResponse GetAppointmentDiarySelectByTitle(AppointmentDiaryRequest request);

        [OperationContract()]
        AppointmentDiaryResponse GetAppointmentDiarySelectByTitleAndMonth(AppointmentDiaryRequest request);

        [OperationContract()]
        AppointmentDiaryResponse InsertAppointmentDiary(AppointmentDiaryRequest request);

        [OperationContract()]
        AppointmentDiaryResponse UpdateAppointmentDiary(AppointmentDiaryRequest request);
        #endregion

        #region SlideShow
        [OperationContract()]
        SlideShowResponse GetSlideShowFindBy(SlideShowRequest request);

        [OperationContract()]
        SlideShowResponse GetSlideShowList(SlideShowRequest request);

        [OperationContract()]
        SlideShowResponse InsertSlideShow(SlideShowRequest request);

        [OperationContract()]
        SlideShowResponse UpdateSlideShow(SlideShowRequest request);

        [OperationContract()]
        SlideShowResponse DeleteSlideShow(SlideShowRequest request);
        #endregion

        #region Parameter
        [OperationContract()]
        ParameterResponse GetParameterFindBy(ParameterRequest request);

        [OperationContract()]
        ParameterResponse GetParameterList(ParameterRequest request);

        [OperationContract()]
        ParameterResponse InsertParameter(ParameterRequest request);

        [OperationContract()]
        ParameterResponse UpdateParameter(ParameterRequest request);

        [OperationContract()]
        ParameterResponse DeleteParameter(ParameterRequest request);
        #endregion



    }
}
