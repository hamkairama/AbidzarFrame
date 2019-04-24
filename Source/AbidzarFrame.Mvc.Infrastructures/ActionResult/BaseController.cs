using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AbidzarFrame.Mvc.Infrastructures.ActionResult
{
    public abstract class BaseController : Controller
    {
        protected string InsScs = "Insert Success.";
        protected string InsErr = "Insert Error.";
        protected string UpdScs = "Update Success.";
        protected string UpdErr = "Update Error.";
        protected string DelScs = "Delete Success.";
        protected string DelErr = "Delete Error.";
        //protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        //{
        //    // Setting default culture ke en-GB karena secara format paling aman ketimbang en-US
        //    string cultureName = "en-GB";
        //    //var userCulture = System.Web.HttpContext.Current.Session["UserCulture"];
        //    //if (userCulture != null)
        //    //{
        //    //    userCulture = CultureHelper.GetImplementedCulture((string)userCulture);
        //    //    HttpCookie cultureCookie = Request.Cookies["_culture_" + userCulture];
        //    //    if (cultureCookie != null)
        //    //    {
        //    //        cultureName = cultureCookie.Value;
        //    //    }
        //    //}

        //    // Validate culture name
        //    cultureName = System.Globalization.CultureInfo.CurrentCulture.ToString();
        //    //cultureName = CultureHelper.GetImplementedCulture(cultureName); // This is safe

        //    var newCulture = new System.Globalization.CultureInfo(cultureName);
        //    // format tanggal yang digunakan saat ini (standarisasi tanggal)             
        //    //newCulture.DateTimeFormat.ShortDatePattern = "dd-MMM-yyyy";

        //    // Modify current thread's cultures           
        //    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
        //    Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

        //    return base.BeginExecuteCore(callback, state);
        //}

        //protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        //{
        //    return base.BeginExecuteCore(callback, state);
        //}

        // Fungsi untuk menghasilkan message validation JSON
        protected StandardJsonResult JsonValidationError()
        {
            var result = new StandardJsonResult();

            foreach (var validationError in ModelState.Values.SelectMany(v => v.Errors))
            {
                result.AddError(validationError.ErrorMessage);
            }
            return result;
        }
        // Fungsi untuk menghasilkan message error JSON
        protected StandardJsonResult JsonError(string errorMessage)
        {
            var result = new StandardJsonResult();

            result.AddError(errorMessage);

            return result;
        }
        // Method constructor dari JsonError untuk menghasilkan message validation JSON dengan parameter tambahan JsonRequestBehavior
        protected StandardJsonResult JsonError(string errorMessage, JsonRequestBehavior behavior)
        {
            var result = new StandardJsonResult()
            {
                JsonRequestBehavior = behavior
            };

            result.AddError(errorMessage);

            return result;
        }

        // Fungsi untuk menghasilkan message sukses JSON
        protected StandardJsonResult<T> JsonSuccess<T>(T data)
        {
            return new StandardJsonResult<T> { Data = data };
        }

        // Method constructor dari JsonSuccess untuk menghasilkan message sucess JSON dengan parameter tambahan JsonRequestBehavior
        protected StandardJsonResult<T> JsonSuccess<T>(T data, JsonRequestBehavior behavior)
        {
            return new StandardJsonResult<T>
            {
                Data = data,
                JsonRequestBehavior = behavior
            };
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            // if the request is AJAX return JSON else view.
            if (filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                //Because its a exception raised after ajax invocation
                //Lets return Json
                if (filterContext.Exception != null)
                    filterContext.Result = new JsonResult()
                    {
                        Data = filterContext.Exception.Message,
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };

                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.Clear();
            }
            else
            {
                //Normal Exception
                //So let it handle by its default ways.
                base.OnException(filterContext);
            }

        }
    }
}
