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

namespace AbidzarFrame.Web.Areas.Informasi.Controllers
{
    public class DetailJenisInformasiController : WebLogManager
    {

        #region Private Instance
        private FunctionLog functionLog = new FunctionLog();
        private const string controller = "DetailJenisInformasiController";
        private string token = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken;
        private ResultStatus result = new ResultStatus();
        BusinessErrors bussinessError = new BusinessErrors();
        DetailJenisInformasiRequest request = new DetailJenisInformasiRequest();
        DetailJenisInformasiResponse response = new DetailJenisInformasiResponse();
        protected ErrorHandler _errHand
        {
            get { return new ErrorHandler(); }
        }
        #endregion

        #region Contructor 
        public DetailJenisInformasiController()
        {
        }
        #endregion

        public ActionResult Index(int idJenisInformasi)
        {
            response = GetDetailJenisInformasiListByIdJenisInformasi(idJenisInformasi);

            ViewBag.IdJenisInformasi = idJenisInformasi;
            return View(response.DetailJenisInformasiResultList.ToList());
        }

        public ActionResult DetailJenisInformasiTerbaru()
        {
            List<DetailJenisInformasiResult> responseList = new List<DetailJenisInformasiResult>();
            responseList = Common.GetDetailJenisInformasiNewest(CurrentUser.GetCurrentKodeRt());
            return View(responseList);
        }

        public ActionResult Read()
        {
            try
            {
                response = GetDataList();
                var data = response.DetailJenisInformasiResultList;
                return Json(new { data = data.ToList() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public DetailJenisInformasiResponse GetDataList()
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/DetailJenisInformasi/GetDetailJenisInformasiList";

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                request.AuthenticationToken = token;
                //call api
                response = JsonConvert.DeserializeObject<DetailJenisInformasiResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
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

        public DetailJenisInformasiResponse GetDetailJenisInformasiListByIdJenisInformasi(int idJenisInformasi)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/DetailJenisInformasi/GetDetailJenisInformasiListByIdJenisInformasi";

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                request.AuthenticationToken = token;
                request.IdJenisInformasi = idJenisInformasi;
                //call api
                response = JsonConvert.DeserializeObject<DetailJenisInformasiResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
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

        public ActionResult EditorFormPartialForCreate(int id)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            int idJenisInformasi = id;
            ViewBag.ActionGrid = "Add";

            ViewBag.IdJenisInformasi = idJenisInformasi;
            return View("_DetailJenisInformasi", response.DetailJenisInformasiResult);
        }

        public ActionResult EditorFormPartialForEdit(int id, string flag)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/DetailJenisInformasi/GetDetailJenisInformasiFindBy";
            int idJenisInformasi = 0;
            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                request.AuthenticationToken = token;
                request.Id = id;
                //call api if not adding / create
                if (id > 0)
                {
                    response = JsonConvert.DeserializeObject<DetailJenisInformasiResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
                    idJenisInformasi = response.DetailJenisInformasiResult.IdJenisInformasi;
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

            ViewBag.ActionGrid = flag;
            ViewBag.IdJenisInformasi = idJenisInformasi;
            return View("_DetailJenisInformasi", response.DetailJenisInformasiResult);
        }

        [ValidateInput(false)]
        public ActionResult Create(DetailJenisInformasiRequest model)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/DetailJenisInformasi/InsertDetailJenisInformasi";

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
                //encod descripsi
                request.Deskripsi = Server.HtmlEncode(request.Deskripsi);

                //call api
                request.DibuatOleh = CurrentUser.GetCurrentUserId();
                response = JsonConvert.DeserializeObject<DetailJenisInformasiResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
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

            return RedirectToAction("Index", new { idJenisInformasi = model.IdJenisInformasi });
        }

        [ValidateInput(false)]
        public ActionResult Update(DetailJenisInformasiRequest model)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/DetailJenisInformasi/UpdateDetailJenisInformasi";

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                if (string.IsNullOrWhiteSpace(model.Deskripsi))
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
                //call api
                response = JsonConvert.DeserializeObject<DetailJenisInformasiResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
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

            return RedirectToAction("Index", new { idJenisInformasi = model.IdJenisInformasi });
        }

        public ActionResult Delete(int id)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrlSelect = "api/DetailJenisInformasi/GetDetailJenisInformasiFindBy";
            string apiUrl = "api/DetailJenisInformasi/DeleteDetailJenisInformasi";
            int idJenisInformasi = 0;
            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                request.AuthenticationToken = token;
                request.Id = id;

                //call api get idJenisInformasi
                response = JsonConvert.DeserializeObject<DetailJenisInformasiResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrlSelect, request));
                idJenisInformasi = response.DetailJenisInformasiResult.IdJenisInformasi;

                //call api delete data
                response = JsonConvert.DeserializeObject<DetailJenisInformasiResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.end);
            }


            //Json(new { success = true, Msg = "Success Delete Data" }, JsonRequestBehavior.AllowGet);
            return RedirectToAction("Index", new { idJenisInformasi = idJenisInformasi });
        }
    }
}