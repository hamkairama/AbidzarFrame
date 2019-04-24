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
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace AbidzarFrame.Web.Areas.StrukturOrganisasi.Controllers
{
    public class StrukturOrganisasiController : WebLogManager
    {
        #region Private Instance
        private FunctionLog functionLog = new FunctionLog();
        private const string controller = "StrukturController";
        private string token = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken;
        private ResultStatus result = new ResultStatus();
        BusinessErrors bussinessError = new BusinessErrors();
        StrukturRequest request = new StrukturRequest();
        StrukturResponse response = new StrukturResponse();
        protected ErrorHandler _errHand
        {
            get { return new ErrorHandler(); }
        }
        #endregion

        #region Contructor 
        public StrukturOrganisasiController()
        {
        }
        #endregion
        // GET: Informasi/Informasi
        public ActionResult Index()
        {
            response = GetDataList();
            return View(response.StrukturResultList);
        }

        public StrukturResponse GetDataList()
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/Struktur/GetStrukturList";

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                request.AuthenticationToken = token;
                request.KodeRt = CurrentUser.GetCurrentKodeRt();
                //call api
                response = JsonConvert.DeserializeObject<StrukturResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
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

        public int SaveCoords(int x, int y, string element, int userid)
        {
            int result = 0;

            //string connect = "Server=MyServer;Database=Tests;Trusted_Connection=True;";
            //using (SqlConnection conn = new SqlConnection(connect))
            //{
            //    string query = "UPDATE Coords SET xPos = @xPos, yPos = @yPos WHERE Element = @Element AND UserID = @UserID";
            //    using (SqlCommand cmd = new SqlCommand(query, conn))
            //    {
            //        cmd.Parameters.AddWithValue("xPos", x);
            //        cmd.Parameters.AddWithValue("yPos", y);
            //        cmd.Parameters.AddWithValue("Element", element);
            //        cmd.Parameters.AddWithValue("UserID", userid);
            //        conn.Open();
            //        result = (int)cmd.ExecuteNonQuery();
            //    }
            //}
            return result;
        }

        public DataTable GetSavedCoords(int userid)
        {
            DataTable dt = new DataTable();
            //string connect = "Server=MyServer;Database=Tests;Trusted_Connection=True;";
            //using (SqlConnection conn = new SqlConnection(connect))
            //{
            //    string query = "SELECT xPos, yPos, Element FROM Coords WHERE UserID = @UserID";
            //    using (SqlCommand cmd = new SqlCommand(query, conn))
            //    {
            //        cmd.Parameters.AddWithValue("UserID", userid);
            //        SqlDataAdapter da = new SqlDataAdapter(cmd);
            //        da.Fill(dt);
            //        return dt;
            //    }
            //}

            return dt;
        }

        public ActionResult Update(StrukturRequest model)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/Struktur/UpdateStrukturByDrag";

            try
            {
                WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                if (!ModelState.IsValid)
                {
                    var errors = new Hashtable();
                    foreach (var pair in ModelState)
                    {
                        if (pair.Value.Errors.Count > 0)
                            errors[pair.Key] = pair.Value.Errors.Select(error => error.ErrorMessage).ToList();
                    }
                    return Json(new { success = false, errors }, JsonRequestBehavior.AllowGet);
                }

                request = model;
                request.AuthenticationToken = token;
                request.DieditOleh = CurrentUser.GetCurrentUserId();
                //call api
                response = JsonConvert.DeserializeObject<StrukturResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
                if (!response.ResultStatus.IsSuccess)
                {
                    return JsonError(response.ResultStatus.MessageText, JsonRequestBehavior.AllowGet);
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


            return Json(new { success = true, Msg = "Success Update Data" }, JsonRequestBehavior.AllowGet);
        }
    }
}