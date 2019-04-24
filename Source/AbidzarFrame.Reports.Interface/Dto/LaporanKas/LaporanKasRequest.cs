using AbidzarFrame.Utils;
using System;
using System.Runtime.Serialization;
using AbidzarFrame.Domain.Models;

namespace AbidzarFrame.Reports.Interface.Dto
{
    [Serializable()]
    [DataContract()]
    public class LaporanKasRequest : LaporanKasBaseModel, ISecureRequest
    {
        [DataMember()]
        public string AuthenticationToken { get; set; }

    }
}
