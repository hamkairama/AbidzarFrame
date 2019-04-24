using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AbidzarFrame.Core.Mvc.Models
{
    [DataContract]
    public class MessageContent
    {

        [DataMember]
        protected String languageCode = null;

        [DataMember]
        protected String message = null;

        public MessageContent(String languageCode, String message)
        {
            this.languageCode = languageCode;
            this.message = message;
        }

        public String LanguageCode
        {
            get
            {
                return this.languageCode;
            }
            set
            {
                this.languageCode = value;
            }
        }

        public String Message
        {
            get
            {
                return this.message;
            }
            set
            {
                this.message = value;
            }
        }

    }
}
