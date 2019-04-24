using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class BaseModel
    {
        [DataMember()]
        public int Id { get; set; }

        [DataMember()]
        public string DibuatOleh { get; set; }

        [DataMember()]
        public System.DateTime DibuatTanggal { get; set; }

        [DataMember()]
        public string DieditOleh { get; set; }

        [DataMember()]
        public Nullable<System.DateTime> DieditTanggal { get; set; }

        [DataMember()]
        public bool SystemStatus { get; set; }

        [DataMember()]
        public string KodeRt { get; set; }

    }
}
