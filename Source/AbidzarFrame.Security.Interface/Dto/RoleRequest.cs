using AbidzarFrame.Domain.Models;
using AbidzarFrame.Utils;
using System;
using System.Runtime.Serialization;

namespace AbidzarFrame.Security.Interface.Dto
{
    [Serializable()]
    [DataContract()]
    public class RoleRequest : RoleBaseModel, ISecureRequest
    {
        [DataMember()]
        public string AuthenticationToken { get; set; }
    }
}
