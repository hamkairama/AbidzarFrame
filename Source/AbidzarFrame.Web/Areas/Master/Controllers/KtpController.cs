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

namespace AbidzarFrame.Web.Areas.Master.Controllers
{
    public class KtpController : WebLogManager
    {

        #region Private Instance
        private FunctionLog functionLog = new FunctionLog();
        private const string controller = "KtpController";
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
        public KtpController()
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

        private void LoadData(KtpResponse response)
        {
            ViewBag.ProvinsiList = DropDown.GetProvinsiList(response.KtpResult.IdProvinsi);
            ViewBag.KotaList = DropDown.GetKotaList(response.KtpResult.IdProvinsi);
            ViewBag.KecamatanList = DropDown.GetKecamatanList(response.KtpResult.IdKota);
            ViewBag.KelurahanList = DropDown.GetKelurahanList(response.KtpResult.IdKecamatan);
            ViewBag.JenisKelaminList = DropDown.GetJenisKelaminList();
            ViewBag.AgamaList = DropDown.GetAgamaList();
            ViewBag.StatusPerkawinanList = DropDown.GetStatusPerkawinanList();
            ViewBag.JenisPekerjaanList = DropDown.GetJenisPekerjaanList();
            ViewBag.KewarganegaraanList = DropDown.GetKewarganegaraanList();
            ViewBag.GolonganDarahList = DropDown.GetGolonganDarahList();
            ViewBag.PendidikanList = DropDown.GetPendidikanList();
            ViewBag.RtList = DropDown.GetRtList();
            ViewBag.RwList = DropDown.GetRwList();
        }

        private void LoadDataFirst()
        {
            ViewBag.ProvinsiList = DropDown.NullList();
            ViewBag.KotaList = DropDown.NullList(); // DropDown.GetKotaList(response.KtpResult.IdKota);
            ViewBag.KecamatanList = DropDown.NullList(); // DropDown.GetKecamatanList(response.KtpResult.IdKota);
            ViewBag.KelurahanList = DropDown.NullList(); // DropDown.GetKelurahanList(response.KtpResult.IdKecamatan);
            ViewBag.JenisKelaminList = DropDown.GetJenisKelaminList();
            ViewBag.AgamaList = DropDown.GetAgamaList();
            ViewBag.StatusPerkawinanList = DropDown.GetStatusPerkawinanList();
            ViewBag.JenisPekerjaanList = DropDown.GetJenisPekerjaanList();
            ViewBag.KewarganegaraanList = DropDown.GetKewarganegaraanList();
            ViewBag.GolonganDarahList = DropDown.GetGolonganDarahList();
            ViewBag.PendidikanList = DropDown.GetPendidikanList();
            ViewBag.RtList = DropDown.GetRtList();
            ViewBag.RwList = DropDown.GetRwList();
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
        public ActionResult GetDataListProvinsi()
        {
            SelectList selectList = DropDown.GetProvinsiList(null);
            return Json(selectList);
        }

        public ActionResult GetDataListKota()
        {
            SelectList selectList = DropDown.GetKotaList(null);
            return Json(selectList);
        }
        public ActionResult GetDataListByIdProvinsi(int idProvinsi)
        {
            SelectList selectList = DropDown.GetKotaList(idProvinsi);
            return Json(selectList);
        }

        public ActionResult GetDataListByIdKota(int idKota)
        {
            SelectList selectList = DropDown.GetKecamatanList(idKota);
            return Json(selectList);
        }

        public ActionResult GetDataListByIdKecamatan(int idKecamatan)
        {
            SelectList selectList = DropDown.GetKelurahanList(idKecamatan);
            return Json(selectList);
        }

        public ActionResult EditorFormPartial(int id)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/Ktp/GetKtpFindBy";

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                request.AuthenticationToken = token;
                request.Id = id;
                //call api if not adding / create
                if (id > 0)
                {
                    response = JsonConvert.DeserializeObject<KtpResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
                    ViewBag.ActionGrid = "Edit";
                    LoadData(response);
                }
                else
                {
                    ViewBag.ActionGrid = "Add";
                    LoadDataFirst();
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

            if (id > 0)
            {
               
            }
            else
            {
               
            }

           
            return PartialView("_Ktp", response.KtpResult);
        }

        public ActionResult Create(KtpRequest model)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/Ktp/InsertKtp";

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                //set id is null 
                model.Id = 0;
                if (!ModelState.IsValid)
                {
                    var errors = new Hashtable();
                    foreach (var pair in ModelState)
                    {
                        if (pair.Value.Errors.Count > 0)
                            errors[pair.Key] = pair.Value.Errors.Select(error => error.ErrorMessage).ToList();
                    }
                    return Json(new { success = false, errors }, JsonRequestBehavior.AllowGet);
                }

                request = model;
                request.AuthenticationToken = token;
                if (CurrentUser.IsApiLogin())
                    request.KodeRt = model.KodeRt;
                else
                    request.KodeRt = CurrentUser.GetCurrentKodeRt();

                //call api
                request.DibuatOleh = CurrentUser.GetCurrentUserId();
                response = JsonConvert.DeserializeObject<KtpResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
                if (!response.ResultStatus.IsSuccess)
                {
                    return JsonError(response.ResultStatus.MessageText, JsonRequestBehavior.AllowGet);
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

            return Json(new { success = true, Msg = "Success Insert Data" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(KtpRequest model)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/Ktp/UpdateKtp";

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                if (string.IsNullOrWhiteSpace(model.Nik))
                {
                    throw new InvalidOperationException(_errHand.GetErrorMessage(ErrorHandler._ERRKEY_ABIDZARFRAME, Utils.ErrorMessages.ABIDZARFRAME_DATA_NOT_FOUND_CD));
                }
                if (!ModelState.IsValid)
                {
                    var errors = new Hashtable();
                    foreach (var pair in ModelState)
                    {
                        if (pair.Value.Errors.Count > 0)
                            errors[pair.Key] = pair.Value.Errors.Select(error => error.ErrorMessage).ToList();
                    }
                    return Json(new { success = false, errors }, JsonRequestBehavior.AllowGet);
                }

                request = model;
                request.AuthenticationToken = token;
                request.DieditOleh = CurrentUser.GetCurrentUserId();
                if (CurrentUser.IsApiLogin())
                    request.KodeRt = model.KodeRt;

                //call api
                response = JsonConvert.DeserializeObject<KtpResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
                if (!response.ResultStatus.IsSuccess)
                {
                    return JsonError(response.ResultStatus.MessageText, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.end);
            }

            return Json(new { success = true, Msg = "Success Update Data" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/Ktp/DeleteKtp";

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                request.AuthenticationToken = token;
                request.Id = id;
                //call api
                response = JsonConvert.DeserializeObject<KtpResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.end);
            }

            return Json(new { success = true, Msg = "Success Delete Data" }, JsonRequestBehavior.AllowGet);
        }
    }
}