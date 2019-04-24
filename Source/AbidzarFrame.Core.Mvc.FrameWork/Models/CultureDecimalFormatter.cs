using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace AbidzarFrame.Core.Mvc.Models
{
    public class CultureDecimalFormatter : IDecimalFormatter
    {

        String cultureName = null;
        int decimalPoint = 0;
        String currencyString = null;

        public CultureDecimalFormatter(String cultureName, int decimalPoint, String currencyString)
        {
            this.cultureName = cultureName;
            this.decimalPoint = decimalPoint;
            this.currencyString = currencyString;
        }

        public string format(decimal d)
        {
            NumberFormatInfo a = new CultureInfo(this.cultureName, false).NumberFormat;
            if (this.currencyString != null)
                a.CurrencySymbol = this.currencyString;

            return d.ToString("C" + decimalPoint.ToString(), a);
        }

    }
}
