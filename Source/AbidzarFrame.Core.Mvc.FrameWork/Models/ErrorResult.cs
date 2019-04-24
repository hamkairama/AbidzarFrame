using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace AbidzarFrame.Core.Mvc.Models
{
    public class ErrorResult: ActionResult
    {

        public const String SEARCH_RESULT = "__SEARCH_RESULT";

        private Errors err = null;
        private int statusCode = 200;

        public ErrorResult(int statusCode, Errors err)
        {
            this.err = err;
            this.statusCode = statusCode;
        }


        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.StatusCode = this.statusCode;
            context.HttpContext.Session[ErrorResult.SEARCH_RESULT] = err;

        }
    }
}
