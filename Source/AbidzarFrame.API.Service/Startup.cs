using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using AbidzarFrame.Core.Model.Business;

[assembly: OwinStartup(typeof(AbidzarFrame.API.Service.Startup))]

namespace AbidzarFrame.API.Service
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);          
        }
    }
}
