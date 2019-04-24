using AbidzarFrame.Core.Model.Business;
using AbidzarFrame.Core.Mvc.Helpers;
using AbidzarFrame.Domain.Common;
using AbidzarFrame.Domain.Models;
using AbidzarFrame.Questioner.Interface.Dto;
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

namespace AbidzarFrame.Web.Areas.Questioner.Controllers
{
    public class TanyaRtDetailController : WebLogManager
    {

        #region Private Instance
        private FunctionLog functionLog = new FunctionLog();
        private const string controller = "TanyaRtDetailController";
        private string token = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken;
        private ResultStatus result = new ResultStatus();
        BusinessErrors bussinessError = new BusinessErrors();
        TanyaRtDetailRequest request = new TanyaRtDetailRequest();
        TanyaRtDetailResponse response = new TanyaRtDetailResponse();
        protected ErrorHandler _errHand
        {
            get { return new ErrorHandler(); }
        }
        #endregion

        #region Contructor 
        public TanyaRtDetailController()
        {
        }
        #endregion

        public ActionResult Index(int idTanyaRt)
        {
            try
            {
                response = GetDataListByIdTanyaRt(idTanyaRt);
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message, JsonRequestBehavior.AllowGet);
            }
            return View(response.TanyaRtDetailResultList.ToList());
        }
        
        public ActionResult GetTanyaRtDetail(int idTanyaRt)
        {
            response = GetDataListByIdTanyaRt(idTanyaRt);
            ViewBag.IdTanyaRt = idTanyaRt;
            return PartialView("~/Areas/Questioner/Views/TanyaRt/_TanyaRtDetailList.cshtml", response.TanyaRtDetailResultList);
        }

        public ActionResult Read(int idTanyaRt)
        {
            try
            {
                response = GetDataListByIdTanyaRt(idTanyaRt);
                var data = response.TanyaRtDetailResultList;
                return Json(new { data = data.ToList() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }


        public TanyaRtDetailResponse GetDataListByIdTanyaRt(int idTanyaRt)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/TanyaRtDetail/GetTanyaRtDetailListByIdTanyaRt";

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                request.AuthenticationToken = token;
                request.IdTanyaRt = idTanyaRt;
                //call api
                response = JsonConvert.DeserializeObject<TanyaRtDetailResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
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

        public ActionResult EditorFormPartial(int id)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/TanyaRtDetail/GetTanyaRtDetailFindBy";

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                request.AuthenticationToken = token;
                request.Id = id;
                //call api if not adding / create
                if (id > 0)
                {
                    response = JsonConvert.DeserializeObject<TanyaRtDetailResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
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
            
            return PartialView("_TanyaRtDetail", response.TanyaRtDetailResult);
        }

        public ActionResult Create(TanyaRtDetailRequest model)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/TanyaRtDetail/InsertTanyaRtDetail";

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

                //call api
                request.DibuatOleh = CurrentUser.GetCurrentUserId();
                response = JsonConvert.DeserializeObject<TanyaRtDetailResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
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

        public ActionResult Update(TanyaRtDetailRequest model)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/TanyaRtDetail/UpdateTanyaRtDetail";

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
                response = JsonConvert.DeserializeObject<TanyaRtDetailResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
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
            string apiUrl = "api/TanyaRtDetail/DeleteTanyaRtDetail";

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                request.AuthenticationToken = token;
                request.Id = id;
                //call api
                response = JsonConvert.DeserializeObject<TanyaRtDetailResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
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