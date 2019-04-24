using AbidzarFrame.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Master.Interface.Dto
{
    [Serializable()]
    [DataContract()]
    public class StrukturResult : StrukturBaseModel
    {
        [DataMember()]
        public string NamaJabatan { get; set; }

        [DataMember()]
        public string Nama { get; set; }

        [DataMember()]
        public string Nik { get; set; }

        [DataMember()]
        public string NamaFile { get; set; }
    }
}
