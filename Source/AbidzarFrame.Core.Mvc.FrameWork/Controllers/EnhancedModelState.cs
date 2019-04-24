using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace AbidzarFrame.Core.Mvc.Controllers
{
    public class EnhancedModelState : ModelState
    {

        public EnhancedModelState(ModelState state)
        {
            this.Value = state.Value;
            foreach (ModelError e in state.Errors)
            {
                this.Errors.Add(e);
            }
        }

    }
}
