using System;
using System.ServiceModel.Configuration;

namespace AbidzarFrame.Core.Mvc.Models.CookieManager
{
    public class CookieManagerBehaviorExtension : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(CookieManagerEndpointBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new CookieManagerEndpointBehavior();
        }
    }
}
