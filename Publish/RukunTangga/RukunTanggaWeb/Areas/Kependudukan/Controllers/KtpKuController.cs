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
    public class KtpKuController : WebLogManager
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
        public KtpKuController()
        {
        }
        #endregion
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

        public ActionResult Index()
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/Ktp/GetKtpFindBy";
            ViewBag.MsgScs = TempData["MsgScs"];
            ViewBag.MsgErr = TempData["MsgErr"];

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                request.AuthenticationToken = token;
                request.Nik = CurrentUser.GetCurrentUserId();
                request.KodeRt = CurrentUser.GetCurrentKodeRt();
                response = JsonConvert.DeserializeObject<KtpResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
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

            ChangePasswordViewModel changePasswordViewModel = new ChangePasswordViewModel();

            LoadData();
            return View(Tuple.Create(response.KtpResult, changePasswordViewModel));
        }

        public ActionResult UpdatePhotoKtp(int idPhotoKtp)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/PhotoKtp/UpdatePhotoKtp";
            PhotoKtpRequest photoKtpRequest = new PhotoKtpRequest();
            PhotoKtpResponse photoKtpResponse = new PhotoKtpResponse();

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                photoKtpRequest.AuthenticationToken = token;
                List<string> lString = CData.GetListString;
                photoKtpRequest.Id = idPhotoKtp;
                photoKtpRequest.NamaFile = lString[0];
                photoKtpRequest.DieditOleh = CurrentUser.GetCurrentUserId();
                photoKtpResponse = JsonConvert.DeserializeObject<PhotoKtpResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, photoKtpRequest));
                CData.CleanDataString();
                if (!photoKtpResponse.ResultStatus.IsSuccess)
                {
                    return JsonError(photoKtpResponse.ResultStatus.MessageText);
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

            //ChangePasswordViewModel changePasswordViewModel = new ChangePasswordViewModel();           
            //return View(Tuple.Create(response.KtpResult, changePasswordViewModel));
            return Json(new { success = true, Msg = "Success Update Photo" }, JsonRequestBehavior.AllowGet);
        }

    }
}