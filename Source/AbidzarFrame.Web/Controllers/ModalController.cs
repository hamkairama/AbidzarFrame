using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AbidzarFrame.Web.Controllers
{
    public class ModalController : Controller
    {
        // GET: Modal
        public ActionResult KtpList()
        {
            return PartialView("_KtpList");
        }
    }
}