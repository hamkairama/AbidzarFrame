using AbidzarFrame.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Questioner.Interface.Dto
{
    [Serializable()]
    [DataContract()]
    public class TanyaRtDetailResult : TanyaRtDetailBaseModel
    {

        [DataMember()]
        public string Nama { get; set; }

        [DataMember()]
        public string NamaFile { get; set; }
    }
}
