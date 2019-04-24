using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbidzarFrame.Core.Mvc.Models
{
    public class PatternDecimalFormatter : IDecimalFormatter
    {

        String decimalFormatString = null;

        public PatternDecimalFormatter(String decimalFormat)
        {
            this.decimalFormatString = decimalFormat;
        }

        public string format(decimal d)
        {
            if (this.decimalFormatString == null)
                return d.ToString();
            else
                return d.ToString(decimalFormatString);
        }

    }
}
