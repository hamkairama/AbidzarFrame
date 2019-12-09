using AbidzarFrame.Utils;
using System;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using AbidzarFrame.Domain.Models;

namespace AbidzarFrame.Master.Interface.Dto
{
    [Serializable()]
    [DataContract()]
    public class DetailJenisInformasiRequest : DetailJenisInformasiBaseModel, ISecureRequest
    {
        [DataMember()]
        public string AuthenticationToken { get; set; }

        [DataMember()]
        public int LamaHari { get; set; }

        [DataMember()]
        public int IdRw { get; set; }
    }
}
