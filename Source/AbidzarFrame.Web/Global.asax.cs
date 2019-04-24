using StructureMap;
using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AbidzarFrame.Web
{
    public class MvcApplication : HttpApplication
    {
        public IContainer Container
        {
            get { return (IContainer)HttpContext.Current.Items["_Container"]; }
            set { HttpContext.Current.Items["_Container"] = value; }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //CustomAutoMapperConfiguration.PopulateMapperConfig();
            // Register IoC DI

            //IoC.Container.Configure(cfg =>
            //{
            //    cfg.AddRegistry(new StandardRegistry());
            //    cfg.AddRegistry(new ControllerRegistry());
            //    cfg.AddRegistry(new ActionFilterRegistry(() => Container ?? IoC.Container));
            //    cfg.AddRegistry(new MvcRegistry());
            //    cfg.AddRegistry(new TaskRegistry());
            //    cfg.AddRegistry(new ModelMetadataRegistry());
            //});

            //using (var container = IoC.Container.GetNestedContainer())
            //{
            //    foreach (var task in container.GetAllInstances<IRunAtInit>())
            //    {
            //        task.Execute();
            //    }

            //    foreach (var task in container.GetAllInstances<IRunAtStartUp>())
            //    {
            //        task.Execute();
            //    }
            //}
        }

        //protected void Application_BeginRequest()
        //{
        //    Container = IoC.Container.GetNestedContainer();
        //    //CultureInfo newCulture = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
        //    //newCulture.DateTimeFormat.ShortDatePattern = "dd-MMM-yyyy";
        //    //newCulture.DateTimeFormat.DateSeparator = "-";
        //    //Thread.CurrentThread.CurrentCulture = newCulture;
        //    foreach (var task in Container.GetAllInstances<IRunOnEachRequest>())
        //    {
        //        task.Execute();
        //    }
        //}

        //protected void Application_EndRequest()
        //{
        //    try
        //    {
        //        if (Container != null)
        //        {
        //            foreach (var task in Container.GetAllInstances<IRunAfterEachRequest>())
        //            {
        //                task.Execute();
        //            }
        //        }
        //    }
        //    finally
        //    {
        //        Container?.Dispose();
        //        Container = null;
        //    }
        //}

        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    // handle error for devexpress
        //    Exception exception = HttpContext.Current.Server.GetLastError();
        //    //Handle Exception
        //    if (Container != null)
        //    {
        //        foreach (var task in Container.GetAllInstances<IRunOnError>())
        //        {
        //            task.Execute();
        //        }
        //    }
        //}
    }
}
