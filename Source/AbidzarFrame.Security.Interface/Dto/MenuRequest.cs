using System;
using AbidzarFrame.Utils;
using System.Runtime.Serialization;
using AbidzarFrame.Domain.Models;

namespace AbidzarFrame.Security.Interface.Dto
{
    [Serializable()]
    [DataContract()]
    public class MenuRequest : MenuBaseModel, ISecureRequest
    {
        [DataMember()]
        public string AuthenticationToken { get; set; }

        [DataMember()]
        public string Nik { get; set; }
    }
}
