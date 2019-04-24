using AbidzarFrame.Core.Model.Business;
using AbidzarFrame.Core.Mvc.Helpers;
using AbidzarFrame.Domain.Common;
using AbidzarFrame.Domain.Models;
using AbidzarFrame.Reports.Interface.Dto;
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

namespace AbidzarFrame.Web.Areas.Reports.Controllers
{
    public class RekapLaporanKasController : WebLogManager
    {

        #region Private Instance
        private FunctionLog functionLog = new FunctionLog();
        private const string controller = "LaporanKasController";
        private string token = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken;
        private ResultStatus result = new ResultStatus();
        BusinessErrors bussinessError = new BusinessErrors();
        LaporanKasRequest request = new LaporanKasRequest();
        LaporanKasResponse response = new LaporanKasResponse();
        protected ErrorHandler _errHand
        {
            get { return new ErrorHandler(); }
        }
        #endregion

        #region Contructor 
        public RekapLaporanKasController()
        {
        }
        #endregion

        public ActionResult Index()
        {
            string method = MethodBase.GetCurrentMethod().Name;
            List<LaporanKasResult> dataList = new List<LaporanKasResult>();
            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);
                response = GetDataListByDate(CurrentUser.GetCurrentDateTime());
                if (response.Count > 0)
                {
                    dataList = response.LaporanKasResultList.Where(x => x.Tipe == "0").ToList();
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

            ViewBag.Date = DateTime.Now.ToString("MMM yyyy");
            ViewBag.ByValue = "Pemasukan";

            return View(dataList);
        }
 
        public LaporanKasResponse GetDataListByDate(DateTime dt)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/LaporanKas/GetLaporanKasListByDate";

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                request.AuthenticationToken = token;
                request.Tanggal = dt;
                request.KodeRt = CurrentUser.GetCurrentKodeRt();
                //call api
                response = JsonConvert.DeserializeObject<LaporanKasResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
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

        public LaporanKasResponse GetDataListByYear(DateTime dt)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/LaporanKas/GetLaporanKasListByYear";

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                request.AuthenticationToken = token;
                request.Tanggal = dt;
                request.KodeRt = CurrentUser.GetCurrentKodeRt();
                //call api
                response = JsonConvert.DeserializeObject<LaporanKasResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
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

        public ActionResult GetPemasukan(DateTime dt)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            List<LaporanKasResult> dataList = new List<LaporanKasResult>();
            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);
                response = GetDataListByDate(dt);
                if (response.Count > 0)
                {
                    dataList = response.LaporanKasResultList.Where(x => x.Tipe == "0").ToList();
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

            ViewBag.Date = dt.ToString("MMM yyyy");
            ViewBag.ByValue = "Pemasukan";

            return PartialView("~/Areas/Reports/Views/RekapLaporanKas/_Pemasukan.cshtml", dataList);
        }

        public ActionResult GetPengeluaran(DateTime dt)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            List<LaporanKasResult> dataList = new List<LaporanKasResult>();

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);
                response = GetDataListByDate(dt);
                if (response.Count > 0)
                {
                    dataList = response.LaporanKasResultList.Where(x => x.Tipe == "1").ToList();
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

            ViewBag.Date = dt.ToString("MMM yyyy");
            ViewBag.ByValue = "Pengeluaran";

            return PartialView("~/Areas/Reports/Views/RekapLaporanKas/_Pengeluaran.cshtml", dataList);
        }

        public ActionResult GetSummary(DateTime dt)
        {
            string method = MethodBase.GetCurrentMethod().Name;

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);
                response = GetDataListByDate(dt);
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.end);
            }
            ViewBag.Date = dt.ToString("yyyy");
            ViewBag.ByValue = "Summary";

            return PartialView("~/Areas/Reports/Views/RekapLaporanKas/_Summary.cshtml", response.LaporanKasResultList);
        }
    }
}