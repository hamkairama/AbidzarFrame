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
using AbidzarFrame.Web.Areas.Security.Models;

namespace AbidzarFrame.Web.Areas.Security.Controllers
{
    public class RoleMenuController : WebLogManager
    {
        #region Private Instance
        private FunctionLog functionLog = new FunctionLog();
        private const string controller = "RoleMenuController";
        private string token = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken;
        private ResultStatus result = new ResultStatus();
        BusinessErrors bussinessError = new BusinessErrors();
        RoleMenuRequest request = new RoleMenuRequest();
        RoleMenuResponse response = new RoleMenuResponse();
        protected ErrorHandler _errHand
        {
            get { return new ErrorHandler(); }
        }
        #endregion

        #region Contructor 
        public RoleMenuController()
        {
        }
        #endregion
        // GET: Security/RoleMenu
        public ActionResult Index(string ddlRoleId)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/RoleMenu/GetRoleMenuListByRoleId";
            ViewBag.MsgScs = TempData["MsgScs"];
            ViewBag.MsgErr = TempData["MsgErr"];

            RoleMenuViewModel model = new RoleMenuViewModel()
            {
                RoleMenuBaseModelList = new List<RoleMenuViewModel>()
            };

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                if (ddlRoleId == null)
                {
                    ddlRoleId = "ADM";
                }

                request.AuthenticationToken = token;
                request.IdRole = ddlRoleId;
                response = JsonConvert.DeserializeObject<RoleMenuResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
                model.RoleMenuBaseModelList = response.RoleMenuResultList; //Mapper.Map(query.RoleMenuResultList, model.RoleMenuBaseModelList);

                List<string> modes = new List<string>();
                model.ArrayMenuId = new List<string>();

                foreach (var mdl in model.RoleMenuBaseModelList)
                {
                    if (mdl.HaveAccess == true)
                    {
                        modes.Add(Convert.ToString(mdl.IdMenu));//array javascript
                        model.ArrayMenuId.Add(Convert.ToString(mdl.IdMenu));//array model
                    }
                };
                ViewBag.ArrayLoadId = modes;

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
            return View("Index", model);
        }

        [HttpPost]
        public ActionResult Update(RoleMenuViewModel model, List<string> array)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            RoleMenuRequest request = new RoleMenuRequest();

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                if (string.IsNullOrWhiteSpace(model.IdRole))
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

                request.DieditOleh = CurrentUser.GetCurrentUserId();

                //delete dulu semua sesuai role id
                string deleteUrl = "api/RoleMenu/DeleteRoleMenu";
                request.AuthenticationToken = token;
                request.IdRole = model.IdRole;
                var doProcessDelete = JsonConvert.DeserializeObject<RoleMenuResponse>(JasonMapper.ConvertHttpResponseToJson(deleteUrl, request));

                if (doProcessDelete.Errors.HasError)
                {
                    throw new InvalidOperationException(exceptionWcf(doProcessDelete.Errors));
                }

                //kemudian di insert lagi
                if (array != null)
                {
                    for (int i = 0; i < array.Count; i++)
                    {
                        request.IdMenu = Convert.ToInt32(array[i]);
                        string insertUrl = "api/RoleMenu/InsertRoleMenu";
                        request.DibuatOleh = CurrentUser.GetCurrentUserId();
                        var doProcessInsert = JsonConvert.DeserializeObject<RoleMenuResponse>(JasonMapper.ConvertHttpResponseToJson(insertUrl, request));
                        if (doProcessInsert.Errors.HasError)
                        {
                            throw new InvalidOperationException(exceptionWcf(doProcessInsert.Errors));
                        }
                    }
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

        private void LoadData()
        {
            ViewBag.RoleList = DropDown.GetRoleList();
        }
    }
}