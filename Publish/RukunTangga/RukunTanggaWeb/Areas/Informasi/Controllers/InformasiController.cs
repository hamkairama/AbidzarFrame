using AbidzarFrame.Core.Model.Business;
using AbidzarFrame.Core.Mvc.Helpers;
using AbidzarFrame.Domain.Common;
using AbidzarFrame.Master.Interface.Dto;
using AbidzarFrame.Utils;
using AbidzarFrame.Web.Helpers;
using AbidzarFrame.Web.WebApiLocal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace AbidzarFrame.Web.Areas.Informasi.Controllers
{
    public class InformasiController : WebLogManager
    {
        #region Private Instance
        private FunctionLog functionLog = new FunctionLog();
        private const string controller = "InformasiController";
        private string token = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken;
        private ResultStatus result = new ResultStatus();
        BusinessErrors bussinessError = new BusinessErrors();
        JenisInformasiRequest request = new JenisInformasiRequest();
        JenisInformasiResponse response = new JenisInformasiResponse();
        protected ErrorHandler _errHand
        {
            get { return new ErrorHandler(); }
        }
        #endregion

        #region Contructor 
        public InformasiController()
        {
        }
        #endregion
        // GET: Informasi/Informasi
        public ActionResult Index()
        {
            response = GetDataList();
            return View(response.JenisInformasiResultList);
        }

        public JenisInformasiResponse GetDataList()
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/JenisInformasi/GetJenisInformasiList";

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                request.AuthenticationToken = token;
                request.KodeRt = CurrentUser.GetCurrentKodeRt();
                //call api
                response = JsonConvert.DeserializeObject<JenisInformasiResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
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
    }
}