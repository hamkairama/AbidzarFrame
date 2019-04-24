using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using AbidzarFrame.Core.Mvc.Controllers;
using System.Web.SessionState;
using System.Collections.Concurrent;
using AbidzarFrame.Core.Mvc.Helpers;

namespace AbidzarFrame.Core.Mvc.Models
{
    public class AppServiceLocator : IDisposable
    {

        public const String SESSION_APPLICATION_SERVICE = "SESSION_APPLICATION_SERVICE";

        //private ConcurrentDictionary<String, Object> appServices = null;
        private Dictionary<String, Object> appServices = null;
        private Dictionary<String, Type> appServiceInfos = null;

        public static String LockKey = "LockKey";

        public AppServiceLocator()
        {
            //appServices = new ConcurrentDictionary<string, object>();
            appServices = new Dictionary<string, object>();
            appServiceInfos = new Dictionary<string, Type>();
        }

        public void AddService(String serviceName, Object serviceObject)
        {
            //appServices.AddOrUpdate(serviceName, serviceObject, (key, oldvalue) => serviceObject);
            appServices.Add(serviceName, serviceObject);
            appServiceInfos.Add(serviceName, serviceObject.GetType());
        }

        public Object GetService(String serviceName)
        {
            Object service = null;
            if (!appServices.TryGetValue(serviceName, out service))
            {
                Type serviceType = null;
                if (appServiceInfos.TryGetValue(serviceName, out serviceType))
                {
                    service = Utility.LoadClass<Object>(serviceType.Namespace, serviceType.Name);
                    if (service == null)
                    {
                        service = Utility.LoadClass<Object>(serviceType.Namespace, serviceType.Name, new object[] { HttpContext.Current.Session });
                    }
                }
            }
            return service;
        }

        public static void AddService(HttpSessionState session, String serviceName, Object service)
        {
            AppServiceLocator locator = (AppServiceLocator)session[AppServiceLocator.SESSION_APPLICATION_SERVICE];
            if (locator == null)
            {
                locator = new AppServiceLocator();
            }
            locator.AddService(serviceName, service);
            session[AppServiceLocator.SESSION_APPLICATION_SERVICE] = locator;
        }

        public static Object GetService(HttpSessionState session, String serviceName)
        {
            AppServiceLocator locator = (AppServiceLocator)session[AppServiceLocator.SESSION_APPLICATION_SERVICE];
            if (locator == null)
            {
                return null;
            }
            else
            {
                return locator.GetService(serviceName);
            }
        }

        public static void AddSharedService(HttpApplicationState application, String serviceName, Object service)
        {
            AppServiceLocator locator = (AppServiceLocator)application[AppServiceLocator.SESSION_APPLICATION_SERVICE];
            if (locator == null)
            {
                locator = new AppServiceLocator();
            }

            lock (locator)
            {
                locator.AddService(serviceName, service);
            }
            application[AppServiceLocator.SESSION_APPLICATION_SERVICE] = locator;
        }

        public static Object GetSharedService(HttpApplicationState applicationn, String serviceName)
        {
            AppServiceLocator locator = (AppServiceLocator)applicationn[AppServiceLocator.SESSION_APPLICATION_SERVICE];
            if (locator == null)
            {
                return null;
            }
            else
            {
                return locator.GetService(serviceName);
            }
        }

        public static bool CheckService(HttpSessionState session, String serviceName)
        {
            AppServiceLocator locator = (AppServiceLocator)session[AppServiceLocator.SESSION_APPLICATION_SERVICE];
            if (locator == null)
            {
                locator = new AppServiceLocator();
            }
            Object service = locator.GetService(serviceName);
            return (service != null);
        }

        public static bool CheckService(HttpApplicationState application, String serviceName)
        {
            AppServiceLocator locator = (AppServiceLocator)application[AppServiceLocator.SESSION_APPLICATION_SERVICE];
            if (locator == null)
            {
                locator = new AppServiceLocator();
            }
            Object service = locator.GetService(serviceName);
            return (service != null);
        }


#region IDisposable codes

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    ClearResources();
                }
            }
        }

        ~AppServiceLocator()
        {
            Dispose(false);
            ClearResources();
        }

        private void ClearResources()
        {
            foreach (Object o in appServices.Values)
            {
                if (o is IDisposable)
                {
                    try
                    {
                        ((IDisposable)o).Dispose();
                    }
                    catch (Exception e) { }
                }
            }
            bool _clear = false;
            if (!Boolean.TryParse(ApplicationSetting.GetInstance().ClearAllEntryInAppServiceLocator, out _clear))
            {
                _clear = false;
            }
            if (_clear)
            {
                appServices.Clear();
            }
        }

#endregion

    }
}
