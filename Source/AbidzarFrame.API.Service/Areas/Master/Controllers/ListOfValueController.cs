using AbidzarFrame.Core.Model.Business;
using AbidzarFrame.Core.Mvc.Helpers;
using AbidzarFrame.Master.Interface;
using AbidzarFrame.Master.Interface.Dto;
using AbidzarFrame.Master.Manager;
using AbidzarFrame.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace AbidzarFrame.API.Service.Areas.Master.Controllers
{
    [RoutePrefix("api/ListOfValue")]
    public class ListOfValueController : WebLogManager
    {
        #region Private Instance
        private ListOfValueResponse response = new ListOfValueResponse();
        private BusinessErrors errors = new BusinessErrors();
        private FunctionLog functionLog = new FunctionLog();
        private const string controller = "ListOfValueController";

        #endregion

        #region Contructor 
        IMasterManager manager;
        public ListOfValueController()
        {
            manager = new MasterManager();
        }
        #endregion


        [HttpPost]
        [Route("GetListOfValueFindBy")]
        public ListOfValueResponse GetListOfValueFindBy(ListOfValueRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            if (VerifyAuthenticationToken(request.AuthenticationToken))
            {                
                response = manager.GetListOfValueFindBy(request);
            }
            else
            {
                functionLog.WriteFunctionAuthentication(controller, method, 1, LogData.STAGE.unknown, Utils.ErrorMessages.AUTH_ERROR);
                errors.Add(Utils.ErrorMessages.AUTH_ERROR);
                response.Errors = errors;
            }         

            return response;
        }

        [HttpPost]
        [Route("GetListOfValueList")]
        public ListOfValueResponse GetListOfValueList(ListOfValueRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            if (VerifyAuthenticationToken(request.AuthenticationToken))
            {
                response = manager.GetListOfValueList(request);
            }
            else
            {
                functionLog.WriteFunctionAuthentication(controller, method, 1, LogData.STAGE.unknown, Utils.ErrorMessages.AUTH_ERROR);
                errors.Add(Utils.ErrorMessages.AUTH_ERROR);
                response.Errors = errors;
            }

            return response;
        }


        [HttpPost]
        [Route("InsertListOfValue")]
        public ListOfValueResponse InsertListOfValue(ListOfValueRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            if (VerifyAuthenticationToken(request.AuthenticationToken))
            {
                response = manager.InsertListOfValue(request);
            }
            else
            {
                functionLog.WriteFunctionAuthentication(controller, method, 1, LogData.STAGE.unknown, Utils.ErrorMessages.AUTH_ERROR);
                errors.Add(Utils.ErrorMessages.AUTH_ERROR);
                response.Errors = errors;
            }

            return response;
        }

        [HttpPost]
        [Route("UpdateListOfValue")]
        public ListOfValueResponse UpdateListOfValue(ListOfValueRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            if (VerifyAuthenticationToken(request.AuthenticationToken))
            {
                response = manager.UpdateListOfValue(request);
            }
            else
            {
                functionLog.WriteFunctionAuthentication(controller, method, 1, LogData.STAGE.unknown, Utils.ErrorMessages.AUTH_ERROR);
                errors.Add(Utils.ErrorMessages.AUTH_ERROR);
                response.Errors = errors;
            }

            return response;
        }

        [HttpPost]
        [Route("DeleteListOfValue")]
        public ListOfValueResponse DeleteListOfValue(ListOfValueRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            if (VerifyAuthenticationToken(request.AuthenticationToken))
            {
                response = manager.DeleteListOfValue(request);
            }
            else
            {
                functionLog.WriteFunctionAuthentication(controller, method, 1, LogData.STAGE.unknown, Utils.ErrorMessages.AUTH_ERROR);
                errors.Add(Utils.ErrorMessages.AUTH_ERROR);
                response.Errors = errors;
            }

            return response;
        }
    }
}
