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
    [RoutePrefix("api/Biodata")]
    public class BiodataController : WebLogManager
    {
        #region Private Instance
        private BiodataResponse response = new BiodataResponse();
        private BusinessErrors errors = new BusinessErrors();
        private FunctionLog functionLog = new FunctionLog();
        private const string controller = "BiodataController";
        #endregion

        #region Contructor 
        IMasterManager manager;
        public BiodataController()
        {
            manager = new MasterManager();
        }
        #endregion


        [HttpPost]
        [Route("GetBiodataFindBy")]
        public BiodataResponse GetBiodataFindBy(BiodataRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            if (VerifyAuthenticationToken(request.AuthenticationToken))
            {                
                response = manager.GetBiodataFindBy(request);
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
        [Route("GetBiodataList")]
        public BiodataResponse GetBiodataList(BiodataRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            if (VerifyAuthenticationToken(request.AuthenticationToken))
            {
                response = manager.GetBiodataList(request);
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
        [Route("InsertBiodata")]
        public BiodataResponse InsertBiodata(BiodataRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            if (VerifyAuthenticationToken(request.AuthenticationToken))
            {
                response = manager.InsertBiodata(request);
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
        [Route("UpdateBiodata")]
        public BiodataResponse UpdateBiodata(BiodataRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            if (VerifyAuthenticationToken(request.AuthenticationToken))
            {
                response = manager.UpdateBiodata(request);
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
        [Route("DeleteBiodata")]
        public BiodataResponse DeleteBiodata(BiodataRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            if (VerifyAuthenticationToken(request.AuthenticationToken))
            {
                response = manager.DeleteBiodata(request);
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
        [Route("GetBiodataByNik")]
        public BiodataResponse GetBiodataByNik(BiodataRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            if (VerifyAuthenticationToken(request.AuthenticationToken))
            {
                response = manager.GetBiodataByNik(request);
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
