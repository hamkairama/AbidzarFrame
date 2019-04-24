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
    public class DetailPemiluController : WebLogManager
    {

        #region Private Instance
        private FunctionLog functionLog = new FunctionLog();
        private const string controller = "DetailPemiluController";
        private string token = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken;
        private ResultStatus result = new ResultStatus();
        BusinessErrors bussinessError = new BusinessErrors();
        DetailPemiluRequest request = new DetailPemiluRequest();
        DetailPemiluResponse response = new DetailPemiluResponse();
        protected ErrorHandler _errHand
        {
            get { return new ErrorHandler(); }
        }
        #endregion

        #region Contructor 
        public DetailPemiluController()
        {
        }
        #endregion

        public ActionResult Index(int idPemilu)
        {
            bool isUserHasBeenSelected = false;
            try
            {
                //get detail pemilu
                response = GetDataListByIdPemilu(idPemilu);

                //check if user has been selected paslon
                if (response.Count > 0)
                {
                    isUserHasBeenSelected = IsUserHasBeenSelected(CurrentUser.GetCurrentUserId(), idPemilu);
                }
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message, JsonRequestBehavior.AllowGet);
            }

            ViewBag.IdPemilu = idPemilu;
            ViewBag.IsUserHasBeenSelected = isUserHasBeenSelected;
            return View(response.DetailPemiluResultList.OrderBy(x => x.NoUrut).ToList());
        }

        public bool IsUserHasBeenSelected(string nik, int idPemilu)
        {
            bool result = false;
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/PollingPEmilu/GetPollingPemiluFindByNik";
            PollingPemiluRequest polRequest = new PollingPemiluRequest();
            PollingPemiluResponse polResponse = new PollingPemiluResponse();

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                polRequest.AuthenticationToken = token;
                polRequest.Nik = nik;
                polRequest.IdPemilu = idPemilu;
                polResponse = JsonConvert.DeserializeObject<PollingPemiluResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, polRequest));

                if (polResponse.PollingPemiluResult != null)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
                return false;
            }
            finally
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.end);
            }

            return result;
        }

        public ActionResult Read()
        {
            try
            {
                response = GetDataList();
                var data = response.DetailPemiluResultList;
                return Json(new { data = data.ToList() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public DetailPemiluResponse GetDataListByIdPemilu(int idPemilu)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/DetailPemilu/GetDetailPemiluListByIdPemilu";

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                request.AuthenticationToken = token;
                request.IdPemilu = idPemilu;
                //call api
                response = JsonConvert.DeserializeObject<DetailPemiluResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
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

        public DetailPemiluResponse GetDataList()
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/DetailPemilu/GetDetailPemiluList";

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                request.AuthenticationToken = token;
                //call api
                response = JsonConvert.DeserializeObject<DetailPemiluResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
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

        public ActionResult EditorFormPartialCreate(int id)
        {
            ViewBag.ActionGrid = "Add";
            ViewBag.IdPemilu = id;
            return PartialView("_DetailPemilu", response.DetailPemiluResult);
        }

        public ActionResult EditorFormPartialEdit(int id)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/DetailPemilu/GetDetailPemiluFindBy";

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                request.AuthenticationToken = token;
                request.Id = id;
                //call api if not adding / create
                if (id > 0)
                {
                    response = JsonConvert.DeserializeObject<DetailPemiluResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
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

            ViewBag.ActionGrid = "Edit";
            return PartialView("_DetailPemilu", response.DetailPemiluResult);
        }


        public ActionResult Create(DetailPemiluRequest model)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/DetailPemilu/InsertDetailPemilu";

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
                List<string> lString = CData.GetListString;

                //call api
                request.DibuatOleh = CurrentUser.GetCurrentUserId();
                request.FileName = lString[0];
                response = JsonConvert.DeserializeObject<DetailPemiluResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
                if (!response.ResultStatus.IsSuccess)
                {
                    CData.CleanDataString();
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
                CData.CleanDataString();
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.end);
            }

            return Json(new { success = true, Msg = "Success Insert Data" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(DetailPemiluRequest model)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/DetailPemilu/UpdateDetailPemilu";

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                if (string.IsNullOrWhiteSpace(model.Kandidat))
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

                List<string> lString = CData.GetListString;
                request = model;
                request.AuthenticationToken = token;
                request.FileName = lString[0];
                request.DieditOleh = CurrentUser.GetCurrentUserId();
                //call api
                response = JsonConvert.DeserializeObject<DetailPemiluResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
                if (!response.ResultStatus.IsSuccess)
                {
                    CData.CleanDataString();
                    return JsonError(response.ResultStatus.MessageText, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                CData.CleanDataString();
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.end);
            }


            return Json(new { success = true, Msg = "Success Update Data" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {

            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/DetailPemilu/DeleteDetailPemilu";

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                request.AuthenticationToken = token;
                request.Id = id;
                //call api
                response = JsonConvert.DeserializeObject<DetailPemiluResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
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