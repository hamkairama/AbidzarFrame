using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AbidzarFrame.Core.Mvc.Models;
using System.Web.Security;

namespace AbidzarFrame.Core.Mvc.Helpers
{
    public class LogInformationReader
    {

        public static LogData Read(LogData.STAGE stage, ControllerContext context)
        {
            LogData l = new LogData();

            l.ControllerName = (String)context.RouteData.Values["controller"];
            l.ActionName = (String)context.RouteData.Values["action"];
            l.LogStage = stage;
            l.SessionId = context.HttpContext.Session.SessionID;
            l.Time = System.DateTime.Now;
            l.Url = context.HttpContext.Request.Url.ToString();
            l.UserId = context.HttpContext.User.Identity.Name;
            l.UserData = "{";
            try
            {
                for (int i=0; i<context.HttpContext.Request.Params.Count; i++) 
                {
                    try
                    {
                        String r = context.HttpContext.Request.Params.Keys[i];
                        if (!LogInformationReader.RequestDataIgnoreList().Contains(r))
                        {
                            String reqData = context.HttpContext.Request.Params[r];
                            if (r.ToLower().Contains("password"))
                            {
                                reqData = "*****";
                            }
                            l.UserData = l.UserData + r + "=" + reqData + ",";
                        }
                    }
                    catch (Exception e)
                    {
                        System.Console.Out.Write(e.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.Out.Write(ex.ToString());
            }
            l.UserData = l.UserData + "}";
            return l;
        }

        public static LogData Read(LogData.STAGE stage, ExceptionContext context)
        {
            LogData log = Read(stage, (ControllerContext)context);
            if (context.HttpContext.Error == null)
            {
                log.Error = context.Exception.Message;
            }
            else
            {
                log.Error = context.HttpContext.Error.Message + "(" + context.HttpContext.Error.Source + ")";
            }
            return log;
        }

        private static List <String> RequestDataIgnoreList(){
            List <String> l = new List<String>();
            l.Add("__VIEWSTATE");
            l.Add("AUTH_PASSWORD");
            l.Add("ASP.NET_SessionId");
            l.Add(".ASPXAUTH");           
            l.Add("ALL_HTTP");           
            l.Add("ALL_RAW");
            l.Add("APPL_MD_PATH");         
            l.Add("APPL_PHYSICAL_PATH");   
            l.Add("AUTH_TYPE");
            l.Add("AUTH_USER");            
            l.Add("AUTH_PASSWORD ");       
            l.Add("LOGON_USER");           
            l.Add("REMOTE_USER");          
            l.Add("CERT_COOKIE");         
            l.Add("CERT_FLAGS");           
            l.Add("CERT_ISSUER");          
            l.Add("CERT_KEYSIZE");         
            l.Add("CERT_SECRETKEYSIZE");   
            l.Add("CERT_SERIALNUMBER");    
            l.Add("CERT_SERVER_ISSUER");  
            l.Add("CERT_SERVER_SUBJECT"); 
            l.Add("CERT_SUBJECT");         
            l.Add("CONTENT_LENGTH");       
            l.Add("CONTENT_TYPE");        
            l.Add("GATEWAY_INTERFACE");    
            l.Add("HTTPS");                
            l.Add("HTTPS_KEYSIZE");        
            l.Add("HTTPS_SECRETKEYSIZE");  
            l.Add("HTTPS_SERVER_ISSUER");  
            l.Add("HTTPS_SERVER_SUBJECT"); 
            l.Add("INSTANCE_ID");          
            l.Add("INSTANCE_META_PATH");   
            l.Add("LOCAL_ADDR");           
            l.Add("PATH_INFO");           
            l.Add("PATH_TRANSLATED");     
            l.Add("QUERY_STRING");         
            l.Add("REMOTE_ADDR");          
            l.Add("REMOTE_HOST");          
            l.Add("REMOTE_PORT");          
            l.Add("REQUEST_METHOD");       
            l.Add("SCRIPT_NAME");          
            l.Add("SERVER_NAME");          
            l.Add("SERVER_PORT");          
            l.Add("SERVER_PORT_SECURE");   
            l.Add("SERVER_PROTOCOL");      
            l.Add("SERVER_SOFTWARE");      
            l.Add("URL");                  
            l.Add("HTTP_CACHE_CONTROL");   
            l.Add("HTTP_CONNECTION");      
            l.Add("HTTP_CONTENT_LENGTH");  
            l.Add("HTTP_CONTENT_TYPE");    
            l.Add("HTTP_ACCEPT");          
            l.Add("HTTP_ACCEPT_ENCODING"); 
            l.Add("HTTP_ACCEPT_LANGUAGE"); 
            l.Add("HTTP_COOKIE");          
            l.Add("HTTP_HOST");            
            l.Add("HTTP_REFERER");         
            l.Add("HTTP_USER_AGENT");
            l.Add("HTTP_X_REQUESTED_WITH");
            l.Add("BIGipServerIDAgencyLink_Pool_https");
            l.Add("HTTP_X_FORWARDED_FOR");
            l.Add("HTTP_ACCEPT_CHARSET");
            return l;
        }
    }
}