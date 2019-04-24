using AbidzarFrame.Core.Model.Business;
using AbidzarFrame.Core.Mvc.Helpers;
using AbidzarFrame.Domain.Common;
using AbidzarFrame.Domain.Models;
using AbidzarFrame.Security.Interface.Dto;
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

namespace AbidzarFrame.Web.Areas.Security.Controllers
{
    public class HistoricalUserLoginController : WebLogManager
    {

        #region Private Instance
        private FunctionLog functionLog = new FunctionLog();
        private const string controller = "HistoricalUserLoginController";
        private string token = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken;
        private ResultStatus result = new ResultStatus();
        BusinessErrors bussinessError = new BusinessErrors();
        HistoricalUserLoginRequest request = new HistoricalUserLoginRequest();
        HistoricalUserLoginResponse response = new HistoricalUserLoginResponse();
        protected ErrorHandler _errHand
        {
            get { return new ErrorHandler(); }
        }
        #endregion

        #region Contructor 
        public HistoricalUserLoginController()
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
                var data = response.HistoricalUserLoginResultList;
                return Json(new { data = data.ToList() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetDataBy(string byValue)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string partialView = "";
            if (byValue == "1")
            {
                partialView = "~/Areas/Security/Views/HistoricalUserLogin/_ByDate.cshtml";
            }
            else if (byValue == "2")
            {
                partialView = "~/Areas/Security/Views/HistoricalUserLogin/_ByMonth.cshtml";
            }
            else
            {
                partialView = "~/Areas/Security/Views/HistoricalUserLogin/_ByYear.cshtml";
            }

            ViewBag.ByValue = byValue;
            return PartialView(partialView);
        }

        public HistoricalUserLoginResponse GetDataList()
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/HistoricalUserLogin/GetHistoricalUserLoginList";

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                request.AuthenticationToken = token;
                //call api
                response = JsonConvert.DeserializeObject<HistoricalUserLoginResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
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

        public ActionResult GetDataListBy(string byValue)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "";
            if (byValue == "1")
            {
                apiUrl = "api/HistoricalUserLogin/GetHistoricalUserLoginListByDate";
            }
            else if (byValue == "2")
            {
                apiUrl = "api/HistoricalUserLogin/GetHistoricalUserLoginListByMonth";
            }
            else
            {
                apiUrl = "api/HistoricalUserLogin/GetHistoricalUserLoginListByYear";
            }

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                request.AuthenticationToken = token;
                request.Login = DateTime.Now;
                //call api
                response = JsonConvert.DeserializeObject<HistoricalUserLoginResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.end);
            }

            return Json(response);
        }

        public ActionResult EditorFormPartial(int id)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/HistoricalUserLogin/GetHistoricalUserLoginFindBy";

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                request.AuthenticationToken = token;
                request.Id = id;
                //call api if not adding / create
                if (id > 0)
                {
                    response = JsonConvert.DeserializeObject<HistoricalUserLoginResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
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
            
            return PartialView("_HistoricalUserLogin", response.HistoricalUserLoginResult);
        }

        public ActionResult Create(HistoricalUserLoginRequest model)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/HistoricalUserLogin/InsertHistoricalUserLogin";

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
                response = JsonConvert.DeserializeObject<HistoricalUserLoginResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
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

        public ActionResult Update(HistoricalUserLoginRequest model)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/HistoricalUserLogin/UpdateHistoricalUserLogin";

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

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
                response = JsonConvert.DeserializeObject<HistoricalUserLoginResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
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
            string apiUrl = "api/HistoricalUserLogin/DeleteHistoricalUserLogin";

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                request.AuthenticationToken = token;
                request.Id = id;
                //call api
                response = JsonConvert.DeserializeObject<HistoricalUserLoginResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
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