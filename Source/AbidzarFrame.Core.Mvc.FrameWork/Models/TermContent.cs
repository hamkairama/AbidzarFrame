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
    public class TermContent : ICloneable       //, IDisposable
    {
        [DataMember(Name="Language")]
        private String languageCode = null;
        [DataMember(Name="Descriptions")]
        private String description = null;

        public TermContent(String languageCode, String description)
        {
            this.languageCode = languageCode;
            this.description = description;
        }

        public TermContent() : this(null, null) { }

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

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType().Equals(typeof(TermContent)))
            {
                return this.languageCode.Equals(((TermContent) obj).languageCode);
            }

            return false;
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
        //            languageCode = null;
        //            description = null;
        //        }
                
        //    }
        //}

        //~TermContent()
        //{
        //    Dispose(false);

        //    languageCode = null;
        //    description = null;
        //}

    }
}
