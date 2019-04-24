using AbidzarFrame.Core.Mvc.Helpers;
using AbidzarFrame.Utils;
using AbidzarFrame.Web.Wrappers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AbidzarFrame.Web.Helpers
{
    public class JasonMapper 
    {
        public static string ConvertHttpResponseToJson(string apiUrl, object request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            StringContent requestContent = new StringContent("");
            string response = null;
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiConfiguration.GetInstance().ApiBaseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string qryString = ObjectToDictionaryHelper.GenericObjectToString(request);
                requestContent = new StringContent(qryString, UnicodeEncoding.Default, "application/json");

                var myContent = JsonConvert.SerializeObject(request);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


                HttpResponseMessage httpResponseMessage = client.PostAsync(apiUrl, byteContent).Result;
                using (HttpContent content = httpResponseMessage.Content)
                {
                    Task<string> result = content.ReadAsStringAsync();
                    response = result.Result;
                }
            }

            return response;
        }
    }
}

