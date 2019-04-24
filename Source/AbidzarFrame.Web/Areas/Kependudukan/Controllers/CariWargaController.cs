using AbidzarFrame.Core.Model.Business;
using AbidzarFrame.Core.Mvc.Helpers;
using AbidzarFrame.Domain.Common;
using AbidzarFrame.Domain.Models;
using AbidzarFrame.Master.Interface.Dto;
using AbidzarFrame.Mvc.Infrastructures.ActionResult;
using AbidzarFrame.Utils;
using AbidzarFrame.Web.Helpers;
using AbidzarFrame.Web.Models;
using AbidzarFrame.Web.WebApiLocal;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AbidzarFrame.Web.Areas.Kependudukan.Controllers
{
    public class CariWargaController : WebLogManager
    {
        #region Private Instance
        private FunctionLog functionLog = new FunctionLog();
        private const string controller = "KtpKuController";
        private string token = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken;
        private ResultStatus result = new ResultStatus();
        BusinessErrors bussinessError = new BusinessErrors();
        KtpRequest request = new KtpRequest();
        KtpResponse response = new KtpResponse();
        protected ErrorHandler _errHand
        {
            get { return new ErrorHandler(); }
        }
        #endregion

        #region Contructor 
        public CariWargaController()
        {
        }
        #endregion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read()
        {
            try
            {
                response = GetDataList();
                var data = response.KtpResultList;
                return Json(new { data = data.ToList() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        private void LoadData()
        {
            ViewBag.ProvinsiList = DropDown.GetProvinsiList();
            ViewBag.KotaList = DropDown.GetKotaList(null);
            ViewBag.KecamatanList = DropDown.GetKecamatanList(null);
            ViewBag.KelurahanList = DropDown.GetKelurahanList(null);
            ViewBag.JenisKelaminList = DropDown.GetJenisKelaminList();
            ViewBag.AgamaList = DropDown.GetAgamaList();
            ViewBag.StatusPerkawinanList = DropDown.GetStatusPerkawinanList();
            ViewBag.JenisPekerjaanList = DropDown.GetJenisPekerjaanList();
            ViewBag.KewarganegaraanList = DropDown.GetKewarganegaraanList();
            ViewBag.GolonganDarahList = DropDown.GetGolonganDarahList();
            ViewBag.PendidikanList = DropDown.GetPendidikanList();
        }

        public ActionResult GetWarga(string nik, string nama)
        {
            response = GetDataListBy(nik, nama);
            return PartialView("~/Areas/Kependudukan/Views/CariWarga/_Warga.cshtml", response.KtpResultList);
        }

        public ActionResult EditorFormPartial(string id)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string nik = id.ToString();
            KtpResult ktpResult = new KtpResult();
            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);
                response = GetDataListBy(nik, null);
                if (response.KtpResultList.Count() > 0)
                {
                    ktpResult = response.KtpResultList[0];
                }
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
                return JsonError(ex.Message, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.end);
            }
            LoadData();
            return PartialView("_DetailWarga", ktpResult);
        }


        public KtpResponse GetDataListBy(string nik, string nama)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/Ktp/GetKtpListBy";

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                request.AuthenticationToken = token;
                request.Nik = nik;
                request.Nama = nama;
                request.KodeRt = CurrentUser.GetCurrentKodeRt();
                //call api
                response = JsonConvert.DeserializeObject<KtpResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.end);
            }

            return response;
        }

        public KtpResponse GetDataList()
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/Ktp/GetKtpList";

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                request.AuthenticationToken = token;
                request.KodeRt = CurrentUser.GetCurrentKodeRt();
                //call api
                response = JsonConvert.DeserializeObject<KtpResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.end);
            }

            return response;
        }


    }
}