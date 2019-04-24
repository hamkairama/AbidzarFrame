using AbidzarFrame.Core.Model.Business;
using AbidzarFrame.Core.Mvc.Helpers;
using AbidzarFrame.Domain.Common;
using AbidzarFrame.Master.Interface.Dto;
using AbidzarFrame.Utils;
using AbidzarFrame.Web.Helpers;
using AbidzarFrame.Web.WebApiLocal;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace AbidzarFrame.Web.Areas.Kegiatan.Controllers
{
    public class AppointmentDiaryController : WebLogManager
    {
        #region Private Instance
        private FunctionLog functionLog = new FunctionLog();
        private const string controller = "AppointmentDiaryController";
        private string token = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken;
        private ResultStatus result = new ResultStatus();
        BusinessErrors bussinessError = new BusinessErrors();
        JenisKegiatanRequest request = new JenisKegiatanRequest();
        JenisKegiatanResponse response = new JenisKegiatanResponse();
        protected ErrorHandler _errHand
        {
            get { return new ErrorHandler(); }
        }
        #endregion

        #region Contructor 
        public AppointmentDiaryController()
        {
        }
        #endregion

        // GET: Kegiatan/Kegiatan
        public ActionResult Index()
        {
            ViewBag.KtpList = DropDown.GetKtpList();
            return View();
        }

        public string Init()
        {
            bool rslt = false;
            //rslt = Utils.InitialiseDiary();
            return rslt.ToString();
        }

        public bool UpdateEvent(int Id, string NewEventStart, string NewEventEnd)
        {
            Helpers.DiaryEvent diaryEvent = new Helpers.DiaryEvent();
            return diaryEvent.UpdateDiaryEvent(Id, NewEventStart, NewEventEnd);
        }


        public bool SaveEvent(string Title, string NewEventDate, string NewEventTime, string NewEventDuration)
        {
            Helpers.DiaryEvent diaryEvent = new Helpers.DiaryEvent();
            return diaryEvent.CreateNewEvent(Title, NewEventDate, NewEventTime, NewEventDuration);
        }

        public JsonResult GetDiarySummary(double start, double end)
        {
            Helpers.DiaryEvent diaryEvent = new Helpers.DiaryEvent();

            var ApptListForDate = diaryEvent.LoadAppointmentSummaryInDateRange(start, end);
            var eventList = from e in ApptListForDate
                            select new
                            {
                                id = e.ID,
                                title = e.Title,
                                start = e.StartDateString,
                                end = e.EndDateString,
                                someKey = e.SomeImportantKeyID,
                                allDay = false
                            };
            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDiaryEvents(double start, double end)
        {
            Helpers.DiaryEvent diaryEvent = new Helpers.DiaryEvent();

            var ApptListForDate = diaryEvent.LoadAllAppointmentsInDateRange(start, end);
            var eventList = from e in ApptListForDate
                            select new
                            {
                                id = e.ID,
                                title = e.Title,
                                start = e.StartDateString,
                                end = e.EndDateString,
                                color = e.StatusColor,
                                className = e.ClassName,
                                someKey = e.SomeImportantKeyID,
                                allDay = false
                            };
            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        public ActionResult IsMathAppointment()
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/AppointmentDiary/GetAppointmentDiarySelectByTitle";
            AppointmentDiaryRequest request = new AppointmentDiaryRequest();
            AppointmentDiaryResponse response = new AppointmentDiaryResponse();
            request.AuthenticationToken = token;
            request.Title = CurrentUser.GetCurrentUserName();

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                response = JsonConvert.DeserializeObject<AppointmentDiaryResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
                if (response.AppointmentDiaryResultList.Count() == 0)
                {
                    return Json(new { success = false, Msg = "false" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message.ToString(), JsonRequestBehavior.AllowGet);
            }
            finally
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.end);
            }

            return Json(new { success = true, Msg = "true" }, JsonRequestBehavior.AllowGet);
        }

    }
}