using AbidzarFrame.Core.Model.Business;
using AbidzarFrame.Core.Mvc.Helpers;
using AbidzarFrame.Domain.Common;
using AbidzarFrame.Master.Interface.Dto;
using AbidzarFrame.Utils;
using AbidzarFrame.Web.Helpers;
using AbidzarFrame.Web.WebApiLocal;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace AbidzarFrame.Web.Areas.Kegiatan.Controllers
{
    public class KegiatanController : WebLogManager
    {
        #region Private Instance
        private FunctionLog functionLog = new FunctionLog();
        private const string controller = "KegiatanController";
        private string token = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken;
        private ResultStatus result = new ResultStatus();
        BusinessErrors bussinessError = new BusinessErrors();
        JenisKegiatanRequest request = new JenisKegiatanRequest();
        JenisKegiatanResponse response = new JenisKegiatanResponse();
        protected ErrorHandler _errHand
        {
            get { return new ErrorHandler(); }
        }
        #endregion

        #region Contructor 
        public KegiatanController()
        {
        }
        #endregion
        // GET: Kegiatan/Kegiatan
        public ActionResult Index()
        {
            response = GetDataList();
            return View(response.JenisKegiatanResultList);
        }

        public JenisKegiatanResponse GetDataList()
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/JenisKegiatan/GetJenisKegiatanList";

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                request.AuthenticationToken = token;
                request.KodeRt = CurrentUser.GetCurrentKodeRt();
                //call api
                response = JsonConvert.DeserializeObject<JenisKegiatanResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
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

        private void LoadData()
        {
            ViewBag.JenisKegiatanList = DropDown.GetJenisKegiatanList();
            ViewBag.WarnaList = DropDown.GetWarnaList();
        }

        public ActionResult DetailJenisKegiatan(int idJenisKegiatan)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/DetailJenisKegiatan/GetDetailJenisKegiatanListByIdJenisKegiatan";
            DetailJenisKegiatanRequest detailJenisKegiatanRequest = new DetailJenisKegiatanRequest();
            DetailJenisKegiatanResponse detailJenisKegiatanResponse = new DetailJenisKegiatanResponse();

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                detailJenisKegiatanRequest.AuthenticationToken = token;
                detailJenisKegiatanRequest.IdJenisKegiatan = idJenisKegiatan;
                //call api
                detailJenisKegiatanResponse = JsonConvert.DeserializeObject<DetailJenisKegiatanResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, detailJenisKegiatanRequest));
                //if (!response.ResultStatus.IsSuccess)
                //{
                //    return JsonError(response.ResultStatus.MessageText, JsonRequestBehavior.AllowGet);
                //}

            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.end);
            }

            ViewBag.MsgScs = TempData["MsgScs"];
            return View(detailJenisKegiatanResponse.DetailJenisKegiatanResultList);
        }

        public ActionResult EditorFormPartial(int id)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/DetailJenisKegiatan/GetDetailJenisKegiatanFindBy";
            DetailJenisKegiatanRequest detailJenisKegiatanRequest = new DetailJenisKegiatanRequest();
            DetailJenisKegiatanResponse detailJenisKegiatanResponse = new DetailJenisKegiatanResponse();

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                detailJenisKegiatanRequest.AuthenticationToken = token;
                detailJenisKegiatanRequest.Id = id;
                //call api if not adding / create
                if (id > 0)
                {
                    detailJenisKegiatanResponse = JsonConvert.DeserializeObject<DetailJenisKegiatanResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, detailJenisKegiatanRequest));
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
                ViewBag.ActionGrid = "Edit";
            }
            else
            {
                ViewBag.ActionGrid = "Add";
            }

            LoadData();
            return PartialView("_DetailJenisKegiatan", detailJenisKegiatanResponse.DetailJenisKegiatanResult);
        }

        public ActionResult CreateDetailJenisKegiatan(DetailJenisKegiatanRequest model)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/DetailJenisKegiatan/InsertDetailJenisKegiatan";
            DetailJenisKegiatanRequest detailJenisKegiatanRequest = new DetailJenisKegiatanRequest();
            DetailJenisKegiatanResponse detailJenisKegiatanResponse = new DetailJenisKegiatanResponse();

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

                detailJenisKegiatanRequest = model;
                detailJenisKegiatanRequest.AuthenticationToken = token;

                //call api
                detailJenisKegiatanRequest.DibuatOleh = CurrentUser.GetCurrentUserId();
                detailJenisKegiatanResponse = JsonConvert.DeserializeObject<DetailJenisKegiatanResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, detailJenisKegiatanRequest));
                if (!detailJenisKegiatanResponse.ResultStatus.IsSuccess)
                {
                    return JsonError(detailJenisKegiatanResponse.ResultStatus.MessageText, JsonRequestBehavior.AllowGet);
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

        public ActionResult UpdateDetailJenisKegiatan(DetailJenisKegiatanRequest model)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/DetailJenisKegiatan/UpdateDetailJenisKegiatan";
            DetailJenisKegiatanRequest detailJenisKegiatanRequest = new DetailJenisKegiatanRequest();
            DetailJenisKegiatanResponse detailJenisKegiatanResponse = new DetailJenisKegiatanResponse();

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                if (string.IsNullOrWhiteSpace(model.NamaKegiatan))
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

                detailJenisKegiatanRequest = model;
                detailJenisKegiatanRequest.AuthenticationToken = token;
                detailJenisKegiatanRequest.DieditOleh = CurrentUser.GetCurrentUserId();
                //call api
                detailJenisKegiatanResponse = JsonConvert.DeserializeObject<DetailJenisKegiatanResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, detailJenisKegiatanRequest));
                if (!detailJenisKegiatanResponse.ResultStatus.IsSuccess)
                {
                    return JsonError(detailJenisKegiatanResponse.ResultStatus.MessageText, JsonRequestBehavior.AllowGet);
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

        public ActionResult DeleteDetailJenisKegiatan(int id)
        {

            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/DetailJenisKegiatan/DeleteDetailJenisKegiatan";
            DetailJenisKegiatanRequest detailJenisKegiatanRequest = new DetailJenisKegiatanRequest();
            DetailJenisKegiatanResponse detailJenisKegiatanResponse = new DetailJenisKegiatanResponse();

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                detailJenisKegiatanRequest.AuthenticationToken = token;
                detailJenisKegiatanRequest.Id = id;
                //call api
                detailJenisKegiatanResponse = JsonConvert.DeserializeObject<DetailJenisKegiatanResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, detailJenisKegiatanRequest));
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.end);
            }

            TempData["MsgScs"] = "Success Delete Data";
            var adae = Request.QueryString["idJenisKegiatan"];
            return Json(new { success = true, Msg = "Success Delete Data" }, JsonRequestBehavior.AllowGet);
            //return RedirectToAction("DetailJenisKegiatan", new {idJenisKegiatan = })
        }


        //======================start not use==============================
        public ActionResult JadwalSiskamling()
        {
            ViewBag.KtpList = DropDown.GetKtpList();
            return View();
        }

        public ActionResult CreateJadwalSiskamling(List<JadwalSiskamlingRequest> requestList)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/JadwalSiskamling/InsertJadwalSiskamling";
            JadwalSiskamlingRequest request = new JadwalSiskamlingRequest();
            JadwalSiskamlingResponse response = new JadwalSiskamlingResponse();

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                foreach (var item in requestList)
                {
                    request.Nik = item.Nik;
                    request.Nama = item.Nama;
                    request.Tanggal = item.Tanggal;
                    request.AuthenticationToken = token;

                    //call api
                    request.DibuatOleh = CurrentUser.GetCurrentUserId();
                    response = JsonConvert.DeserializeObject<JadwalSiskamlingResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
                    if (!response.ResultStatus.IsSuccess)
                    {
                        return JsonError(response.ResultStatus.MessageText, JsonRequestBehavior.AllowGet);
                    }
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
        //======================end not use==================================

    }
}