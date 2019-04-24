using AbidzarFrame.API.Service.Models;
using AbidzarFrame.Domain.Models;
using AbidzarFrame.Security.Interface;
using AbidzarFrame.Security.Interface.Dto;
using AbidzarFrame.Security.Manager;
using AbidzarFrame.Utils;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace AbidzarFrame.API.Service.Controllers
{
    public class AccountController : Controller
    {
        #region Private Instance
        private UserApiRequest request = new UserApiRequest();
        private UserApiResponse response = new UserApiResponse();
        #endregion

        #region Contructor 
        ISecurityManager manager;
        public AccountController()
        {
            manager = new SecurityManager();
        }
        #endregion

        [System.Web.Mvc.AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            request.IdUser = model.IdUser;
            request.Sandi = Cryptoghrap.EncryptString(model.Sandi);
            response = manager.GetUserApiFindBy(request);

            if (response.UserApiResult != null)
            {
                Session["loginSession"] = model;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            //Session["loginSession"] = null;
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}
