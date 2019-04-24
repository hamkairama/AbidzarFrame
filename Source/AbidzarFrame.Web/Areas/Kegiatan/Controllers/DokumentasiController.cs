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
    public class DokumentasiController : WebLogManager
    {
        #region Private Instance
        private FunctionLog functionLog = new FunctionLog();
        private const string controller = "DokumentasiController";
        private string token = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken;
        private ResultStatus result = new ResultStatus();
        BusinessErrors bussinessError = new BusinessErrors();
        DokumentasiDetailJenisKegiatanRequest request = new DokumentasiDetailJenisKegiatanRequest();
        DokumentasiDetailJenisKegiatanResponse response = new DokumentasiDetailJenisKegiatanResponse();
        protected ErrorHandler _errHand
        {
            get { return new ErrorHandler(); }
        }
        #endregion

        #region Contructor 
        public DokumentasiController()
        {
        }
        #endregion
        // GET: Kegiatan/Kegiatan
        public ActionResult Index(int idDetailJenisKegiatan)
        {
            ViewBag.IdDetailJenisKegiatan = idDetailJenisKegiatan;
            response = GetDataList(idDetailJenisKegiatan);
            return View(response.DokumentasiDetailJenisKegiatanResultList);
        }

        public ActionResult EditorFormPartial(int idDetailJenisKegiatan)
        {
            //int idDetailJenisKegiatan = id;
            ViewBag.IdDetailJenisKegiatan = idDetailJenisKegiatan;
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/DokumentasiDetailJenisKegiatan/GetDokumentasiDetailJenisKegiatanListByIdDetailJenisKegiatan";

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                request.AuthenticationToken = token;
                request.Id = idDetailJenisKegiatan;
                //call api if not adding / create
                if (idDetailJenisKegiatan > 0)
                {
                    response = JsonConvert.DeserializeObject<DokumentasiDetailJenisKegiatanResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
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

            if (idDetailJenisKegiatan > 0)
            {
                ViewBag.ActionGrid = "Edit";
            }
            else
            {
                ViewBag.ActionGrid = "Add";
            }

            return View("_Dokumentasi", response.DokumentasiDetailJenisKegiatanResultList);
        }

        public DokumentasiDetailJenisKegiatanResponse GetDataList(int idDetaiJenisKegiatan)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/DokumentasiDetailJenisKegiatan/GetDokumentasiDetailJenisKegiatanListByIdDetailJenisKegiatan";

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                request.AuthenticationToken = token;
                request.IdDetailJenisKegiatan = idDetaiJenisKegiatan;
                //call api
                response = JsonConvert.DeserializeObject<DokumentasiDetailJenisKegiatanResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
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
        
        public ActionResult CreateDokumentasiDetailJenisKegiatan(int idDetailJenisKegiatan)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/DokumentasiDetailJenisKegiatan/InsertDokumentasiDetailJenisKegiatan";
            //int idDetailJk = idDetailJenisKegiatan;
            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                request.AuthenticationToken = token;
                List<string> lString = CData.GetListString;

                if (lString.Count > 0)
                {
                    foreach (var item in lString)
                    {
                        request.IdDetailJenisKegiatan = idDetailJenisKegiatan;
                        request.NamaFile = item;
                        request.DibuatOleh = CurrentUser.GetCurrentUserId();
                        response = JsonConvert.DeserializeObject<DokumentasiDetailJenisKegiatanResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
                    }
                }
                
                if (!response.ResultStatus.IsSuccess)
                {
                    CData.CleanDataString();
                    return JsonError(response.ResultStatus.MessageText);
                }
            }
            catch (Exception ex)
            {
                CData.CleanDataString();
                _errHand.FillError(ex.Message, ref bussinessError);
                return JsonError(ex.Message, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                CData.CleanDataString();
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.end);
            }            

            return RedirectToAction("Index", new { idDetailJenisKegiatan = idDetailJenisKegiatan });
        }

        public ActionResult UpdateDokumentasiDetailJenisKegiatan(DokumentasiDetailJenisKegiatanRequest model)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/DokumentasiDetailJenisKegiatan/UpdateDokumentasiDetailJenisKegiatan";
            DokumentasiDetailJenisKegiatanRequest DokumentasiDetailJenisKegiatanRequest = new DokumentasiDetailJenisKegiatanRequest();
            DokumentasiDetailJenisKegiatanResponse DokumentasiDetailJenisKegiatanResponse = new DokumentasiDetailJenisKegiatanResponse();

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

                DokumentasiDetailJenisKegiatanRequest = model;
                DokumentasiDetailJenisKegiatanRequest.AuthenticationToken = token;
                DokumentasiDetailJenisKegiatanRequest.DieditOleh = CurrentUser.GetCurrentUserId();
                //call api
                DokumentasiDetailJenisKegiatanResponse = JsonConvert.DeserializeObject<DokumentasiDetailJenisKegiatanResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, DokumentasiDetailJenisKegiatanRequest));
                if (!DokumentasiDetailJenisKegiatanResponse.ResultStatus.IsSuccess)
                {
                    return JsonError(DokumentasiDetailJenisKegiatanResponse.ResultStatus.MessageText, JsonRequestBehavior.AllowGet);
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

        public ActionResult DeleteDokumentasiDetailJenisKegiatan(int id)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/DokumentasiDetailJenisKegiatan/DeleteDokumentasiDetailJenisKegiatan";
            DokumentasiDetailJenisKegiatanRequest DokumentasiDetailJenisKegiatanRequest = new DokumentasiDetailJenisKegiatanRequest();
            DokumentasiDetailJenisKegiatanResponse DokumentasiDetailJenisKegiatanResponse = new DokumentasiDetailJenisKegiatanResponse();

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                DokumentasiDetailJenisKegiatanRequest.AuthenticationToken = token;
                DokumentasiDetailJenisKegiatanRequest.Id = id;
                //call api
                DokumentasiDetailJenisKegiatanResponse = JsonConvert.DeserializeObject<DokumentasiDetailJenisKegiatanResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, DokumentasiDetailJenisKegiatanRequest));
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
            //return RedirectToAction("DokumentasiDetailJenisKegiatan", new {idJenisKegiatan = })
        }


       

    }
}