using System;
using AbidzarFrame.Utils;
using System.Runtime.Serialization;
using AbidzarFrame.Domain.Models;


namespace AbidzarFrame.Security.Interface.Dto
{
    [Serializable()]
    [DataContract()]
    public class RoleMenuRequest : RoleMenuBaseModel, ISecureRequest
    {
        [DataMember()]
        public string AuthenticationToken { get; set; }
    }
}
