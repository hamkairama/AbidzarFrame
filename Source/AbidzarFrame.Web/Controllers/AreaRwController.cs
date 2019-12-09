using AbidzarFrame.Core.Model.Business;
using AbidzarFrame.Master.Interface.Dto;
using AbidzarFrame.Security.Interface.Dto;
using AbidzarFrame.Utils;
using AbidzarFrame.Web.App_Start;
using AbidzarFrame.Web.Helpers;
using AbidzarFrame.Web.Models;
using AbidzarFrame.Web.WebApiLocal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AbidzarFrame.Web.Controllers
{
    public class AreaRwController : Controller
    {
        private string token = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken;

        private readonly ErrorHandler _errHand;
        public AreaRwController()
        {
            _errHand = new ErrorHandler();
        }

        public ActionResult Index(string errCode)
        {
            if (!string.IsNullOrWhiteSpace(errCode))
            {
                ViewBag.ErrorMessage = _errHand.GetErrorMessage(ErrorHandler._ERRKEY_ABIDZARFRAME, errCode);
            }

            DetailJenisInformasiRequest request = new DetailJenisInformasiRequest();
            DetailJenisInformasiResponse response = new DetailJenisInformasiResponse();
            request.AuthenticationToken = token;
            var objRw = CurrentUser.GetObjectRw();
            request.IdRw = (int)objRw.Id;

            string apiUrl = "api/DetailJenisInformasi/GetDetailJenisInformasiLandingPage";
            response = JsonConvert.DeserializeObject<DetailJenisInformasiResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));

            return View(response.DetailJenisInformasiResultList.ToList());
        }

        public ActionResult About()
        {
            BiodataRequest request = new BiodataRequest();
            BiodataResponse response = new BiodataResponse();
            request.AuthenticationToken = token;
            request.Nik = CurrentUser.GetObjectRw().Nik;

            string apiUrl = "api/Biodata/GetBiodataByNik";
            response = JsonConvert.DeserializeObject<BiodataResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));

            return View(response.BiodataResultList.ToList());
        }

        public ActionResult BlogHome()
        {
            return View();
        }

        public ActionResult BlogSingle()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Element()
        {
            return View();
        }

        public ActionResult Portofolio()
        {
            return View();
        }

        public ActionResult Price()
        {
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult News()
        {
            DetailJenisInformasiRequest request = new DetailJenisInformasiRequest();
            DetailJenisInformasiResponse response = new DetailJenisInformasiResponse();
            request.AuthenticationToken = token;
            var objRw = CurrentUser.GetObjectRw();
            request.IdRw = (int)objRw.Id;

            string apiUrl = "api/DetailJenisInformasi/SpGetDetailJenisInformasiByIdRw";
            response = JsonConvert.DeserializeObject<DetailJenisInformasiResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));

            return View(response.DetailJenisInformasiResultList.ToList());
        }

        public ActionResult Team()
        {
            RtRequest request = new RtRequest();
            RtResponse response = new RtResponse();
            request.AuthenticationToken = token;
            var objRw = CurrentUser.GetObjectRw();
            request.IdRw = (int)objRw.Id;

            string apiUrl = "api/Rt/GetRtByIdRw";
            response = JsonConvert.DeserializeObject<RtResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));

            return View(response.RtResultList.ToList());
        }

        public ActionResult Galery()
        {
            DokumentasiDetailJenisKegiatanRequest request = new DokumentasiDetailJenisKegiatanRequest();
            DokumentasiDetailJenisKegiatanResponse response = new DokumentasiDetailJenisKegiatanResponse();
            request.AuthenticationToken = token;

            string apiUrl = "api/DokumentasiDetailJenisKegiatan/GetDokumentasiDetailJenisKegiatanListByIdDetailJenisKegiatan";
            response = JsonConvert.DeserializeObject<DokumentasiDetailJenisKegiatanResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));

            return View(response.DokumentasiDetailJenisKegiatanResultList);
        }

        public ActionResult DetailNews(int id)
        {
            DetailJenisInformasiRequest request = new DetailJenisInformasiRequest();
            DetailJenisInformasiResponse response = new DetailJenisInformasiResponse();

            string apiUrl = "api/DetailJenisInformasi/GetDetailJenisInformasiFindBy";
            request.AuthenticationToken = token;
            request.Id = id;            

            response = JsonConvert.DeserializeObject<DetailJenisInformasiResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));

            return View(response.DetailJenisInformasiResult);
        }
    }
}