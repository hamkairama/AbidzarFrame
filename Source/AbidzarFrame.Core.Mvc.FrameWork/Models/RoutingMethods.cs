using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbidzarFrame.Core.Mvc.Models
{
    public class RoutingMethods
    {
        public const String METHOD_POST = "POST";
        public const String METHOD_GET = "GET";

        public static String[] PostOnly()
        {
            return new String[] { RoutingMethods.METHOD_POST };
        }

        public static String[] GetOnly()
        {
            return new String[] { RoutingMethods.METHOD_GET };
        }

        public static String[] Any()
        {
            return new String[] { RoutingMethods.METHOD_GET, RoutingMethods.METHOD_POST };
        }

    }
}
