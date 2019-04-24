using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbidzarFrame.Web.Helpers
{
    public class Labels
    {
        public static string CardIcon(int mode)
        {
            string label = "<i class='icon-trophy font-green-haze theme-font'></i>";
            switch (mode)
            {
                case 1:
                    label = "<i class='icon-user-follow font-red-sunglo theme-font'></i>";
                    break;
                case 2:
                    label = "<i class='icon-trophy font-green-haze theme-font'></i>";
                    break;
                case 3:
                    label = " <i class='icon-basket font-purple-wisteria theme-font'></i>";
                    break;
                case 4:
                    label = "<i class='icon-layers font-blue theme-font'></i>";
                    break;
                case 5:
                    label = "<i class='icon-camera font-purple-sharp theme-font'></i>";
                    break;
                case 6:
                    label = "<i class='icon-book-open font-yellow-casablanca theme-font'></i>";
                    break;
                case 7:
                    label = "<i class='icon-badge font-blue-ebonyclay theme-font'></i>";
                    break;
                case 8:
                    label = "<i class='icon-chemistry font-green-seagreen theme-font'></i>";
                    break;
                default:
                    label = "<i class='icon-trophy font-green-haze theme-font'></i>";
                    break;
            }
            return label;
        }
    }
}