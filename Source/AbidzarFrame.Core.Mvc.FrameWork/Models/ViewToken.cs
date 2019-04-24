using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbidzarFrame.Core.Mvc.Models
{
    public class ViewToken
    {

        private String viewName = null;
        private String viewPath = null;

        public ViewToken(String viewName, String viewPath)
        {
            this.viewName = viewName;
            this.viewPath = viewPath;
        }

        public ViewToken() : this(null, null) { }

        public String ViewName
        {
            get
            {
                return this.viewName;
            }
            set
            {
                this.viewName = value;
            }
        }

        public String ViewPath
        {
            get
            {
                return this.viewPath;
            }
            set
            {
                this.viewPath = value;
            }
        }

    }
}
