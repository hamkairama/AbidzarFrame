using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;
using AbidzarFrame.Core.Mvc.Controllers;

namespace AbidzarFrame.Core.Mvc.Models
{
    public interface IRequestRoutingRule
    {
        String[] ApplicableMethods { get; }

        void Init(EnhancedController controller, ResultExecutedContext context, ActionRequestToken token);

        bool Trigger();

        void Execute();
    }
}
