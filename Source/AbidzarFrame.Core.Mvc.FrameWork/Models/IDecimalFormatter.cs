using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbidzarFrame.Core.Mvc.Models
{
    public interface IDecimalFormatter
    {

        String format(Decimal d);

    }
}
