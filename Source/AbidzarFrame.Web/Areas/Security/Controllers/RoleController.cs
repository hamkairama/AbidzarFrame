﻿using AbidzarFrame.Core.Model.Business;
using AbidzarFrame.Core.Mvc.Helpers;
using AbidzarFrame.Domain.Common;
using AbidzarFrame.Domain.Models;
using AbidzarFrame.Master.Interface.Dto;
using AbidzarFrame.Mvc.Infrastructures.ActionResult;
using AbidzarFrame.Security.Interface.Dto;
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
    public class RoleController : WebLogManager
    {

        #region Private Instance
        private FunctionLog functionLog = new FunctionLog();
        private const string controller = "RoleController";
        private string token = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken;
        private ResultStatus result = new ResultStatus();
        BusinessErrors bussinessError = new BusinessErrors();
        RoleRequest request = new RoleRequest();
        RoleResponse response = new RoleResponse();
        protected ErrorHandler _errHand
        {
            get { return new ErrorHandler(); }
        }
        #endregion

        #region Contructor 
        public RoleController()
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
                var data = response.RoleResultList;
                return Json(new { data = data.ToList() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }


        public RoleResponse GetDataList()
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/Role/GetRoleList";

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                request.AuthenticationToken = token;
                //call api
                response = JsonConvert.DeserializeObject<RoleResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
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

        public ActionResult EditorFormPartial(string id)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/Role/GetRoleFindBy";

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                request.AuthenticationToken = token;
                request.IdRole = id;
                //call api if not adding / create
                if (id != "")
                {
                    response = JsonConvert.DeserializeObject<RoleResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
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

            if (id != "")
            {
                ViewBag.ActionGrid = "Edit";
            }
            else
            {
                ViewBag.ActionGrid = "Add";
            }
            
            return PartialView("_Role", response.RoleResult);
        }

        public ActionResult Create(RoleRequest model)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/Role/InsertRole";

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
                response = JsonConvert.DeserializeObject<RoleResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
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

        public ActionResult Update(RoleRequest model)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/Role/UpdateRole";

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                if (string.IsNullOrWhiteSpace(model.NamaRole))
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
                response = JsonConvert.DeserializeObject<RoleResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
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

        public ActionResult Delete(string id)
        {

            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/Role/DeleteRole";

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                request.AuthenticationToken = token;
                request.IdRole = id;
                //call api
                response = JsonConvert.DeserializeObject<RoleResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
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