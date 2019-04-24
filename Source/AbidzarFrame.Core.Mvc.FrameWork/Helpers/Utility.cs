using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Collections;
using System.Web.Security;
using System.Web;
using System.Reflection;
using AbidzarFrame.Core.Mvc.Models;
using System.Web.Mvc;

namespace AbidzarFrame.Core.Mvc.Helpers
{
    public class Utility
    {
        public static string currentUser()
        {
            string userId = (string)HttpContext.Current.User.Identity.Name;
            return userId.Split('\\')[1];
        }

        public static string uuDecode(string sBuffer)
        {
            string str1 = String.Empty;

            int j = sBuffer.Length;
            for (int i = 1; i <= j; i += 4)
            {
                str1 = String.Concat(str1, Convert.ToString((char)(((int)Convert.ToChar(sBuffer.Substring(i - 1, 1)) - 32) * 4 + ((int)Convert.ToChar(sBuffer.Substring(i, 1)) - 32) / 16)));

                str1 = String.Concat(str1, Convert.ToString((char)(((int)Convert.ToChar(sBuffer.Substring(i, 1)) % 16 * 16) + ((int)Convert.ToChar(sBuffer.Substring(i + 1, 1)) - 32) / 4)));
                str1 = String.Concat(str1, Convert.ToString((char)(((int)Convert.ToChar(sBuffer.Substring(i + 1, 1)) % 4 * 64) + (int)Convert.ToChar(sBuffer.Substring(i + 2, 1)) - 32)));
            }
            return str1;
        }

        public static string uuEncode(string sBuffer)
        {
            string str1 = String.Empty;

            if (sBuffer.Length % 3 != 0)
            {
                string stuff = new String(' ', 3 - sBuffer.Length % 3);
                sBuffer = String.Concat(sBuffer, stuff);
            }
            int j = sBuffer.Length;
            for (int i = 1; i <= j; i += 3)
            {
                str1 = String.Concat(str1, Convert.ToString((char)((int)Convert.ToChar(sBuffer.Substring(i - 1, 1)) / 4 + 32)));
                str1 = String.Concat(str1, Convert.ToString((char)((int)Convert.ToChar(sBuffer.Substring(i - 1, 1)) % 4 * 16 + (int)Convert.ToChar(sBuffer.Substring(i, 1)) / 16 + 32)));
                str1 = String.Concat(str1, Convert.ToString((char)((int)Convert.ToChar(sBuffer.Substring(i, 1)) % 16 * 4 + (int)Convert.ToChar(sBuffer.Substring(i + 1, 1)) / 64 + 32)));
                str1 = String.Concat(str1, Convert.ToString((char)((int)Convert.ToChar(sBuffer.Substring(i + 1, 1)) % 64 + 32)));
            }
            return str1;
        }

        public static object CloneObject(object obj)
        {
            using (MemoryStream memStream = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter(null,
                     new StreamingContext(StreamingContextStates.Clone));
                binaryFormatter.Serialize(memStream, obj);
                memStream.Seek(0, SeekOrigin.Begin);
                return binaryFormatter.Deserialize(memStream);
            }
        }

        /*
        Public Shared Function LoadClass(Of T)(ByVal package As String, ByVal className As String) As T

            'Dim typeName As String = className

            Dim ab As Assembly = Assembly.Load(package)
            Dim type = ab.GetType(package & "." & className)
            Dim instance As T = DirectCast(Activator.CreateInstance(type), T)

            Return instance
        End Function
         */

        public static T LoadClass<T>(String package, String className)
        {
            T instance = default(T);

            try
            {
                Assembly ab = Assembly.Load(package);
                Type type = ab.GetType(package + "." + className);
                instance = (T)Activator.CreateInstance(type);
            }
            catch (Exception e)
            {
                instance = default(T);
            }
            return instance;
        }

        public static T LoadClass<T>(String package, String className, Object[] parameters)
        {
            T instance = default(T);

            try
            {
                List<Type> typeList = new List<Type>();
                foreach (object o in parameters)
                {
                    typeList.Add(o.GetType());
                }

                Assembly ab = Assembly.Load(package);
                Type type = ab.GetType(package + "." + className);
                if (type != null)
                {
                    ConstructorInfo ci = type.GetConstructor(typeList.ToArray());
                    instance = (T)ci.Invoke(parameters);
                }
            }
            catch (Exception e)
            {
                instance = default(T);
            }
            return instance;
        }


        public static string ToFullUrl(string url)
        {
            if (String.IsNullOrEmpty(url))
            {
                return "";
            }
            else
            {
                String _fullUrl = "";
                try
                {
                    _fullUrl = VirtualPathUtility.ToAbsolute(url);
                }
                catch (Exception e)
                {
                    _fullUrl = url;
                }
                return _fullUrl;
            }
        }

        public static ActionRequestToken UrlToAction(String url)
        {
            ActionRequestToken action = null;
            try
            {
                if (!VirtualPathUtility.IsAppRelative(url))
                {
                    url = VirtualPathUtility.ToAppRelative(url);
                    if (url.StartsWith("~/")) url = url.Substring(2);
                }
                String[] words = url.Split('/');

                int controllerPos = 0;
                int actionPos = 1;

                //action = new ActionRequestToken(null, words[shift + controllerPos], words[shift + actionPos]);
                action = new ActionRequestToken(words[controllerPos].Trim(), words[actionPos].Trim());
            }
            catch (Exception e)
            {
                action = null;
            }
            return action;
        }

        public static void ClearObject(ref Object data)
        {
            if (data != null)
            {
                if (data is IDisposable)
                {
                    ((IDisposable)data).Dispose();
                }

                try
                {
                    MethodInfo method = data.GetType().GetMethod("Clear");
                    if (method != null)
                    {
                        method.Invoke(data, null);
                    }
                }
                catch (Exception e)
                {
                    String a = e.Message;
                }

                data = null;
            }
        }

    }
}
