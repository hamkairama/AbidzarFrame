using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Xml;
using System.Web.Mvc;

namespace AbidzarFrame.Core.Mvc.Models
{

    [DataContract]
    [KnownType(typeof(MessageContent))]
    public class ErrorVo
    {

        public readonly static String DEFAULT_LANGUAGE = AbidzarFrame.Core.Mvc.Views.EnhancedViewEngine.LANGUAGE_EN;

        private String errorCode = null;
        private String errorFieldName = null;
        private Dictionary<String, String> messages = new Dictionary<String, String>();

        public ErrorVo() : this(null, null) { }

        public ErrorVo(String errorCode, String errorFieldName, String errorMessage) :
            this(errorCode, errorFieldName, new MessageContent(DEFAULT_LANGUAGE, errorMessage))
        { }

        public ErrorVo(String errorCode, String errorFieldName, params MessageContent[] errorMessages)
        {
            messages = new Dictionary<String, String>();

            this.errorCode = errorCode;
            this.errorFieldName = errorFieldName;
            //this.errorMessage = errorMessage;
            if (errorMessages != null && errorMessages.Length > 0)
            {
                foreach (MessageContent error in errorMessages)
                {
                    messages.Add(error.LanguageCode, error.Message);
                }
            }
        }

        [DataMember]
        public String ErrorCode
        {
            get
            {
                return this.errorCode;
            }
            set
            {
                this.errorCode = value;
            }
        }

        [DataMember]
        public String ErrorFieldName
        {
            get
            {
                return this.errorFieldName;
            }
            set
            {
                this.errorFieldName = value;
            }
        }

        [DataMember]
        public String ErrorMessage
        {
            get
            {
                return messages.Values.First();
            }
            set
            {
                if (messages == null)
                {
                    messages = new Dictionary<String, String>();
                    messages[ErrorVo.DEFAULT_LANGUAGE] = value;
                }
                else
                {
                    messages[messages.Keys.First()] = value;
                }
            }
        }

        [DataMember]
        public List<MessageContent> LocalizedErrors
        {
            get
            {
                List<MessageContent> _list = new List<MessageContent>();
                foreach (String lang in this.messages.Keys)
                {
                    _list.Add(new MessageContent(lang, messages[lang]));
                }
                return _list;
            }
            set
            {
                List<MessageContent> _list = value;
                this.messages.Clear();
                foreach (MessageContent msg in _list)
                {
                    this.messages.Add(msg.LanguageCode, msg.Message);
                }
            }
        }

        [DataMember]
        internal Dictionary<String, String> ErrMessages
        {
            get
            {
                return this.messages;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
  
        public string ErrorMessages(string language)
        {
            if(this.messages.ContainsKey(language)){
                 return this.messages[language];
            }
            return this.messages.Values.First();
        }

        [DataMember]
        public List<String> ErrorString
        {
            get
            {
                return ErrorsString.Values.First();
            }
            set
            {
                // nothing
            }
        }

        [DataMember]
        public Dictionary<String, List<String>> ErrorsString
        {
            get
            {
                Dictionary<String, List<String>> errors = new Dictionary<String, List<String>>();
                foreach (String key in messages.Keys)
                {
                    List<String> l = new List<String>();
                    l.Add(errorCode);
                    l.Add(errorFieldName);
                    l.Add(messages[key]);
                    errors.Add(key, l);
                }
                return errors;
            }
            set
            {
                // nothing
            }
        }

        [DataMember]
        public Dictionary<String, String> ErrorInJson
        {
            get
            {
                return ErrorsInJson.Values.First();
            }
            set
            {
            }
        }

        [DataMember]
        public Dictionary<String, Dictionary<String, String>> ErrorsInJson
        {
            get
            {
                Dictionary<String, Dictionary<String, String>> errors = new Dictionary<String, Dictionary<String, String>>();
                foreach (String key in messages.Keys)
                {
                    Dictionary<string, string> r = new Dictionary<string, string>();
                    r.Add("errorCode", errorCode);
                    r.Add("errorField", errorFieldName);
                    r.Add("errorMessage", messages[key]);
                    errors.Add(key, r);
                }
                return errors;
            }
            set
            {
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else
            {
                if (obj.GetType().Equals(typeof(ErrorVo)))
                {
                    ErrorVo a = (ErrorVo)obj;
                    return (a.errorCode.Equals(this.errorCode));
                }
                else
                {
                    return false;
                }
            }
        }

    }
}