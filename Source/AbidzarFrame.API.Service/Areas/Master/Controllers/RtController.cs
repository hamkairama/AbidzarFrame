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
    [RoutePrefix("api/Rt")]
    public class RtController : WebLogManager
    {
        #region Private Instance
        private RtResponse response = new RtResponse();
        private BusinessErrors errors = new BusinessErrors();
        private FunctionLog functionLog = new FunctionLog();
        private const string controller = "RtController";

        #endregion

        #region Contructor 
        IMasterManager manager;
        public RtController()
        {
            manager = new MasterManager();
        }
        #endregion


        [HttpPost]
        [Route("GetRtFindBy")]
        public RtResponse GetRtFindBy(RtRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            if (VerifyAuthenticationToken(request.AuthenticationToken))
            {                
                response = manager.GetRtFindBy(request);
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
        [Route("GetRtList")]
        public RtResponse GetRtList(RtRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            if (VerifyAuthenticationToken(request.AuthenticationToken))
            {
                response = manager.GetRtList(request);
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
        [Route("InsertRt")]
        public RtResponse InsertRt(RtRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            if (VerifyAuthenticationToken(request.AuthenticationToken))
            {
                response = manager.InsertRt(request);
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
        [Route("UpdateRt")]
        public RtResponse UpdateRt(RtRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            if (VerifyAuthenticationToken(request.AuthenticationToken))
            {
                response = manager.UpdateRt(request);
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
        [Route("DeleteRt")]
        public RtResponse DeleteRt(RtRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            if (VerifyAuthenticationToken(request.AuthenticationToken))
            {
                response = manager.DeleteRt(request);
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
        [Route("GetRtByIdRw")]
        public RtResponse GetRtByIdRw(RtRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            if (VerifyAuthenticationToken(request.AuthenticationToken))
            {
                response = manager.GetRtByIdRw(request);
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
