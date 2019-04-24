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
    [RoutePrefix("api/DokumentasiDetailJenisKegiatan")]
    public class DokumentasiDetailJenisKegiatanController : WebLogManager
    {
        #region Private Instance
        private DokumentasiDetailJenisKegiatanResponse response = new DokumentasiDetailJenisKegiatanResponse();
        private BusinessErrors errors = new BusinessErrors();
        private FunctionLog functionLog = new FunctionLog();
        private const string controller = "DokumentasiDetailJenisKegiatanController";

        #endregion

        #region Contructor 
        IMasterManager manager;
        public DokumentasiDetailJenisKegiatanController()
        {
            manager = new MasterManager();
        }
        #endregion


        [HttpPost]
        [Route("GetDokumentasiDetailJenisKegiatanFindBy")]
        public DokumentasiDetailJenisKegiatanResponse GetDokumentasiDetailJenisKegiatanFindBy(DokumentasiDetailJenisKegiatanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            if (VerifyAuthenticationToken(request.AuthenticationToken))
            {                
                response = manager.GetDokumentasiDetailJenisKegiatanFindBy(request);
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
        [Route("GetDokumentasiDetailJenisKegiatanList")]
        public DokumentasiDetailJenisKegiatanResponse GetDokumentasiDetailJenisKegiatanList(DokumentasiDetailJenisKegiatanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            if (VerifyAuthenticationToken(request.AuthenticationToken))
            {
                response = manager.GetDokumentasiDetailJenisKegiatanList(request);
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
        [Route("GetDokumentasiDetailJenisKegiatanListByIdDetailJenisKegiatan")]
        public DokumentasiDetailJenisKegiatanResponse GetDokumentasiDetailJenisKegiatanListByIdDetailJenisKegiatan(DokumentasiDetailJenisKegiatanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            if (VerifyAuthenticationToken(request.AuthenticationToken))
            {
                response = manager.GetDokumentasiDetailJenisKegiatanListByIdDetailJenisKegiatan(request);
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
        [Route("InsertDokumentasiDetailJenisKegiatan")]
        public DokumentasiDetailJenisKegiatanResponse InsertDokumentasiDetailJenisKegiatan(DokumentasiDetailJenisKegiatanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            if (VerifyAuthenticationToken(request.AuthenticationToken))
            {
                response = manager.InsertDokumentasiDetailJenisKegiatan(request);
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
        [Route("UpdateDokumentasiDetailJenisKegiatan")]
        public DokumentasiDetailJenisKegiatanResponse UpdateDokumentasiDetailJenisKegiatan(DokumentasiDetailJenisKegiatanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            if (VerifyAuthenticationToken(request.AuthenticationToken))
            {
                response = manager.UpdateDokumentasiDetailJenisKegiatan(request);
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
        [Route("DeleteDokumentasiDetailJenisKegiatan")]
        public DokumentasiDetailJenisKegiatanResponse DeleteDokumentasiDetailJenisKegiatan(DokumentasiDetailJenisKegiatanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            if (VerifyAuthenticationToken(request.AuthenticationToken))
            {
                response = manager.DeleteDokumentasiDetailJenisKegiatan(request);
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
