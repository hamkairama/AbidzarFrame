using System;
using System.Runtime.Serialization;
using AbidzarFrame.Utils;
using AbidzarFrame.Domain.Models;

namespace AbidzarFrame.Security.Interface.Dto
{
    [Serializable()]
    [DataContract()]
    public class UserRequest : UserBaseModel, ISecureRequest
    {       
        [DataMember()]
        public string AuthenticationToken { get; set; }
        [DataMember()]
        public DateTime TanggalLahir { get; set; }
    }
}
