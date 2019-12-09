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
    [RoutePrefix("api/LandingPageLevelProperty")]
    public class LandingPageLevelPropertyController : WebLogManager
    {
        #region Private Instance
        private LandingPageLevelPropertyResponse response = new LandingPageLevelPropertyResponse();
        private BusinessErrors errors = new BusinessErrors();
        private FunctionLog functionLog = new FunctionLog();
        private const string controller = "LandingPageLevelPropertyController";

        #endregion

        #region Contructor 
        IMasterManager manager;
        public LandingPageLevelPropertyController()
        {
            manager = new MasterManager();
        }
        #endregion


        [HttpPost]
        [Route("GetLandingPageLevelPropertyFindBy")]
        public LandingPageLevelPropertyResponse GetLandingPageLevelPropertyFindBy(LandingPageLevelPropertyRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            if (VerifyAuthenticationToken(request.AuthenticationToken))
            {                
                response = manager.GetLandingPageLevelPropertyFindBy(request);
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
        [Route("GetLandingPageLevelPropertyList")]
        public LandingPageLevelPropertyResponse GetLandingPageLevelPropertyList(LandingPageLevelPropertyRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            if (VerifyAuthenticationToken(request.AuthenticationToken))
            {
                response = manager.GetLandingPageLevelPropertyList(request);
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
        [Route("InsertLandingPageLevelProperty")]
        public LandingPageLevelPropertyResponse InsertLandingPageLevelProperty(LandingPageLevelPropertyRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            if (VerifyAuthenticationToken(request.AuthenticationToken))
            {
                response = manager.InsertLandingPageLevelProperty(request);
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
        [Route("UpdateLandingPageLevelProperty")]
        public LandingPageLevelPropertyResponse UpdateLandingPageLevelProperty(LandingPageLevelPropertyRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            if (VerifyAuthenticationToken(request.AuthenticationToken))
            {
                response = manager.UpdateLandingPageLevelProperty(request);
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
        [Route("DeleteLandingPageLevelProperty")]
        public LandingPageLevelPropertyResponse DeleteLandingPageLevelProperty(LandingPageLevelPropertyRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            if (VerifyAuthenticationToken(request.AuthenticationToken))
            {
                response = manager.DeleteLandingPageLevelProperty(request);
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
