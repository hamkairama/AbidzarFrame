﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AbidzarFrame.Mvc.Infrastructures.ActionResult
{
    public class StandardJsonResult : JsonResult
    {
        // deklarasi list or error
        public IList<string> ErrorMessages { get; private set; }

        // Constructor class 
        public StandardJsonResult()
        {
            ErrorMessages = new List<string>();
        }

        // Method insert error ke list error
        public void AddError(string errorMessage)
        {
            ErrorMessages.Add(errorMessage);
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (this.JsonRequestBehavior == JsonRequestBehavior.DenyGet &&
                string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("GET access is not allowed.  Change the JsonRequestBehavior if you need GET access.");
            }

            var response = context.HttpContext.Response;
            response.ContentType = string.IsNullOrEmpty(ContentType) ? "application/json" : ContentType;

            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }

            SerializeData(response);
        }

        // Fungsi memproses response menjadi format json
        protected virtual void SerializeData(HttpResponseBase response)
        {
            if (ErrorMessages.Any())
            {
                var originalData = Data;
                Data = new
                {
                    Success = false,
                    OriginalData = originalData,
                    ErrorMessage = string.Join("\n", ErrorMessages),
                    ErrorMessages = ErrorMessages.ToArray(),
                };
                response.TrySkipIisCustomErrors = true;
                response.StatusCode = 400;
            }

            var settings = new JsonSerializerSettings
            {
                // gak bisa pake camelCase karena di kendo ui menggunakan PascalCase
                //ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new JsonConverter[]
                {
                    new StringEnumConverter(),
                },
            };
            response.Write((string)JsonConvert.SerializeObject(Data, settings));
        }
    }

    public class StandardJsonResult<T> : StandardJsonResult
    {
        public new T Data
        {
            get { return (T)base.Data; }
            set { base.Data = value; }
        }
    }
}
