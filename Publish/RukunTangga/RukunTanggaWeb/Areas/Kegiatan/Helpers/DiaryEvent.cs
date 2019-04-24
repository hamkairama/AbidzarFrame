using AbidzarFrame.Core.Model.Business;
using AbidzarFrame.Domain.Common;
using AbidzarFrame.Master.Interface.Dto;
using AbidzarFrame.Utils;
using AbidzarFrame.Web.Helpers;
using AbidzarFrame.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace AbidzarFrame.Web.Areas.Kegiatan.Helpers
{
    public class DiaryEvent
    {
        //public int ID;
        //public string Title;
        //public int SomeImportantKeyID;
        //public string StartDateString;
        //public string EndDateString;
        //public string StatusString;
        //public string StatusColor;
        //public string ClassName;

        #region Private Instance
        private FunctionLog functionLog = new FunctionLog();
        private string token = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken;
        private ResultStatus result = new ResultStatus();
        BusinessErrors bussinessError = new BusinessErrors();
        AppointmentDiaryRequest request = new AppointmentDiaryRequest();
        AppointmentDiaryResponse response = new AppointmentDiaryResponse();

        protected FunctionLog _functionLog
        {
            get { return new FunctionLog(); }
        }
        protected ErrorHandler _errHand
        {
            get { return new ErrorHandler(); }
        }
        #endregion

        public List<DairyEventModel> LoadAllAppointmentsInDateRange(double start, double end)
        {
            var fromDate = ConvertFromUnixTimestamp(start);
            var toDate = ConvertFromUnixTimestamp(end);

            string apiUrl = "api/AppointmentDiary/GetAppointmentDiarySelectByDateRange";

            //call api
            request.AuthenticationToken = token;
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.KodeRt = CurrentUser.GetCurrentKodeRt();
            response = JsonConvert.DeserializeObject<AppointmentDiaryResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));

            List<DairyEventModel> result = new List<DairyEventModel>();
            if (response.AppointmentDiaryResultList != null)
            {
                foreach (var item in response.AppointmentDiaryResultList)
                {
                    DairyEventModel rec = new DairyEventModel();
                    rec.ID = item.Id;
                    rec.SomeImportantKeyID = item.SomeImportantKey;
                    rec.StartDateString = item.DateTimeScheduled.ToString("s"); // "s" is a preset format that outputs as: "2009-02-27T12:12:22"
                    rec.EndDateString = item.DateTimeScheduled.AddMinutes(item.AppointmentLength).ToString("s"); // field AppointmentLength is in minutes
                    rec.Title = item.Title + " - " + item.AppointmentLength.ToString() + " mins";
                    rec.StatusString = Web.Helpers.EnumList.GetName<AppointmentStatus>((AppointmentStatus)item.StatusENUM);
                    rec.StatusColor = Web.Helpers.EnumList.GetEnumDescription<AppointmentStatus>(rec.StatusString);
                    string ColorCode = rec.StatusColor.Substring(0, rec.StatusColor.IndexOf(":"));
                    rec.ClassName = rec.StatusColor.Substring(rec.StatusColor.IndexOf(":") + 1, rec.StatusColor.Length - ColorCode.Length - 1);
                    rec.StatusColor = ColorCode;
                    result.Add(rec);
                }
            }

            return result;
        }


        public List<DairyEventModel> LoadAppointmentSummaryInDateRange(double start, double end)
        {

            var fromDate = ConvertFromUnixTimestamp(start);
            var toDate = ConvertFromUnixTimestamp(end);

            string apiUrl = "api/AppointmentDiary/GetAppointmentDiarySelectByDateRange";

            //call api
            request.AuthenticationToken = token;
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.KodeRt = CurrentUser.GetCurrentKodeRt();
            response = JsonConvert.DeserializeObject<AppointmentDiaryResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));

            List<DairyEventModel> result = new List<DairyEventModel>();

            if (response.AppointmentDiaryResultList != null)
            {
                int i = 0;
                foreach (var item in response.AppointmentDiaryResultList)
                {
                    DairyEventModel rec = new DairyEventModel();
                    rec.ID = item.Id; //we dont link this back to anything as its a group summary but the fullcalendar needs unique IDs for each event item (unless its a repeating event)
                    rec.SomeImportantKeyID = -1;
                    rec.StartDateString = item.DateTimeScheduled.ToString("s"); // "s" is a preset format that outputs as: "2009-02-27T12:12:22"
                    rec.EndDateString = item.DateTimeScheduled.AddMinutes(item.AppointmentLength).ToString("s"); // field AppointmentLength is in minutes
                    rec.Title = item.Title;
                    result.Add(rec);
                    i++;
                }
            }
            return result;
        }

        public bool UpdateDiaryEvent(int Id, string NewEventStart, string NewEventEnd)
        {
            try
            {
                string apiUrl = "api/AppointmentDiary/UpdateAppointmentDiary";

                //call api
                request.AuthenticationToken = token;
                request.Id = Id;
                DateTime DateTimeStart = DateTime.Parse(NewEventStart, null, DateTimeStyles.RoundtripKind).ToLocalTime(); // and convert offset to localtime
                request.DateTimeScheduled = DateTimeStart;
                request.DieditOleh = CurrentUser.GetCurrentUserId();

                if (!String.IsNullOrEmpty(NewEventEnd))
                {
                    TimeSpan span = DateTime.Parse(NewEventEnd, null, DateTimeStyles.RoundtripKind).ToLocalTime() - DateTimeStart;
                    request.AppointmentLength = Convert.ToInt32(span.TotalMinutes);
                }
                response = JsonConvert.DeserializeObject<AppointmentDiaryResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
                if (!response.ResultStatus.IsSuccess)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }


        private static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }


        public bool CreateNewEvent(string Title, string NewEventDate, string NewEventTime, string NewEventDuration)
        {
            try
            {
                if (Title == "" || Title == null)
                {
                    return false;
                }

                string apiUrlSelect = "api/AppointmentDiary/GetAppointmentDiarySelectByTitleAndMonth";
                string apiUrl = "api/AppointmentDiary/InsertAppointmentDiary";

                //call api
                request.AuthenticationToken = token;
                request.Title = Title;
                request.DateTimeScheduled = DateTime.ParseExact(NewEventDate + " " + NewEventTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                request.AppointmentLength = Int32.Parse(NewEventDuration);
                request.DibuatOleh = CurrentUser.GetCurrentUserId();
                request.KodeRt = CurrentUser.GetCurrentKodeRt();

                response = JsonConvert.DeserializeObject<AppointmentDiaryResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrlSelect, request));
                if (response.AppointmentDiaryResult != null)
                {
                    return false;
                }
                else
                {
                    response = JsonConvert.DeserializeObject<AppointmentDiaryResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
                    if (!response.ResultStatus.IsSuccess)
                    {
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}