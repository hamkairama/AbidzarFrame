using AbidzarFrame.Core.Model.Business;
using AbidzarFrame.Core.Mvc.Helpers;
using AbidzarFrame.Domain.Common;
using AbidzarFrame.Domain.Models;
using AbidzarFrame.Master.Interface.Dto;
using AbidzarFrame.Mvc.Infrastructures.ActionResult;
using AbidzarFrame.Security.Interface.Dto;
using AbidzarFrame.Utils;
using AbidzarFrame.Web.Helpers;
using AbidzarFrame.Web.Models;
using AbidzarFrame.Web.WebApiLocal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AbidzarFrame.Web.Controllers
{
    public class AccountController : Controller
    {
        #region Private Instance
        private FunctionLog functionLog = new FunctionLog();
        private const string controller = "AccountController";
        private string token = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken;
        private ResultStatus result = new ResultStatus();
        protected FunctionLog _functionLog
        {
            get { return new FunctionLog(); }
        }
        protected ErrorHandler _errHand
        {
            get { return new ErrorHandler(); }
        }
        #endregion

        #region Contructor 
        public AccountController()
        {
        }
        #endregion

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        //[AllowAnonymous]
        public ActionResult Login()
        {
            Session["NamaPerusahaan"] = Common.GetParameterValue("001");

            ViewBag.MsgScs = TempData["MsgScs"];
            return View();
        }

        [HttpPost]
        //[AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            string apiUrl = "api/User/GetUserFindBy";
            UserRequest request = new UserRequest();
            UserResponse response = new UserResponse();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                if (IsApiLogin(model))
                {
                    return RedirectToAction("Index", "Home", new { area = "" });
                }

                _functionLog.WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                request.AuthenticationToken = token;
                request.Nik = model.IdUser;
                request.Sandi = Cryptoghrap.EncryptString(model.Sandi);

                response = JsonConvert.DeserializeObject<UserResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));

            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
                ModelState.AddModelError("", ex.Message);
            }
            finally
            {
                _functionLog.WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.end);
            }

            if (response.UserResult != null)
            {
                //if user is not active
                if (!response.UserResult.Status)
                {
                    ModelState.AddModelError("", "You have registered, please completing activate registration with following email that we have sent to you");
                    return View(model);
                }

                GlobalVariableUser userVariable = new GlobalVariableUser()
                {
                    IdUser = response.UserResult.Nik,
                    NamaUser = response.UserResult.Nama
                };
                Session["GlobalUserVariable"] = userVariable;
                Session["loginSession"] = model;
                Session["UserResult"] = response.UserResult;

                //insert historicaluserlogin
                ResultStatus rs = new ResultStatus();
                rs = CreateHistoricalUserLogin();

                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                ModelState.AddModelError("", "User Id or password is wrong, please check again");
            }

            return View(model);
        }

        public bool IsApiLogin(LoginViewModel model)
        {
            bool rs = false;
            string apiUrlUser = "api/User/GetUserApiFindBy";
            UserApiRequest requestApi = new UserApiRequest();
            UserApiResponse responseApi = new UserApiResponse();
            requestApi.AuthenticationToken = token;
            requestApi.IdUser = model.IdUser;
            requestApi.Sandi = Cryptoghrap.EncryptString(model.Sandi);
            responseApi = JsonConvert.DeserializeObject<UserApiResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrlUser, requestApi));
            if (responseApi.UserApiResult != null)
            {
                GlobalVariableUser userVariable = new GlobalVariableUser()
                {
                    IdUser = model.IdUser,
                    NamaUser = model.IdUser
                };

                Session["GlobalUserVariable"] = userVariable;
                Session["loginSession"] = model;
                Session["UserResult"] = null;
                Session["ApiLogin"] = true;
                rs = true;
            }

            return rs;
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        //[AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                _functionLog.WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                //check if nik already exist in database (tbktp)
                KtpRequest ktpRequest = new KtpRequest();
                KtpResponse ktpResponse = new KtpResponse();
                string apiKtp = "api/Ktp/GetKtpFindBy";
                ktpRequest.AuthenticationToken = token;
                ktpRequest.Nik = model.IdUser;
                ktpResponse = JsonConvert.DeserializeObject<KtpResponse>(JasonMapper.ConvertHttpResponseToJson(apiKtp, ktpRequest));
                if (ktpResponse.KtpResult == null)
                {
                    ModelState.AddModelError("", "Your NIK : " + model.IdUser + " is not exist. Please call head of village for adding your data");
                    return View(model);
                }

                UserRequest request = new UserRequest();
                UserResponse response = new UserResponse();
                request.AuthenticationToken = token;
                request.Nik = model.IdUser;

                //call api
                string apiUrl = "api/User/GetUserFindBy";
                response = JsonConvert.DeserializeObject<UserResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));

                if (response.UserResult != null)
                {
                    //if user is not active
                    if (!response.UserResult.Status)
                    {
                        ModelState.AddModelError("", "You have registered, please check your email " + model.Email + " for compliting process");
                    }
                    else
                    {
                        ModelState.AddModelError("", "You are already register, please login for access your account");
                    }
                }
                else
                {
                    request.Sandi = model.Sandi;
                    request.Email = model.Email;
                    request.DibuatOleh = model.IdUser;
                    //call api
                    string apiRegistration = "api/User/UserRegistrasi";
                    response = JsonConvert.DeserializeObject<UserResponse>(JasonMapper.ConvertHttpResponseToJson(apiRegistration, request));

                    if (response.ResultStatus.IsSuccess)
                    {
                        //clear sandi to get by nik only
                        request.Sandi = null;
                        response = JsonConvert.DeserializeObject<UserResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));

                        if (response.UserResult != null)
                        {
                            EmailResponse emailResponse = new EmailResponse();
                            emailResponse = SendEmailActivate(model, response.UserResult.KodeVerifikasi);
                            if (emailResponse.ResultStatus.IsSuccess)
                            {
                                ViewBag.MsgScs = "Registration is successfully. Please check your email " + model.Email + " for compliting access";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
                ModelState.AddModelError("", ex.Message);
            }
            finally
            {
                _functionLog.WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.end);
            }

            return View(model);
        }

        public EmailResponse SendEmailActivate(RegisterViewModel model, Guid kodeVerifikasi)
        {
            EmailRequest emailRequest = new EmailRequest();
            EmailResponse emailResponse = new EmailResponse();
            emailRequest.AuthenticationToken = token;

            string apiGetEmailTemplateFindBy = "api/Email/GetEmailTemplateFindBy";
            emailRequest.KodeTemplate = "TEMP001";

            EmailResponse emailTemplateResponse = new EmailResponse();
            emailTemplateResponse = JsonConvert.DeserializeObject<EmailResponse>(JasonMapper.ConvertHttpResponseToJson(apiGetEmailTemplateFindBy, emailRequest));


            string apiSendEmail = "api/Email/SendEmail";
            emailRequest.To = new string[] { model.Email };
            emailRequest.Subject = "[DO NOT REPLY - RUKUNTANGGA@ABIDZARFRAME]";
            string link = CurrentUser.GetUrl().Replace("Register", "UserVerifikasi" + "?idUser=" + model.IdUser + "&kodeVerifikasi=" + kodeVerifikasi);


            emailRequest.Body = string.Format(emailTemplateResponse.EmailResult.Template, link);
            emailResponse = JsonConvert.DeserializeObject<EmailResponse>(JasonMapper.ConvertHttpResponseToJson(apiSendEmail, emailRequest));

            return emailResponse;
        }

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult UserVerifikasi(string idUser, string kodeVerifikasi)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            string apiUrl = "api/User/UserVerifikasi";
            UserRequest request = new UserRequest();
            UserResponse response = new UserResponse();

            try
            {
                _functionLog.WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                request.AuthenticationToken = token;
                request.Nik = idUser;
                request.KodeVerifikasi = Guid.Parse(kodeVerifikasi);

                //call api
                response = JsonConvert.DeserializeObject<UserResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
                if (response.ResultStatus.IsSuccess)
                {
                    TempData["MsgScs"] = "Activation is success. Please login to access your account";
                    return RedirectToAction("Login");
                }
                else
                {
                    return RedirectToAction("LogOff");
                }

            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
                ModelState.AddModelError("", ex.Message);
            }
            finally
            {
                _functionLog.WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.end);
            }

            return View();
        }

        public ActionResult LogOff()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }

        public ActionResult ResendActivate()
        {
            ViewBag.MsgScs = TempData["MsgScs"];
            return View();
        }

        [HttpPost]
        //[AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ResendActivate(RegisterViewModel model)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            string apiUrl = "api/User/GetUserFindBy";
            UserRequest request = new UserRequest();
            UserResponse response = new UserResponse();

            try
            {
                _functionLog.WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                request.AuthenticationToken = token;
                request.Nik = model.IdUser;
                //request.Sandi = Cryptoghrap.EncryptString(model.Sandi);

                response = JsonConvert.DeserializeObject<UserResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
                ModelState.AddModelError("", ex.Message);
            }
            finally
            {
                _functionLog.WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.end);
            }

            if (response.UserResult != null)
            {
                //if user is not active resend kode activasi via email
                if (!response.UserResult.Status)
                {
                    EmailResponse emailResponse = new EmailResponse();
                    model.Email = response.UserResult.Email;
                    emailResponse = SendEmailActivate(model, response.UserResult.KodeVerifikasi);
                    if (emailResponse.ResultStatus.IsSuccess)
                    {
                        ViewBag.MsgScs = "Activation code has been send to email " + response.UserResult.Email;
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Your account is still active. If you forgot your password, please contact your head of village");
                }

            }
            else
            {
                ModelState.AddModelError("", "User Id is wrong, please check again");
            }

            return View(model);
        }

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult ChangePassword(string sandi, string newSandi)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            string apiUrl = "api/User/UserUpdateSandi";
            UserRequest request = new UserRequest();
            UserResponse response = new UserResponse();

            //if (!ModelState.IsValid)
            //{
            //    return RedirectToAction("Index", "KtpKu", new { area = "Kependudukan"});
            //}

            try
            {
                _functionLog.WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                //check if current password is not valid
                if (CurrentUser.GetCurrentPassword() != sandi)
                {
                    TempData["MsgErr"] = "Current password is wrong or is not valid, please check again";
                    //string jsonError = "Current password is wrong or is not valid, please check again";
                    //return JsonError(jsonError);
                }
                else
                {
                    request.AuthenticationToken = token;
                    request.Nik = CurrentUser.GetCurrentUserId();
                    request.Sandi = newSandi;

                    response = JsonConvert.DeserializeObject<UserResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
                    if (response.ResultStatus.IsSuccess)
                    {
                        Session.Clear();
                        Session.Abandon();
                        TempData["MsgScs"] = "Password has been changed successfully, please login with new password";
                        //return JsonError(response.ResultStatus.MessageText);

                    }
                }
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
                ModelState.AddModelError("", ex.Message);
            }
            finally
            {
                _functionLog.WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.end);
            }

            //return Json(new { success = true, Msg = "Password has been changed successfully, please login with new password" }, JsonRequestBehavior.AllowGet);

            return RedirectToAction("Login");
        }

        private ResultStatus CreateHistoricalUserLogin()
        {
            string method = MethodBase.GetCurrentMethod().Name;
            string apiUrl = "api/HistoricalUserLogin/InsertHistoricalUserLogin";
            HistoricalUserLoginRequest requestHUL = new HistoricalUserLoginRequest();
            HistoricalUserLoginResponse responseHUL = new HistoricalUserLoginResponse();
            ResultStatus rs = new ResultStatus();

            try
            {
                _functionLog.WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);


                requestHUL.AuthenticationToken = token;
                requestHUL.Nik = CurrentUser.GetCurrentUserId();
                requestHUL.Login = DateTime.Now;

                //call api
                requestHUL.DibuatOleh = CurrentUser.GetCurrentUserId();
                responseHUL = JsonConvert.DeserializeObject<HistoricalUserLoginResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, requestHUL));
            }
            catch (Exception ex)
            {
                //_errHand.FillError(ex.Message, ref bussinessError);
                responseHUL.ResultStatus.SetErrorStatus(ex.Message);
            }
            finally
            {
                _functionLog.WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.end);
            }

            return responseHUL.ResultStatus;
        }

        public ActionResult LandingPage()
        {
            return View();
        }
    
        public ActionResult LandingPageLogin(LoginViewModelAreaRw model)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            string apiUrl = "api/Rw/GetRwByKodeRt";
            UserRequest request = new UserRequest();
            RwResponse response = new RwResponse();


            TestimoniRequest requestTestimoni = new TestimoniRequest();
            TestimoniResponse responseTestimoni = new TestimoniResponse();

            if (!ModelState.IsValid)
            {
                return View("LandingPage", model);
            }

            try
            {
                _functionLog.WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.begin);

                request.AuthenticationToken = token;
                request.KodeRt = model.KodeRt;

                response = JsonConvert.DeserializeObject<RwResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));

                if (response.RwResult != null)
                {
                    string apiUrlTestimoni = "api/Testimoni/GetTestimoniByIdRw";
                    requestTestimoni.AuthenticationToken = token;
                    requestTestimoni.IdRw = response.RwResult.Id;
                    responseTestimoni = JsonConvert.DeserializeObject<TestimoniResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrlTestimoni, requestTestimoni));
                    Session["Testimoni"] = responseTestimoni.TestimoniResultList;
                }

            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
                ModelState.AddModelError("", ex.Message);
            }
            finally
            {
                _functionLog.WriteFunctionLog(controller, method, 1, LogData.LOG_TYPE.end);
            }

            if (response.RwResult != null)
            {
                Session["AreaRw"] = response.RwResult;

                return RedirectToAction("Index", "AreaRw");
            }
            else
            {
                ModelState.AddModelError("", "Kode Rt is invalid");
            }

            return RedirectToAction("Index", "AreaRw");
        }

        public ActionResult Rw()
        {
            return View();
        }
        public ActionResult LogOffRw()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("LandingPage", "Account");
        }

    }


}