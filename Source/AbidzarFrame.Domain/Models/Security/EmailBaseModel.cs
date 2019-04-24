using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class EmailBaseModel 
    {
        [DataMember()]
        public string Subject { get; set; }

        [DataMember()]
        public string Body { get; set; }

        [DataMember()]
        public bool IsBodyHtml { get; set; }

        [DataMember()]
        public string[] From { get; set; }

        [DataMember()]
        public string[] To { get; set; }

        [DataMember()]
        public string[] Cc { get; set; }

        [DataMember()]
        public string Attachment { get; set; }

        [DataMember()]
        public string KodeTemplate { get; set; }
        [DataMember()]
        public string Template { get; set; }

    }
}
