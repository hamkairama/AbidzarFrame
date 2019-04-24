using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace AbidzarFrame.Core.Mvc.Models.Menu
{
    public interface IMenuCreator: IDisposable
    {

        void WriteMenu(HttpContextBase httpContext, string[] userRoles, string siteMap);

    }
}
