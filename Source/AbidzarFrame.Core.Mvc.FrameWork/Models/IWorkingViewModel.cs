using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace AbidzarFrame.Core.Mvc.Models
{
    public interface IWorkingViewModel
    {

        void Read(HttpRequestBase r);
        Errors CheckIntegrity(HttpRequestBase r);
        Boolean HasInputted();

    }
}
