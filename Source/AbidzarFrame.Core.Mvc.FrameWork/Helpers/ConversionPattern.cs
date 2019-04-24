using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbidzarFrame.Core.Mvc.Helpers
{
    public class ConversionPattern
    {

        protected String field = null;
        protected String source = null;
        protected String replacement = null;

        public ConversionPattern() : this(null, null, null) { }

        public ConversionPattern(String fieldName, String source, String replacement)
        {
            this.field = fieldName;
            this.source = source;
            this.replacement = replacement;
        }

        public Boolean IsFieldMatched(String s)
        {
            return field.Equals(s);
        }

        public Boolean IsMatched(String s)
        {
            return s.Contains(source);
        }

        public String ConvertedMessage(String s)
        {
            return s.Replace(source, replacement);
        }

    }
}
