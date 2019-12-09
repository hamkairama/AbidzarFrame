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
    [RoutePrefix("api/LandingPageLevel")]
    public class LandingPageLevelController : WebLogManager
    {
        #region Private Instance
        private LandingPageLevelResponse response = new LandingPageLevelResponse();
        private BusinessErrors errors = new BusinessErrors();
        private FunctionLog functionLog = new FunctionLog();
        private const string controller = "LandingPageLevelController";

        #endregion

        #region Contructor 
        IMasterManager manager;
        public LandingPageLevelController()
        {
            manager = new MasterManager();
        }
        #endregion


        [HttpPost]
        [Route("GetLandingPageLevelFindBy")]
        public LandingPageLevelResponse GetLandingPageLevelFindBy(LandingPageLevelRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            if (VerifyAuthenticationToken(request.AuthenticationToken))
            {                
                response = manager.GetLandingPageLevelFindBy(request);
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
        [Route("GetLandingPageLevelList")]
        public LandingPageLevelResponse GetLandingPageLevelList(LandingPageLevelRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            if (VerifyAuthenticationToken(request.AuthenticationToken))
            {
                response = manager.GetLandingPageLevelList(request);
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
        [Route("InsertLandingPageLevel")]
        public LandingPageLevelResponse InsertLandingPageLevel(LandingPageLevelRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            if (VerifyAuthenticationToken(request.AuthenticationToken))
            {
                response = manager.InsertLandingPageLevel(request);
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
        [Route("UpdateLandingPageLevel")]
        public LandingPageLevelResponse UpdateLandingPageLevel(LandingPageLevelRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            if (VerifyAuthenticationToken(request.AuthenticationToken))
            {
                response = manager.UpdateLandingPageLevel(request);
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
        [Route("DeleteLandingPageLevel")]
        public LandingPageLevelResponse DeleteLandingPageLevel(LandingPageLevelRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            if (VerifyAuthenticationToken(request.AuthenticationToken))
            {
                response = manager.DeleteLandingPageLevel(request);
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
