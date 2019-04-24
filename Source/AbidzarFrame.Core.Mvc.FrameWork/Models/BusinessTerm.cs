using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using AbidzarFrame.Core.Mvc.Helpers;

namespace AbidzarFrame.Core.Mvc.Models
{
    [DataContract]
    [Serializable]
    [KnownType(typeof(TermContent))]
    public class BusinessTerm : ICloneable          //, IDisposable
    {

        [DataMember(Name="TermName")]
        private String termName = null;
        [DataMember(Name="TermDescriptions")]
        private Dictionary<String, Dictionary<String, TermContent>> termDescriptions = null;

        public BusinessTerm(String termName) {
            this.termName = termName;
            this.termDescriptions = new Dictionary<String, Dictionary<String, TermContent>>();
        }

        public void AddValueDescriptions(String value, TermContent[] termDescriptions)
        {
            if (this.termDescriptions.ContainsKey(value))
            {
                Dictionary<String, TermContent> descriptions = this.termDescriptions[value];
                foreach (TermContent e in termDescriptions)
                {
                    if (descriptions.ContainsKey(e.LanguageCode))
                        descriptions[e.LanguageCode] = e;
                    else
                        descriptions.Add(e.LanguageCode, e);
                }
            }
            else
            {
                Dictionary<String, TermContent> descriptions = new Dictionary<String, TermContent>();
                foreach (TermContent e in termDescriptions)
                {
                    if (descriptions.ContainsKey(e.LanguageCode))
                        descriptions[e.LanguageCode] = e;
                    else
                        descriptions.Add(e.LanguageCode, e);
                }
                this.termDescriptions.Add(value, descriptions);
            }
        }

        public void AddValueDescription(String value, TermContent termDescription)
        {
            TermContent[] descriptions = {termDescription};
            AddValueDescriptions(value, descriptions);
        }

        public void AddValueDescriptions(BusinessTerm term)
        {
            if (this.termName.Equals(term.termName))
            {
                foreach (String value in term.termDescriptions.Keys)
                {
                    Dictionary<String, TermContent> contents = null;
                    if (!this.termDescriptions.ContainsKey(value))
                    {
                        contents = new Dictionary<String, TermContent>();
                        this.termDescriptions.Add(value, contents);
                    }
                    contents = this.termDescriptions[value];

                    Dictionary<String, TermContent> localizedContent = term.termDescriptions[value];
                    foreach (String language in localizedContent.Keys) {
                        if (contents.ContainsKey(language))
                            contents[language] = (TermContent)localizedContent[language].Clone();
                        else
                            contents.Add(language, (TermContent)localizedContent[language].Clone());
                    }
                }
            }
        }

        public String TermName
        {
            get
            {
                return this.termName;
            }
            set
            {
                this.termName = value;
            }
        }

        public String GetDescription(String value, String language, String defaultValue = "")
        {
            if (value != null)
            {
                if (termDescriptions.ContainsKey(value))
                {
                    Dictionary<String, TermContent> content = termDescriptions[value];
                    if (content.ContainsKey(language))
                    {
                        TermContent term = content[language];
                        return term.Description;
                    }
                    return defaultValue;
                }
            }
            return defaultValue;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        //private bool disposed = false;

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        //public virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            foreach (Dictionary<String, TermContent> terms in termDescriptions.Values)
        //            {
        //                foreach (TermContent content in terms.Values)
        //                {
        //                    content.Dispose();
        //                }
        //                terms.Clear();
        //            }
        //            termDescriptions.Clear();

        //            termName = null;
        //            termDescriptions = null;
        //        }
                
        //    }
        //}

        //~BusinessTerm()
        //{
        //    Dispose(false);

        //    foreach (Dictionary<String, TermContent> terms in termDescriptions.Values)
        //    {
        //        foreach (TermContent content in terms.Values)
        //        {
        //            content.Dispose();
        //        }
        //        terms.Clear();
        //    }
        //    termDescriptions.Clear();
            
        //    termName = null;
        //    termDescriptions = null;
        //}

    }
}
