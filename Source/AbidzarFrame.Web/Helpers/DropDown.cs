using AbidzarFrame.Master.Interface.Dto;
using AbidzarFrame.Security.Interface.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AbidzarFrame.Web.Helpers
{
    public class DropDown
    {
        public static SelectList GetProvinsiList(int? id)
        {
            string apiUrl = "api/Provinsi/GetProvinsiList";
            ProvinsiResponse response = new ProvinsiResponse();
            ProvinsiRequest request = new ProvinsiRequest();
            request.AuthenticationToken = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken; ;
            if (id != null)
            {
                request.Id = (int)id;
            }
            response = JsonConvert.DeserializeObject<ProvinsiResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));

            var List = response.ProvinsiResultList
                .OrderBy(x => x.NamaProvinsi).ToList();

            SelectList selectList = new SelectList(List, "Id", "NamaProvinsi");
            return selectList;
        }

        public static SelectList GetKotaList(int? idProvinsi)
        {
            string apiUrl = "api/Kota/GetKotaList";
            KotaResponse response = new KotaResponse();
            KotaRequest request = new KotaRequest();
            request.AuthenticationToken = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken; 
            if (idProvinsi != null)
            {
                request.IdProvinsi = (int)idProvinsi;
            }
            response = JsonConvert.DeserializeObject<KotaResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));

            var List = response.KotaResultList.ToList()
                .OrderBy(x => x.NamaKota).ToList();

            SelectList selectList = new SelectList(List, "Id", "NamaKota");
            return selectList;

        }

        public static SelectList GetKecamatanList(int? idKota)
        {
            string apiUrl = "api/Kecamatan/GetKecamatanList";
            KecamatanResponse response = new KecamatanResponse();
            KecamatanRequest request = new KecamatanRequest();
            request.AuthenticationToken = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken;
            if (idKota != null)
            {
                request.IdKota = (int)idKota;
            }

            response = JsonConvert.DeserializeObject<KecamatanResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));

            var List = response.KecamatanResultList.ToList()
                .OrderBy(x => x.NamaKecamatan).ToList();

            SelectList selectList = new SelectList(List, "Id", "NamaKecamatan");
            return selectList;

        }

        public static SelectList GetKelurahanList(int? idKecamatan)
        {
            string apiUrl = "api/Kelurahan/GetKelurahanList";
            KelurahanResponse response = new KelurahanResponse();
            KelurahanRequest request = new KelurahanRequest();
            request.AuthenticationToken = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken;
            if (idKecamatan != null)
            {
                request.IdKecamatan = (int)idKecamatan;
            }

            response = JsonConvert.DeserializeObject<KelurahanResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));

            var List = response.KelurahanResultList.ToList()
                .OrderBy(x => x.NamaKelurahan).ToList();

            SelectList selectList = new SelectList(List, "Id", "NamaKelurahan");
            return selectList;

        }

        public static SelectList GetJabatanList()
        {
            string apiUrl = "api/Jabatan/GetJabatanList";
            JabatanResponse response = new JabatanResponse();
            JabatanRequest request = new JabatanRequest();
            request.AuthenticationToken = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken; 
            response = JsonConvert.DeserializeObject<JabatanResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));

            var List = response.JabatanResultList
                .OrderBy(x => x.NamaJabatan).ToList();

            SelectList selectList = new SelectList(List, "Id", "NamaJabatan");
            return selectList;
        }

        public static SelectList GetJenisKelaminList()
        {
            string apiUrl = "api/JenisKelamin/GetJenisKelaminList";
            JenisKelaminResponse response = new JenisKelaminResponse();
            JenisKelaminRequest request = new JenisKelaminRequest();
            request.AuthenticationToken = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken; 
            response = JsonConvert.DeserializeObject<JenisKelaminResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));

            var List = response.JenisKelaminResultList
                .OrderBy(x => x.Deskripsi).ToList();

            SelectList selectList = new SelectList(List, "Id", "Deskripsi");
            return selectList;
        }

        public static SelectList GetAgamaList()
        {
            string apiUrl = "api/Agama/GetAgamaList";
            AgamaResponse response = new AgamaResponse();
            AgamaRequest request = new AgamaRequest();
            request.AuthenticationToken = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken; 
            response = JsonConvert.DeserializeObject<AgamaResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));

            var List = response.AgamaResultList
                .OrderBy(x => x.NamaAgama).ToList();

            SelectList selectList = new SelectList(List, "Id", "NamaAgama");
            return selectList;
        }

        public static SelectList GetStatusPerkawinanList()
        {
            string apiUrl = "api/StatusPerkawinan/GetStatusPerkawinanList";
            StatusPerkawinanResponse response = new StatusPerkawinanResponse();
            StatusPerkawinanRequest request = new StatusPerkawinanRequest();
            request.AuthenticationToken = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken; 
            response = JsonConvert.DeserializeObject<StatusPerkawinanResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));

            var List = response.StatusPerkawinanResultList
                .OrderBy(x => x.StatusPerkawinan).ToList();

            SelectList selectList = new SelectList(List, "Id", "StatusPerkawinan");
            return selectList;
        }

        public static SelectList GetJenisPekerjaanList()
        {
            string apiUrl = "api/JenisPekerjaan/GetJenisPekerjaanList";
            JenisPekerjaanResponse response = new JenisPekerjaanResponse();
            JenisPekerjaanRequest request = new JenisPekerjaanRequest();
            request.AuthenticationToken = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken; 
            response = JsonConvert.DeserializeObject<JenisPekerjaanResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));

            var List = response.JenisPekerjaanResultList
                .OrderBy(x => x.JenisPekerjaan).ToList();

            SelectList selectList = new SelectList(List, "Id", "JenisPekerjaan");
            return selectList;
        }

        public static SelectList GetKewarganegaraanList()
        {
            string apiUrl = "api/Kewarganegaraan/GetKewarganegaraanList";
            KewarganegaraanResponse response = new KewarganegaraanResponse();
            KewarganegaraanRequest request = new KewarganegaraanRequest();
            request.AuthenticationToken = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken; 
            response = JsonConvert.DeserializeObject<KewarganegaraanResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));

            var List = response.KewarganegaraanResultList
                .OrderBy(x => x.JenisKewarganegaraan).ToList();

            SelectList selectList = new SelectList(List, "Id", "JenisKewarganegaraan");
            return selectList;
        }

        public static SelectList GetGolonganDarahList()
        {
            string apiUrl = "api/GolonganDarah/GetGolonganDarahList";
            GolonganDarahResponse response = new GolonganDarahResponse();
            GolonganDarahRequest request = new GolonganDarahRequest();
            request.AuthenticationToken = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken; 
            response = JsonConvert.DeserializeObject<GolonganDarahResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));

            var List = response.GolonganDarahResultList
                .OrderBy(x => x.GolonganDarah).ToList();

            SelectList selectList = new SelectList(List, "Id", "GolonganDarah");
            return selectList;
        }


        public static SelectList GetPendidikanList()
        {
            string apiUrl = "api/Pendidikan/GetPendidikanList";
            PendidikanResponse response = new PendidikanResponse();
            PendidikanRequest request = new PendidikanRequest();
            request.AuthenticationToken = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken; 
            response = JsonConvert.DeserializeObject<PendidikanResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));

            var List = response.PendidikanResultList
                .OrderBy(x => x.Pendidikan).ToList();

            SelectList selectList = new SelectList(List, "Id", "Pendidikan");
            return selectList;
        }


        public static SelectList GetJenisKegiatanList()
        {
            string apiUrl = "api/JenisKegiatan/GetJenisKegiatanList";
            JenisKegiatanResponse response = new JenisKegiatanResponse();
            JenisKegiatanRequest request = new JenisKegiatanRequest();
            request.AuthenticationToken = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken;
            request.KodeRt = CurrentUser.GetCurrentKodeRt();

            response = JsonConvert.DeserializeObject<JenisKegiatanResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));

            var List = response.JenisKegiatanResultList
                .OrderBy(x => x.JenisKegiatan).ToList();

            SelectList selectList = new SelectList(List, "Id", "JenisKegiatan");
            return selectList;
        }

        public static SelectList GetRoleList()
        {
            string apiUrl = "api/Role/GetRoleList";
            RoleResponse response = new RoleResponse();
            RoleRequest request = new RoleRequest();
            request.AuthenticationToken = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken; 
            response = JsonConvert.DeserializeObject<RoleResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));

            var List = response.RoleResultList
                .OrderBy(x => x.NamaRole).ToList();

            SelectList selectList = new SelectList(List, "IdRole", "NamaRole");
            return selectList;
        }

        public static SelectList GetKtpList()
        {
            string apiUrl = "api/Ktp/GetKtpList";
            KtpResponse response = new KtpResponse();
            KtpRequest request = new KtpRequest();
            request.AuthenticationToken = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken;
            request.KodeRt = CurrentUser.GetCurrentKodeRt();
            response = JsonConvert.DeserializeObject<KtpResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));

            var List = response.KtpResultList
                .OrderBy(x => x.Nama).ToList();

            SelectList selectList = new SelectList(List, "Nik", "Nama");
            return selectList;
        }

        public static SelectList GetTipeLaporanKasList()
        {
            List<TempObj> TipeLaporanKasList = new List<TempObj>();
            string[] str = new string[] { "Pemasukan", "Pengeluaran" };
            for (int i = 0; i < 2; i++)
            {
                TempObj temp = new TempObj();
                temp.Text = str[i];
                temp.Value = i.ToString();
                TipeLaporanKasList.Add(temp);
            }
            SelectList selectList = new SelectList(TipeLaporanKasList, "Value", "Text");
            return selectList;
        }

        public static SelectList GetRtList()
        {
            List<TempObj> ObjList = new List<TempObj>();
            for (int i = 1; i <= 12; i++)
            {
                TempObj temp = new TempObj();
                string val = "";
                if (i < 10)
                {
                    val = "00" + i.ToString();
                }else
                {
                    val = "0" + i.ToString();
                }
                temp.Text = val;
                temp.Value = val;
                ObjList.Add(temp);
            }
            SelectList selectList = new SelectList(ObjList, "Value", "Text");
            return selectList;
        }

        public static SelectList GetRwList()
        {
            List<TempObj> ObjList = new List<TempObj>();
            for (int i = 1; i <= 12; i++)
            {
                TempObj temp = new TempObj();
                string val = "";
                if (i < 10)
                {
                    val = "00" + i.ToString();
                }
                else
                {
                    val = "0" + i.ToString();
                }
                temp.Text = val;
                temp.Value = val;
                ObjList.Add(temp);
            }
            SelectList selectList = new SelectList(ObjList, "Value", "Text");
            return selectList;
        }
        public static SelectList GetWarnaList()
        {
            List<TempObj> TipeLaporanKasList = new List<TempObj>();
            string[] str = new string[] {"default", "dark", "white", "green", "red", "yellow", "blue", "purple" };
            foreach (var item in str)
            {
                TempObj temp = new TempObj();
                temp.Text = item;
                temp.Value = item;
                TipeLaporanKasList.Add(temp);
            }
            
            SelectList selectList = new SelectList(TipeLaporanKasList, "Value", "Text");
            return selectList;
        }

        public static SelectList GetMonthList(int year)
        {
            List<TempObj> monthsList = new List<TempObj>();
            string[] months = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            for (int i = 0; i < 12; i++)
            {
                TempObj month = new TempObj();
                month.Text = months[i];
                month.Value = DateTime.DaysInMonth(year, (i + 1)).ToString() + "-" + (i + 1).ToString().PadLeft(2, '0');
                monthsList.Add(month);
            }
            SelectList selectList = new SelectList(monthsList, "Value", "Text");
            return selectList;
        }

        public static SelectList GetTipeSlideShowList()
        {
            List<TempObj> TipeLaporanKasList = new List<TempObj>();
            string[] str = new string[] { "Slide", "HorizonScroll" };
            for (int i = 0; i < 2; i++)
            {
                TempObj temp = new TempObj();
                temp.Text = str[i];
                temp.Value = i.ToString();
                TipeLaporanKasList.Add(temp);
            }
            SelectList selectList = new SelectList(TipeLaporanKasList, "Value", "Text");
            return selectList;
        }

        public static SelectList GetPosisiList()
        {
            List<TempObj> TipeLaporanKasList = new List<TempObj>();
            string[] str = new string[] { "Dashboard", "Informasi" };
            for (int i = 0; i < 2; i++)
            {
                TempObj temp = new TempObj();
                temp.Text = str[i];
                temp.Value = i.ToString();
                TipeLaporanKasList.Add(temp);
            }
            SelectList selectList = new SelectList(TipeLaporanKasList, "Value", "Text");
            return selectList;
        }

        public static SelectList NullList()
        {
            List<TempObj> ObjList = new List<TempObj>();

            TempObj temp = new TempObj();
            temp.Text = "Select";
            temp.Value = "";
            ObjList.Add(temp);
            SelectList selectList = new SelectList(ObjList, "Value", "Text");
            return selectList;
        }
    }

    public class TempObj
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
}