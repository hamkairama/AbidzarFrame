using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.Web.Mvc;

namespace AbidzarFrame.Core.Mvc.Models
{
    
    //[XmlRoot("Errors")]
    [Serializable]
    [DataContract]
    public class Errors
    {

        private ArrayList errorList = null;

        public Errors()
        {
            errorList = new ArrayList();
        }

        public void Add(ErrorVo error)
        {
            errorList.Add(error);
        }

        public void Add(Errors errors)
        {
            foreach (ErrorVo e in errors.ErrorList)
            {
                errorList.Add(e);
            }
        }

        //[XmlElement("HasError")]
        [DataMember]
        public Boolean HasError
        {
            get
            {
                return (errorList.Count > 0);
            }
            set
            {
                // do nothing
            }
        }

        //[XmlArray("ErrorList")]
        //[XmlArrayItem("Error", typeof(ErrorVo))]
        [DataMember]
        public ErrorVo[] ErrorList
        {
            get
            {
                return (ErrorVo[])errorList.ToArray(typeof(ErrorVo));
            }
            set
            {
                errorList = new ArrayList((ErrorVo[])value);
            }
        }

        [DataMember]
        public Dictionary<String, List<List<string>>> ErrorListString
        {
            get
            {
                Dictionary<String, List<List<string>>> l = new Dictionary<String, List<List<string>>>();
                foreach (ErrorVo e in errorList)
                {
                    Dictionary<String, List<string>> m = e.ErrorsString;
                    foreach (String k in e.ErrMessages.Keys)
                    {
                        List<List<string>> t = null;
                        if (!l.ContainsKey(k))
                        {
                            t = new List<List<string>>();
                            l.Add(k, t);
                        }
                        else
                        {
                            t = l[k];
                        }
                        t.Add(m[k]);
                    }
                }
                return l;
            }
            set
            {
                // nothing
            }
        }

        public List<Dictionary<string, string>> ErrorsInJson
        {
            get
            {
                List<Dictionary<string, string>> l = new List<Dictionary<string, string>>();
                foreach (ErrorVo e in errorList)
                {
                    l.Add(e.ErrorInJson);
                }
                return l;
            }
            set
            {
            }
        }

        public Dictionary<String, List<Dictionary<string, string>>> LocalizedErrorsInJson
        {
            get
            {
                Dictionary<String, Dictionary<int, Dictionary<string, string>>> l = new Dictionary<String, Dictionary<int, Dictionary<string, string>>>();
                int index = 0;
                foreach (ErrorVo e in errorList)
                {
                    Dictionary<String, Dictionary<string, string>> f = e.ErrorsInJson;
                    foreach (String k in f.Keys)
                    {
                        if (!l.ContainsKey(k))
                        {
                            l.Add(k, new Dictionary<int, Dictionary<string, string>>());
                        }
                        Dictionary<int, Dictionary<string, string>> e2 = l[k];
                        e2.Add(index, e.ErrorsInJson[k]);
                    }
                    index++;
                }
                if (l.Keys.Contains(ErrorVo.DEFAULT_LANGUAGE))
                {
                    Dictionary<int, Dictionary<String, String>> d = l[ErrorVo.DEFAULT_LANGUAGE];
                    foreach (String k in l.Keys)
                    {
                        if (ErrorVo.DEFAULT_LANGUAGE.Equals(k)) continue;

                        Dictionary<int, Dictionary<String, String>> t = l[k];
                        foreach (int key in d.Keys)
                        {
                            if (!t.ContainsKey(key))
                            {
                                t.Add(key, d[key]);
                            }
                        }
                    }
                }
                Dictionary<String, List<Dictionary<string, string>>> l2 = new Dictionary<String, List<Dictionary<string, string>>>();
                foreach (String key in l.Keys)
                {
                    l2.Add(key, l[key].Values.ToList());
                }
                return l2;
            }
            set
            {
            }
        }

        public Boolean ContainsError(ErrorVo err)
        {
            foreach (ErrorVo e in this.errorList)
            {
                if (e.Equals(err)) return true;
            }
            return false;
        }
    }
}