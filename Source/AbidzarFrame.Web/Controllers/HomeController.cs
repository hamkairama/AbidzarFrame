using AbidzarFrame.Utils;
using AbidzarFrame.Web.App_Start;
using AbidzarFrame.Web.WebApiLocal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AbidzarFrame.Web.Controllers
{
    public class HomeController : WebLogManager
    {
        private readonly ErrorHandler _errHand;
        public HomeController()
        {
            _errHand = new ErrorHandler();
        }

        public ActionResult Index(string errCode)
        {
            if (!string.IsNullOrWhiteSpace(errCode))
            {
                ViewBag.ErrorMessage = _errHand.GetErrorMessage(ErrorHandler._ERRKEY_ABIDZARFRAME, errCode);
            }

            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Help()
        {
            return View();
        }
    }
}